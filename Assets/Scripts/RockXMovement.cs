using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockXMovement : MonoBehaviour
{
    private Vector2 startPos;

    private Vector2 endPos;

    private Rigidbody2D rb;
    

    private bool isSwitched;

    private bool startMove = false;

    public float moveLength;

    public bool moveRightFirst;

    private GameObject rocky;


    void Start()
    {
        startPos = transform.position;

        if(moveRightFirst)
        {
            endPos = new Vector2(startPos.x+moveLength, startPos.y);
        }
        else
        {
            endPos = new Vector2(startPos.x-moveLength, startPos.y);
        }


        rb = GetComponent<Rigidbody2D>();

        isSwitched = false;

        rocky = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if(startMove && !isSwitched)
        {
            if(Mathf.Abs(transform.position.x - endPos.x) <= 0.15)
            {
                startMove=false;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }
            else{
                if(moveRightFirst){
                    rb.velocity = transform.right * 1.0f;
                }
                else{
                    rb.velocity = -transform.right * 1.0f;
                }
            }
        }
        else if(startMove && isSwitched)
        {
            if(Mathf.Abs(transform.position.x - startPos.x) <= 0.15)
            {
                startMove=false;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }
            else{
                if(moveRightFirst){
                    rb.velocity = -transform.right * 1.0f;
                }
                else{
                    rb.velocity = transform.right * 1.0f;
                }
            }
        }
        else{
            rb.isKinematic = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(rocky.GetComponent<RingHolder>().GetActiveRing() == Ring.RingType.GreenSilver)
            { 
            if(moveRightFirst)
            {
                if(rocky.transform.position.x > transform.position.x){
                    startMove = true;
                    rb.isKinematic = false;
                    isSwitched = true;
                }
                else if(rocky.transform.position.x < transform.position.x){
                    startMove = true; 
                    rb.isKinematic = false;
                    isSwitched = false;
                }
            }  
            else{
                if(rocky.transform.position.x < transform.position.x){
                    startMove = true;
                    rb.isKinematic = false;
                    isSwitched = true;
                }
                else if(rocky.transform.position.x > transform.position.x){
                    startMove = true; 
                    rb.isKinematic = false;
                    isSwitched = false;
                }
            }
            }
        }
    }
}
