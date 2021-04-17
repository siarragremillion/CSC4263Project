using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockYMovement : MonoBehaviour
{
    private Vector2 startPos;

    private Vector2 endPos;

    private Rigidbody2D rb;
    

    private bool isSwitched;

    private bool startMove = false;

    public float moveLength;

    public bool moveUpFirst;

    private GameObject rocky;


    void Start()
    {
        startPos = transform.position;

        if(moveUpFirst)
        {
            endPos = new Vector2(startPos.x, startPos.y + moveLength);
        }
        else
        {
            endPos = new Vector2(startPos.x, startPos.y - moveLength);
        }

        rb = GetComponent<Rigidbody2D>();

        isSwitched = false;

        rocky = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if(startMove && !isSwitched)
        {
            if(Mathf.Abs(transform.position.y - endPos.y) <= 0.15)
            {
                startMove=false;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }
            else{
                if(moveUpFirst){
                    rb.velocity = transform.up * 1.0f;
                }
                else{
                    rb.velocity = -transform.up * 1.0f;
                }
            }
        }
        else if(startMove && isSwitched)
        {
            if(Mathf.Abs(transform.position.y - startPos.y) <= 0.15)
            {
                startMove=false;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }
            else{
                if(moveUpFirst){
                    rb.velocity = -transform.up * 1.0f;
                }
                else{
                    rb.velocity = transform.up * 1.0f;
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
            if(moveUpFirst)
            {
                if(rocky.transform.position.y > transform.position.y){
                    startMove = true;
                    rb.isKinematic = false;
                    isSwitched = true;
                }
                else if(rocky.transform.position.y < transform.position.y){
                    startMove = true; 
                    rb.isKinematic = false;
                    isSwitched = false;
                }
            }  
            else{
                if(rocky.transform.position.y < transform.position.y){
                    startMove = true;
                    rb.isKinematic = false;
                    isSwitched = true;
                }
                else if(rocky.transform.position.y > transform.position.y){
                    startMove = true; 
                    rb.isKinematic = false;
                    isSwitched = false;
                }
            }
            }
        }
    }
}
