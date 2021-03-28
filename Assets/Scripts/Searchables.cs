using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchables : MonoBehaviour
{
    public Ring treasure;

    void Start()
    {
        
    }

    public void isSearched()
    {
        gameObject.SetActive(false);
        Instantiate(treasure, transform.position, transform.rotation);

    }



}
