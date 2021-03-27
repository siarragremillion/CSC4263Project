using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorInteraction : MonoBehaviour
{
    [SerializeField] public bool canInteract;
    [SerializeField] VendorSystem vendorSystem;
    [SerializeField] GameObject rocky;


    // Update is called once per frame
    void Update()
    {
        if (canInteract) {
            Debug.Log("Abbiesplaining");
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("AbbiesplainingTRUE");
                canInteract = false;
                rocky.GetComponent<PlayerMovement>().FreezeMovement();
                vendorSystem.gameObject.SetActive(true);
                StartCoroutine(vendorSystem.SetupVendor());
            }

        }

        if (vendorSystem.canLeaveInteraction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                vendorSystem.gameObject.SetActive(false);
                rocky.GetComponent<PlayerMovement>().UnfreezeMovement();
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Collided");
            canInteract = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Done Collided");
            canInteract = false;
            vendorSystem.gameObject.SetActive(false);
        }
    }
}
