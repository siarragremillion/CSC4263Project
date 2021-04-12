using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    [SerializeField] Rocky rocky;

    [SerializeField] private VendorType vendorType;
    [SerializeField] private bool canSell;
    [SerializeField] private string canSellText, cannotSellText;

    // Items to sell info
    [SerializeField] public List<string> itemNames;
    [SerializeField] public List<int> itemPrices;

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

        itemNames = new List<string> {"Sword", "Gun"};
        itemPrices = new List<int> {2, 4};
    }

    private void SetUpGrocer(){
        canSellText = "Thanks for saving me! How about a snack to celebrate?";
        cannotSellText = "By golly, I'm just fresh out.";

        itemNames = new List<string> {"Food", "Drink"};
        itemPrices = new List<int> {25, 10};
    }

    private void SetUpJeweler(){
        canSellText = "I've got a fine selection of gold rings for you to choose from.";
        cannotSellText = "You've already bought out my stock!";

        itemNames = new List<string> {"Ruby", "Jade"};
        itemPrices = new List<int> {200, 200};
    }

    public void Update() {
        
    }

    public void RemoveItemFromLists(string itemName)
    {
        if (itemNames.Count == 0)
        {
            Debug.LogError("There are no more items, but they still were able to remove an item");
        }

        else
        {
            var index = itemNames.IndexOf(itemName);
            itemPrices.RemoveAt(index);
            itemNames.RemoveAt(index);

            if (itemNames.Count == 0)
            {
                SetCanSell(false);
            }
        }
    }

    public List<string> GetItemNames(){
        return itemNames;
    }

    public List<int> GetItemPrices(){
        return itemPrices;
    }

    public VendorType GetVendorType() {
        return vendorType;
    }

    public bool CanSell(){
        return canSell;
    }

    public void SetCanSell(bool _canSell)
    {
        canSell = _canSell;
    }

    public string GetText() {
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

    public string GetSoldText(bool hasEnoughGems){
        if(hasEnoughGems) return "Thank you for purchasing!";
        else return "You do not have enough gems to purchase this.";
    }

    public string GetSoldText(bool hasEnoughGems, string item){
        if(hasEnoughGems) return ($"Thank you for purchasing the {item}!");
        else return ($"You do not have enough gems to purchase the {item}.");
    }

    public void PowerUp(string itemBought){
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

    public void ObtainFood(string itemBought)
    {
        switch (itemBought)
        {
            case "Food":
                rocky.hasFood = true;
                break;
            case "Drink":
                rocky.hasDrink = true;
                break;
            default:
                break;
        }
    }

}
