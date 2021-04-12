using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorSystem : MonoBehaviour
{
    [SerializeField] Rocky player;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] Vendor vendor;
    public Vendor pastVendor;

    public bool canLeaveInteraction;

    public int currentItem;

    public bool cached;

    private void Start()
    {
        dialogBox.EnableItemText(false);
        for(int i = 0; i < vendor.GetItemNames().Count; i++){
            dialogBox.itemTexts[i].text = vendor.GetItemNames()[i];
            dialogBox.itemPrices[i].text = vendor.GetItemPrices()[i].ToString();
        }
        cached = true;
    }

    public void SetVendor(Vendor _vendor){
        pastVendor = vendor;
        vendor = _vendor;


    }

    public IEnumerator SetupVendor()
    {
        if (pastVendor != null && !vendor.GetVendorType().Equals(pastVendor.GetVendorType()))
        {
            dialogBox.ResetVendor(vendor);
        }
        cached = false;
        dialogBox.EnableItemText(false);
        currentItem = 0;
        // if vendor is sold out
        if (dialogBox.itemTexts.Count == 0)
        {
            yield return dialogBox.TypeDialog(vendor.GetText());
            yield return new WaitForSeconds(1f / 30);
            canLeaveInteraction = true;
        }
        // if vendor has items to sell
        else
        {
            if (!cached)
            {
                for (int i = 0; i < vendor.GetItemNames().Count; i++)
                {
                    dialogBox.itemTexts[i].text = vendor.GetItemNames()[i];
                    dialogBox.itemPrices[i].text = vendor.GetItemPrices()[i].ToString();
                }
            }
            yield return dialogBox.TypeDialog(vendor.GetText());
            yield return new WaitForSeconds(1f / 30);

            ItemSelection();
        }
    }

    void ItemSelection()
    {
        dialogBox.EnableItemText(true);
    }

    private void Update()
    {
        if (dialogBox.itemsShown)
        {
            HandleItemSelection();
            canLeaveInteraction = true;
        }
    }

    void HandleItemSelection()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentItem + 1 < vendor.itemNames.Count)
            {
                ++currentItem;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentItem > 0 && vendor.itemNames.Count > 1)
            {
                --currentItem;
            }
        }
        dialogBox.UpdateItemSelection(currentItem);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Pressed");

            StartCoroutine(ItemSelected(dialogBox.itemTexts[currentItem], currentItem));
        }

    }

    IEnumerator ItemSelected(Text textEle, int currentItem)
    {
        canLeaveInteraction = false;

        var price = vendor.itemPrices[currentItem];
        if (player.SpendCrystal(price))
        {
            switch ((int) vendor.GetVendorType())
            {
                case 0:
                    vendor.PowerUp(textEle.text);
                    break;
                case 1:
                    vendor.ObtainFood(textEle.text);
                    break;
                case 2:
                    //vendor.GetRing(textEle.text);
                    break;
                default:
                    break;
            }

            dialogBox.EnableItemText(false);
            vendor.RemoveItemFromLists(textEle.text);
            textEle.gameObject.SetActive(false);
            yield return dialogBox.TypeDialog(vendor.GetSoldText(true, textEle.text));
            yield return new WaitForSeconds(1f);
        } 
        else
        {
            dialogBox.EnableItemText(false);
            yield return dialogBox.TypeDialog(vendor.GetSoldText(false, textEle.text));
            yield return new WaitForSeconds(1f);
        }

        canLeaveInteraction = true;

        StartCoroutine(SetupVendor());
        cached = false;
    }

    
}
