using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int power = 1;
    public int damageRate = 10;
    private Vector3 prevPos;
    private Vector3 newPos;
    private Vector3 direction;
	[SerializeField] protected float hitCooldown = 2f;
    protected float currHitCoolDown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(power);
        }
        else if(other.collider.tag == "Sword"){
            gameObject.GetComponent<EnemyHealth>().HurtEnemy(GameObject.FindObjectOfType<Rocky>().swordPower);

            /* This bounces the enemy back by 1 in the y direction so it only works if rocky is attacking from above the enemy. 
             * If we can get his direction then we can do something similar to this to make him bounce back by one in the appropriate direction.
             */
            Vector3 temp = transform.position;
            temp.x = transform.position.x;
            temp.y = transform.position.y - 1f;
            transform.position = temp;
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if(other.collider.CompareTag("Player"))
        {
            if(currHitCoolDown < 0){
				currHitCoolDown = hitCooldown;
                other.gameObject.GetComponent<HealthManager>().HurtPlayer(power);
            }
        }        
    }
    private void BounceEnemy(Collider2D other)
    {
        /* This bounces the enemy back by 1 in the y direction so it only works if rocky is attacking from above the enemy. 
             * If we can get his direction then we can do something similar to this to make him bounce back by one in the appropriate direction.
             */
        Vector3 temp = transform.position;
        temp.x = transform.position.x;
        temp.y = transform.position.y - 1f;
        transform.position = temp;
       
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<EnemyHealth>().HurtEnemy(GameObject.FindObjectOfType<Rocky>().gunPower);
            //Vector2 moveDirection = transform.position - other.transform.position;
            //GetComponent<Rigidbody2D>().AddForce(moveDirection.normalized *-500f, ForceMode2D.Impulse);
            BounceEnemy(other);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currHitCoolDown -= Time.deltaTime;
    }

}
