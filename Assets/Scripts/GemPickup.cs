using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public int value;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            other.GetComponent<Rocky>().PickUpCrystal(value);
            Destroy(gameObject);
        }
    }
}
