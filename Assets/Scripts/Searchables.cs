using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchables : MonoBehaviour
{
    public GameObject treasure;

    void Start()
    {
        
    }

    public void isSearched()
    {
        Destroy(gameObject);
        if(treasure.tag == "Ring" 
            && GameObject.FindGameObjectWithTag("Player").GetComponent<RingHolder>().ContainsRing(treasure.GetComponent<Ring>().GetRingType()))
        {
            Instantiate(treasure, transform.position, transform.rotation);
        }

    }



}
