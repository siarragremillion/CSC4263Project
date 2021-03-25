using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocky : MonoBehaviour
{
    public int Health;

    public int MaxHealth;

    public int Crystals;

    public int MaxCrystals;

    public GameObject Gun;

    public int currentWeapon;

    public bool alive;


    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 3;
        Crystals = 0;
        Health = MaxHealth;
        alive = true;
        Physics2D.IgnoreCollision(Gun.transform.GetChild(0).GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
        }
        else
        {
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
        if (Crystals < MaxCrystals)
        {
            Crystals++;
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
