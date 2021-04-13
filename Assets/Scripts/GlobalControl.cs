using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int Health;

    public int MaxHealth;

    public int crystals;

    public int maxCrystals;

    public int currentWeapon;

    public bool alive;

    public bool hasDrink;
    public bool hasFood;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
