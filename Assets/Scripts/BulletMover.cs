using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 lastPos;
    //public GameObject Rocky; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Rocky rocky = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>();
        if(rocky.gameObject.transform.position.x > lastPos.x){
            rb.velocity = rocky.gameObject.transform.right*speed;
        }
        else if(rocky.gameObject.transform.position.x < lastPos.x){
            rb.velocity = -rocky.gameObject.transform.right*speed;
        }
        else if(rocky.gameObject.transform.position.y > lastPos.y){
            rb.velocity = rocky.gameObject.transform.up*speed;
        }
        else if(rocky.gameObject.transform.position.y < lastPos.y){
            rb.velocity = -rocky.gameObject.transform.up*speed;
        }
        //rb.velocity = -transform.right * speed ;
        lastPos = rocky.gameObject.transform.position;
        
    }
}
