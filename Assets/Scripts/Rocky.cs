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

    public int currentWeapon;

    public bool alive;

    public int swordPower;
    public int gunPower;

    public List<JournalEntry> Journal;
    // Start is called before the first frame update
    void Start()
    {
        swordPower = 3;
        gunPower = 2;
        MaxHealth = 3;
        crystals = 0;
        Health = MaxHealth;
        alive = true;
        //Physics2D.IgnoreCollision(Gun.transform.GetChild(0).GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
        Journal = new List<JournalEntry>() { new JournalEntry() { Title = "HELP!!!!", 
            Content = string.Format("Dear Rocky, /n/n I'm trapped at the bottom of this cave. I was searching for the secrets hidden within. Please come find me! You can switch weapons by pressing the E key."),
            Author = "Crystal \"Chris\" Chrisington ",
            Date = "01/11/19XX"
        } };
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            alive = false;
            UIManager.GameOver();
        }
        if(Input.GetKeyDown(KeyCode.F)){
            if(currentWeapon < 2){
                currentWeapon++;
                ChangeWeapon();
            }
            else{
                currentWeapon = 0;
                ChangeWeapon();
            }
        }
    }

    public void ChangeWeapon(){
        if(currentWeapon == 0)
        {
            GetComponent<RangedWeaponController>().SetActive(true);
        }
        else if(currentWeapon == 1)
        {
            GetComponent<RangedWeaponController>().SetActive(false);
            GetComponent<MeleeWeaponController>().SetActive(true);
        }
        else
        {
            GetComponent<MeleeWeaponController>().SetActive(false);
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
            GemHandler.gemAmount += value;
        }
    }

    // void OnCollisionEnter2D (Collision2D collision)
    // {
    //     if(collision.gameObject.tag == "Gun")
    //     {
    //         Physics2D.IgnoreCollision(Gun.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //     }
    // }
}
