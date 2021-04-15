using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockX : MonoBehaviour
{
    private Vector2 startPos;

    private Vector2 endPos;

    private Rigidbody2D rb;

    private bool isSwitched;

    private bool initialMov;

    public float moveLength;


    void Start()
    {
        startPos = transform.position;

        endPos = new Vector2(startPos.x+3, startPos.y);

        rb = GetComponent<Rigidbody2D>();

        moveLength = 50f;

        isSwitched = false;
    }


    void Update()
    {
        // if(!isSwitched)
        // {
        //     if(transform.position.x >= startPos.x + moveLength){
        //         rb.isKinematic = true;
        //         transform.position = new Vector2(startPos.x + moveLength, transform.position.y);
        //         isSwitched = true;
        //     }
        //     else if(transform.position.x <= startPos.x - moveLength){
        //         rb.isKinematic = true;
        //         transform.position = new Vector2(startPos.x - moveLength, transform.position.y);
        //         isSwitched = true;
        //     }
        //     else if (transform.position.y >= startPos.y + moveLength)
        //     {
        //         rb.isKinematic = true;
        //         transform.position = new Vector2(transform.position.x, startPos.y + moveLength);
        //         isSwitched = true;
        //     }
        //     else if (transform.position.y <= startPos.y - moveLength)
        //     {
        //         rb.isKinematic = true;
        //         transform.position = new Vector2(transform.position.x, startPos.y - moveLength);
        //         isSwitched = true;
        //     }
        // }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if(other.gameObject.tag == "Player"){
        //     if(!isSwitched)
        //     {
        //         transform.position = new Vector2(transform.position.x + moveLength * Time.deltaTime, transform.position.y);
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        //         isSwitched = true;
        //     }
        // }





        // Debug.Log(coll.gameObject);
        
        // Rigidbody2D body = coll.gameObject.GetComponent<Rigidbody2D>();
 
        // if (!initialMov)
        // {
        //     if (body.velocity.x < 0)      
        //     { 
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        //     }
        //     else if (body.velocity.x > 0) 
        //     { 
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        //     }
        //     else if (body.velocity.y > 0) 
        //     { 
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 
        //     }
        //     else if (body.velocity.y < 0) 
        //     { 
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 
        //     }
 
        //     initialMov = true; 
        // }
    }
}
