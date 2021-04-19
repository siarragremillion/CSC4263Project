using System.Collections;
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
                StartCoroutine(Interact());
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
                GlobalControl.Instance.canPause = true;
                var music = GameObject.FindGameObjectWithTag("Music");
                var musicSource = music.GetComponent<AudioSource>();
                musicSource.UnPause();
            }   
        }

    }

    public IEnumerator Interact()
    {
        var music = GameObject.FindGameObjectWithTag("Music");
        var musicSource = music.GetComponent<AudioSource>();
        musicSource.Pause();
        yield return new WaitForSeconds(.3f);
        GlobalControl.Instance.canPause = false;
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
