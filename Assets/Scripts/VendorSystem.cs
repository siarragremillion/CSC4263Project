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

    public bool canLeaveInteraction;

    public int currentItem;

    private void Start()
    {
        dialogBox.EnableItemText(false);
        for(int i = 0; i < vendor.GetItemNames().Length; i++){
            dialogBox.itemTexts[i].text = vendor.GetItemNames()[i];
            dialogBox.itemPrices[i].text = vendor.GetItemPrices()[i].ToString();
        }
    }

    public void SetVendor(Vendor _vendor){
        vendor = _vendor;
    }

    public IEnumerator SetupVendor()
    {
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
            if (currentItem + 1 < dialogBox.itemTexts.Count)
            {
                ++currentItem;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentItem > 0 && dialogBox.itemTexts.Count > 1)
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

        var priceText = dialogBox.itemPrices[currentItem];
        var price = Int32.Parse(priceText.text);
        if (player.SpendCrystal(price))
        {

            vendor.PowerUp(textEle.text);

            dialogBox.EnableItemText(false);
            dialogBox.RemoveItemFromList(textEle);
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
    }

    
}
