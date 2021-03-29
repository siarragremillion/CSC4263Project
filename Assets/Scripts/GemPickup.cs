using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public int value;

    private bool pickedUp = false;
    
    private float destructRadius = 0.5f;

    private void Start()
    {
        value = 1;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !pickedUp){
            pickedUp = true;
            Debug.Log("Rocky gained a crystal");
            /*var rocky = other.GetComponent<Rocky>();
                
            rocky.PickUpCrystal(value);*/
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            if(Mathf.Abs(transform.position.x - other.transform.position.x) <= destructRadius && Mathf.Abs(transform.position.y - other.transform.position.y) <= destructRadius){
                Destroy(gameObject);
                var rocky = other.GetComponent<Rocky>();

                rocky.PickUpCrystal(value);
            }
        }
    }
}
