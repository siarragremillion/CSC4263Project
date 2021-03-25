using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public int value;
    
    private float destructRadius = 0.5f;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            other.GetComponent<Rocky>().PickUpCrystal(value);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(Mathf.Abs(transform.position.x - other.transform.position.x) <= destructRadius && Mathf.Abs(transform.position.y - other.transform.position.y) <= destructRadius){
                Destroy(gameObject);
            }
        }
    }
}
