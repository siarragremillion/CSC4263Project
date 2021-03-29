using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    [SerializeField] Rocky rocky;

    [SerializeField] private VendorType vendorType;
    [SerializeField] private bool canSell;
    [SerializeField] private String canSellText, cannotSellText;

    // Items to sell info
    [SerializeField] private String[] itemNames;
    [SerializeField] private int[] itemPrices;

    public enum VendorType {
        Weaponsmith,
        Grocer,
        Jeweler
    }

    public void Start(){

        rocky = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>();

        canSell = true;
        switch(vendorType){
            case VendorType.Weaponsmith:
               SetUpWeaponsmith();
               break;
            case VendorType.Grocer:
                SetUpGrocer();
                break;
            case VendorType.Jeweler:
                SetUpJeweler();
                break;
            default:
                break;
        }
    }

    private void SetUpWeaponsmith(){
        canSellText = "Hey Rock, the names Paulie. What weapon do you want to upgrade?";
        cannotSellText = "Hey Rock, ain't got anything for you.";

        itemNames = new String[]{"Sword", "Gun"};
        itemPrices = new int[]{2, 4};
    }

    private void SetUpGrocer(){
        canSellText = "Thanks for saving me! How about a snack to celebrate?";
        cannotSellText = "By golly, I'm just fresh out.";

        itemNames = new String[]{"Food", "Drink"};
        itemPrices = new int[]{25, 10};
    }

    private void SetUpJeweler(){
        canSellText = "I've got a fine selection of gold rings for you to choose from.";
        cannotSellText = "You've already bought out my stock!";

        itemNames = new String[]{"Ruby", "Jade"};
        itemPrices = new int[]{200, 200};
    }

    public void Update() {
        
    }

    public String[] GetItemNames(){
        return itemNames;
    }

    public int[] GetItemPrices(){
        return itemPrices;
    }

    public VendorType GetVendorType() {
        return vendorType;
    }

    public bool CanSell(){
        return canSell;
    }

    public String GetText() {
        if(canSell) return canSellText;
        else return cannotSellText;
    }

    /*
    TODO put this code here

        if (player.crystals >= price)
        {

            vendor.PowerUp(textEle.text);

            dialogBox.EnableItemText(false);
            dialogBox.RemoveItemFromList(textEle);
            yield return dialogBox.TypeDialog(vendor.GetSoldText(true, textEle.text));
            yield return new WaitForSeconds(1f);

            player.crystals -= price;
        } 
        else
        {
            dialogBox.EnableItemText(false);
            yield return dialogBox.TypeDialog(vendor.GetSoldText(false, textEle.text));
            yield return new WaitForSeconds(1f);
        }
    */

    public String GetSoldText(bool hasEnoughGems){
        if(hasEnoughGems) return "Thank you for purchasing!";
        else return "You do not have enough gems to purchase this.";
    }

    public String GetSoldText(bool hasEnoughGems, String item){
        if(hasEnoughGems) return ($"Thank you for purchasing the {item}!");
        else return ($"You do not have enough gems to purchase the {item}.");
    }

    public void PowerUp(String itemBought){
        switch (itemBought)
        {
            case "Sword":
                rocky.swordPower *= 2;
                break;
            case "Gun":
                rocky.gunPower *= 2;
                break;
            default:
                break;
        }
    }

}
