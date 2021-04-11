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
    public bool isActive;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && isActive)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, ShootPoint.position, GetComponent<PlayerMovement>().direction);
        }    
    }

    public void SetActive(bool _isActive)
    {
        if(_isActive){
            Instantiate(RangedWeapon, GunPoint.position, GunPoint.rotation, GunPoint);
            isActive = true;
            Debug.Log("Yass Queen");
        }
        else{
            Debug.Log("Werk it girl");
            GameObject gun = GameObject.FindGameObjectWithTag("Gun");
            Destroy(gun);
            isActive = false;
            //Destroy(RangedWeapon);
        }
    }
}
