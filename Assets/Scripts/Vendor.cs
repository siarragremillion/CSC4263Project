using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    [SerializeField] private VendorType vendorType;
    [SerializeField] private bool canSell;
    [SerializeField] private String canSellText;
    [SerializeField] private String cannotSellText;

    // Items to sell info
    [SerializeField] private String[] itemNames;
    [SerializeField] private int[] itemPrices;

    public enum VendorType {
        Weaponsmith,
        Grocer,
        Jeweler
    }

    public void Start(){
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
        itemPrices = new int[]{50, 100};
    }

    private void SetUpGrocer(){
        canSellText = "Hey Rock, the names Paulie. What weapon do you want to upgrade?";
        cannotSellText = "Hey Rock, ain't got anything for you.";

    }

    private void SetUpJeweler(){
        canSellText = "Hey Rock, the names Paulie. What weapon do you want to upgrade?";
        cannotSellText = "Hey Rock, ain't got anything for you.";

    }

    public void Update() {
        
    }

    public VendorType GetVendorType() {
        return vendorType;
    }

    public bool CanSell(){
        return canSell;
    }

    public String GetText() {
        Debug.Log("CAN SELL: " + canSell);
        if(canSell) return canSellText;
        else return cannotSellText;
    }
}
