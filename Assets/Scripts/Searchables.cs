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
        Instantiate(treasure, transform.position, transform.rotation);

    }



}
