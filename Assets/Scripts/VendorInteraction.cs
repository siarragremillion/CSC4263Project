using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorInteraction : MonoBehaviour
{
    public bool canInteract = false;
    [SerializeField] VendorSystem vendorSystem;
    [SerializeField] GameObject rocky;
    [SerializeField] Vendor vendor;

    private bool sameVendor;

    // Update is called once per frame
    void Update()
    {
        if (canInteract) {
            if (Input.GetKeyDown(KeyCode.E)) {
                canInteract = false;
                rocky.GetComponent<PlayerMovement>().FreezeMovement();
                vendorSystem.gameObject.SetActive(true);
                Debug.Log("Showing");
                if (sameVendor)
                {
                    vendorSystem.SetVendor(vendor);
                }
                StartCoroutine(vendorSystem.SetupVendor());
                vendorSystem.cached = false;
            }

        }

        if (vendorSystem.canLeaveInteraction && sameVendor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                vendorSystem.gameObject.SetActive(false);
                rocky.GetComponent<PlayerMovement>().UnfreezeMovement();
                vendorSystem.canLeaveInteraction = false;
                canInteract = true;
            }   
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        sameVendor = true;
        Debug.Log(vendor.GetVendorType());
        if (other.transform.tag.Equals("Player"))
        {
            canInteract = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        sameVendor = false;
        Debug.Log(vendor.GetVendorType());
        canInteract = false;
        if (other.transform.tag.Equals("Player"))
        {
            
            vendorSystem.gameObject.SetActive(false);
        }
    }
}
