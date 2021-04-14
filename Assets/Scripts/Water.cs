using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private GameObject rocky;


    // Start is called before the first frame update
    void Start()
    {
        rocky = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(rocky.GetComponent<RingHolder>().GetActiveRing() == Ring.RingType.BlueSilver)
        {
            Physics2D.IgnoreCollision(rocky.GetComponent<Collider2D>(), GetComponent<Collider2D>(),true);
        }
        else{
            Physics2D.IgnoreCollision(rocky.GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);
        }
    }
}
