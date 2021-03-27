using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorSystem : MonoBehaviour
{
    [SerializeField] Rocky player;
    [SerializeField] DialogBox dialogBox;

    public bool canLeaveInteraction;

    public int currentItem;

    private void Start()
    {
        dialogBox.EnableItemText(false);
    }

    public IEnumerator SetupVendor()
    {
        dialogBox.EnableItemText(false);
        currentItem = 0;
        if (dialogBox.itemTexts.Count == 0)
        {
            yield return dialogBox.TypeDialog("Hey Rock, ain't got anything for you.");
            yield return new WaitForSeconds(1f / 30);
            canLeaveInteraction = true;
        }
        else
        {
            yield return dialogBox.TypeDialog("Hey Rock, the names Paulie. What weapon do you want to upgrade?");
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
        if (player.crystals >= price)
        {
            switch (textEle.text)
            {
                case "Sword":
                    player.swordPower *= 2;
                    break;
                case "Gun":
                    player.gunPower *= 2;
                    break;
                default:
                    break;
            }

            dialogBox.EnableItemText(false);
            dialogBox.RemoveItemFromList(textEle);
            yield return dialogBox.TypeDialog($"Thank you for purchasing the {textEle.text} Upgrade!");
            yield return new WaitForSeconds(1f);

            player.crystals -= price;
            /*while (!Input.GetKeyDown(KeyCode.E))
            {

            }*/
        } 
        else
        {
            dialogBox.EnableItemText(false);
            yield return dialogBox.TypeDialog($"You do not have enough gems to purchase the {textEle.text} Upgrade.");
            yield return new WaitForSeconds(1f);
        }

        canLeaveInteraction = true;

        StartCoroutine(SetupVendor());
    }

    
}
