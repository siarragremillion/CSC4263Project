using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int power = 1;
    public int damageRate = 10;
	[SerializeField] protected float hitCooldown = 2f;
    protected float currHitCoolDown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player"){
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(power);
        }
        else if(other.collider.tag == "Sword"){
            Debug.Log("stab");
            gameObject.GetComponent<EnemyHealth>().HurtEnemy(other.gameObject.GetComponent<MeleeWeaponMover>().power);
            
            // Vector2 moveDirection = transform.position - other.transform.position;
            // GetComponent<Rigidbody2D>().AddForce(moveDirection.normalized * -500f);
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if(other.collider.tag == "Player"){

            if(currHitCoolDown < 0){
				currHitCoolDown = hitCooldown;
                other.gameObject.GetComponent<HealthManager>().HurtPlayer(power);
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<EnemyHealth>().HurtEnemy(other.GetComponent<BulletMover>().power);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currHitCoolDown -= Time.deltaTime;
    }

}
