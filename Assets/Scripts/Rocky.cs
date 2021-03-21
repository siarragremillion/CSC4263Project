using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocky : MonoBehaviour
{
    public int Health { get; set; }

    public int MaxHealth { get; set; }

    public int Crystals { get; set; }

    public int MaxCrystals { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 3;
        Crystals = 0;
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            // DEAD
            // Implement Game Over
        }
    }

    public void PickUpHeart()
    {
        if (Health < MaxHealth)
        {
            Health++;
        }
    }

    public void EatFood(int HealthAmount)
    {
        Health += HealthAmount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void PickUpCrystal()
    {
        if (Crystals < MaxCrystals)
        {
            Crystals++;
        }
    }
}
