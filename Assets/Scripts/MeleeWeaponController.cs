using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    public GameObject MeleeWeapon;
    public Transform ShootPoint;
    public bool isActive;
    public float fireRate;
    private float nextFire;

    public void SetActive(bool _isActive)
    {
        if(_isActive){
            Instantiate(MeleeWeapon, ShootPoint.position, ShootPoint.rotation, ShootPoint);
            isActive = true;
        }
        else{
            GameObject sword = GameObject.FindGameObjectWithTag("Sword");
            Destroy(sword);
            isActive = false;
            //Destroy(RangedWeapon);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && isActive )
        {
            nextFire = Time.time + fireRate;
            
        } 
    }
    
}
