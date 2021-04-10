using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    public GameObject MeleeWeapon;
    
    public GameObject sword;

    public Transform ShootPoint;
    public bool isActive;

    public void SetActive(bool _isActive)
    {
        if(_isActive){
            Instantiate(MeleeWeapon, ShootPoint.position, ShootPoint.rotation, ShootPoint);
            sword = GameObject.FindGameObjectWithTag("Sword");
            isActive = true;
        }
        else{
            Destroy(sword);
            isActive = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive )
        {
            Debug.Log("I am in here");
            sword.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;

        } 

        if(Input.GetKeyUp(KeyCode.Space) && isActive){
            sword.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;

        }
    }
    
}
