using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject rocky = GameObject.FindGameObjectWithTag("Player");
        movement = rocky.GetComponent<PlayerMovement>().GetMovement();
        if(movement.x == 0 && movement.y == 0){
            rb.velocity = -transform.up * speed;
            Debug.Log("Test");
        }
        else{
            rb.velocity = rocky.GetComponent<PlayerMovement>().GetMovement() * speed;
            Debug.Log("Test 2");
        }
    }
}
