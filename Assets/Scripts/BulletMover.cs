using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject rocky = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = rocky.GetComponent<PlayerMovement>().GetMovement() * speed;
    }
}
