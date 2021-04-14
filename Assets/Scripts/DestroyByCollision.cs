using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour
{

    void onCollisionEnter2D(Collider2D collider)
    {
        Debug.Log("test");
        if(collider.tag == "Bullet" || collider.tag == "BossBullet")
        {
            Destroy(collider.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Test 2");
        if(collider.tag == "Bullet" || collider.tag == "BossBullet")
        {
            Destroy(collider.gameObject);
        }
    }
}
