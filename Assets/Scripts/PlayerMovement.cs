using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    private Rocky rocky;  
    [SerializeField] Vector2 prevMovement;

    [SerializeField] Vector2 movement;

    public Quaternion direction;

    void Start() {
        prevMovement = new Vector2(0, -1);
        rocky = GetComponent<Rocky>();
    }

    // Update is called once per frame
    void Update()
    {

        if(prevMovement.x > 0)
        {
            Quaternion quaternionRight = Quaternion.Euler(0, 0, 0);
            direction = quaternionRight;
            gameObject.transform.GetChild(0).transform.rotation = quaternionRight;
            gameObject.transform.GetChild(1).transform.rotation = quaternionRight;
            //shootpoint face right
        }
        else if(prevMovement.x < 0)
        {
           Quaternion quaternionLeft = Quaternion.Euler(0, 180, 0);
            direction = quaternionLeft;
            gameObject.transform.GetChild(0).transform.rotation = quaternionLeft;
            gameObject.transform.GetChild(1).transform.rotation = quaternionLeft;
        }
        //up
        if (prevMovement.y < 0)
        {
            direction = Quaternion.Euler(0, 0, 270);
        }
        //down
        else if(prevMovement.y > 0)
        {
            direction = Quaternion.Euler(0, 0, 90);
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.sqrMagnitude < 0.01){
            animator.SetFloat("Horizontal", prevMovement.x);
            animator.SetFloat("Vertical", prevMovement.y);
        }else{
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            prevMovement = movement;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public Vector2 GetMovement() {
        return movement; 
    }

    public Vector2 GetPrevMovement() {
        return prevMovement; 
    }

    public void FreezeMovement()
    {
        movement.x = 0;
        movement.y = 0;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        enabled = false;
    }

    public void UnfreezeMovement()
    {
        enabled = true;
    }

    // public Quaternion GetRockyDirection()
    // {
    //     Quaternion.Euler direction = Quaternion.Euler(0,0,0);
    //     //right
    //     if(prevMovement.x >= 0)
    //     {
    //         direction = Quaternion.Euler(0, 0, 0);
    //     }
    //     //left
    //     else if(prevMovement.x < 0)
    //     {
    //         direction = Quaternion.Euler(0, 180, 0);

    //     }
    //     //up
    //     else if (prevMovement.y >= 0)
    //     {
    //         direction = Quaternion.Euler(90, 0, 0);
    //     }
    //     //down
    //     else if(prevMovement.y < 0)
    //     {
    //         direction = Quaternion.Euler(-90, 0, 0);
    //     }
    //     return direction;
    // }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    [SerializeField] Vector2 movement;

    public enum CardinalDirections {NORTH,SOUTH,EAST,WEST};
	public CardinalDirections playerFacing;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        updatePlayerDir(movement);
        movement = movement.normalized;

        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void updatePlayerDir(Vector2 incomingMove)
	{
		//EAST WEST
		if (incomingMove.x > incomingMove.y)
		{
			//West
			if (incomingMove.x > 0)
				playerFacing = CardinalDirections.WEST;
			else
				playerFacing = CardinalDirections.EAST;
		}
		//North South
		else
		{
			//North
			if (incomingMove.y > 0)
				playerFacing = CardinalDirections.NORTH;
			else
				playerFacing = CardinalDirections.SOUTH;
		}
		//your animator will need a new int to store current direction
		//The nice thing about enums is they act as int so your animator will understand
		//Direction as 0 - North, 1- South, 2-East, 3- West
		animator.SetInteger("DirectionFacing", (int)playerFacing);
		//With this you could actually get rid of the hor and vert your transition cases will say something like
		//If speed > 0 and direction = 0 then animate walk facing north
		//When falling out the if speed < 0 should go back to an empty animator with the 4 directional idles in it
		//The empty idle animation should transition to one of the directional idles based of the direction float.
	}

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public Vector2 GetMovement() {
        return movement; 
    }

    public void FreezeMovement()
    {
        movement.x = 0;
        movement.y = 0;

        updatePlayerDir(movement);
        movement = movement.normalized;

        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        enabled = false;
    }

    public void UnfreezeMovement()
    {
        enabled = true;
    }
}
*/