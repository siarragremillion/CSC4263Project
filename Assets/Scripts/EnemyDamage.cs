using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float power = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player"){
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(power);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
