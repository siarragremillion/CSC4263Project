using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponMover : MonoBehaviour
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
        transform.position = rocky.transform.Find("ShootPoint").gameObject.transform.position;
    }
}
