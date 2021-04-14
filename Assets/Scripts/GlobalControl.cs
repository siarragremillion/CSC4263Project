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

    public int swordPower;
    public int gunPower;
    public bool waterRingisActive;

    public bool hasDrink;
    public bool hasFood;

    public bool canPause;

    private void Start()
    {
        swordPower = 3;
        gunPower = 2;
        waterRingisActive = false;
        MaxHealth = 3;
        crystals = 10;
        Health = MaxHealth;
        currentWeapon = 0;
        hasDrink = false;
        hasFood = false;
        canPause = true;
        alive = true;
    }
    
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
