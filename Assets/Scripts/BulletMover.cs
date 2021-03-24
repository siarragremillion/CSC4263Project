using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // private Vector2 lastPos;
    //public GameObject Rocky; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rocky rocky = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>();
        rb.velocity = rocky.GetComponent<PlayerMovement>().GetMovement() * speed;
    }
}
