using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    private float nextFire;
    public float fireRate;
    public Transform ShootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFire && GetComponent<EnemyAI>().FindTarget() != null){
            nextFire = Time.time + fireRate;
            Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0, 0, 90));
            Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0, 0, 180));
            Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0, 0, 270));
        }

        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>(),true);

    }
}
