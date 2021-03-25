using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public GameObject loot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtEnemy(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);
            // Instantiate(loot, transform.position, transform.rotation);
            Instantiate(loot, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation); // not sure why the z doesn't get properly set
        }
    }
}
