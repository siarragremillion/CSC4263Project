using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    [SerializeField] Vector2 movement;
    GameObject rocky;

    void Start()
    {
        rocky = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(rocky.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = rocky.GetComponent<PlayerMovement>().GetMovement().x;
        movement.y = rocky.GetComponent<PlayerMovement>().GetMovement().y;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
