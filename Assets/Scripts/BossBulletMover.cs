using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMover : MonoBehaviour
{
    public float speed = 5f;
    public int power = 1;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = rb.transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(power);
            Destroy(gameObject);
        }        
    }
}
