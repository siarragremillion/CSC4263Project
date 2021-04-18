using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocky : MonoBehaviour
{
    public int Health;

    public int MaxHealth;

    public int crystals;

    public int maxCrystals;

    public GameObject Gun;

    public GameObject currentSearchable = null;
    public GameObject currentInteractable = null;

    public int currentWeapon;

    public bool alive;

    public int swordPower;
    public int gunPower;
    public bool waterRingisActive;

    public DialogHandler dialogHandler;
    public JournalSystem journalSystem;

    private Ring ring;

    public bool hasDrink;
    public bool hasFood;

    // Start is called before the first frame update
    void Start()
    {
        Health = GlobalControl.Instance.Health;
        MaxHealth = GlobalControl.Instance.MaxHealth;
        crystals = GlobalControl.Instance.crystals;
        maxCrystals = GlobalControl.Instance.maxCrystals;
        currentWeapon = GlobalControl.Instance.currentWeapon;
        alive = GlobalControl.Instance.alive;
        swordPower = GlobalControl.Instance.swordPower;
        gunPower = GlobalControl.Instance.gunPower;
        hasFood = GlobalControl.Instance.hasFood;
        hasDrink = GlobalControl.Instance.hasDrink;
        GemHandler.gemAmount = crystals;
        ring = GlobalControl.Instance.ring;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Rocky Is Dead");
            alive = false;
            // StartCoroutine(UIManager.GameOver());
            UIManager.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentWeapon < 2)
            {
                currentWeapon++;
                ChangeWeapon();
            }
            else
            {
                currentWeapon = 0;
                ChangeWeapon();
            }
        }

        //interaction
        if (Input.GetKeyDown(KeyCode.E) && !dialogHandler.inDialog)
        {
            if (currentSearchable) //if player is collided with a searchable
            {
                currentSearchable.SendMessage("isSearched");
            }
            if (currentInteractable)
            {
                StartCoroutine(Interactable());
            }
        }

    }

    // Save data to global control
    public void SavePlayer()
    {
        GlobalControl.Instance.Health = Health;
        GlobalControl.Instance.MaxHealth = MaxHealth;
        GlobalControl.Instance.crystals = crystals;
        GlobalControl.Instance.maxCrystals = maxCrystals;
        GlobalControl.Instance.currentWeapon = currentWeapon;
        GlobalControl.Instance.alive = alive;
        GlobalControl.Instance.hasDrink = hasDrink;
        GlobalControl.Instance.hasFood = hasFood;
        GlobalControl.Instance.ring = ring;
    }

    public void ChangeWeapon()
    {
        if (currentWeapon == 0)
        {
            GetComponent<RangedWeaponController>().SetActive(true);
            GetComponent<MeleeWeaponController>().SetActive(false);

        }
        else if (currentWeapon == 1)
        {
            GetComponent<RangedWeaponController>().SetActive(false);
            GetComponent<MeleeWeaponController>().SetActive(true);
        }
        else
        {
            GetComponent<MeleeWeaponController>().SetActive(false);
            GetComponent<RangedWeaponController>().SetActive(false);
            Debug.Log("This is where melee weapon will be deactivated so no weapons are active");
        }

    }

    public void PickUpHeart()
    {
        if (Health < MaxHealth)
        {
            Health++;
        }
    }

    public void EatFood(int HealthAmount)
    {
        Health += HealthAmount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void PickUpCrystal()
    {
        if (crystals < maxCrystals)
        {
            crystals++;
            GemHandler.gemAmount++;
        }
    }

    public void PickUpCrystal(int value)
    {
        if (crystals < maxCrystals)
        {
            crystals += value;
            GemHandler.gemAmount = crystals;
        }
    }

    public bool SpendCrystal(int value)
    {
        if (crystals >= value)
        {
            crystals -= value;
            GemHandler.gemAmount = crystals;
            return true;
        }
        return false;
    }

    // void OnCollisionEnter2D (Collision2D collision)
    // {
    //     if(collision.gameObject.tag == "Gun")
    //     {
    //         Physics2D.IgnoreCollision(Gun.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //     }
    // }

    //for searchables
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Searchable"))
        {
            Debug.Log(other.name);
            currentSearchable = other.gameObject;
        }
        if (other.CompareTag("Ring"))
        {
            currentInteractable = other.gameObject;
            ring = currentInteractable.GetComponent<Ring>();
            Debug.Log(ring.GetRingType());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Searchable"))
        {
            if (other.gameObject == currentSearchable)
            {
                currentSearchable = null;
            }
        }
        if (other.CompareTag("Ring"))
        {
            if (other.gameObject == currentInteractable)
            {
                currentInteractable = null;
            }
        }
    }

    IEnumerator Interactable()
    {
        var music = GameObject.FindGameObjectWithTag("Music");
        var musicSource = music.GetComponent<AudioSource>();
        musicSource.Pause();

        currentInteractable.SendMessage("isPickedUp");
        GetComponent<RingHolder>().AddRing(ring.GetRingType());
        GetComponent<RingHolder>().SetActiveRing(ring.GetRingType());
        string dialogText = "";
        if (ring.GetRingType() == Ring.RingType.RedSilver)
        {
            dialogText = "You found the Fire Ring!\nYou can now walk through fire.";
            journalSystem.FindJournal(3);
        }
        else if (ring.GetRingType() == Ring.RingType.BlueSilver)
        {
            dialogText = "You found the Water Ring!\nYou can now walk on water.";
            journalSystem.FindJournal(2);
        }
        else if (ring.GetRingType() == Ring.RingType.GreenSilver)
        {
            dialogText = "You found the Earch Ring!\nYou can now move heavy boulders.";
            journalSystem.FindJournal(4);
        }

        dialogHandler.gameObject.SetActive(true);
        StartCoroutine(dialogHandler.TypeDialog(dialogText));
        

        gameObject.GetComponent<PlayerMovement>().FreezeMovement();
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.itemPickup);

        yield return new WaitForSeconds(SfxManager.sfxInstance.itemPickup.length / 2);

    }


}
