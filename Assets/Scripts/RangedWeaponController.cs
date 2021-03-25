using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponController : MonoBehaviour
{
    public Transform ShootPoint;
    public Transform GunPoint;
    public GameObject RangedWeapon;
    public GameObject bullet;
    public float fireRate;
    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
        }    
    }

    public void SetActive(bool isActive)
    {
        if(isActive == true){
            Instantiate(RangedWeapon, GunPoint.position, GunPoint.rotation, GunPoint);
            Debug.Log("Yass Queen");
        }
        else{
            Debug.Log("Werk it girl");
            //Destroy(RangedWeapon);
        }
    }
}
