using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocky : MonoBehaviour
{
    public int Health;

    public int MaxHealth;

    public int Crystals;

    public int MaxCrystals;

    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 3;
        Crystals = 0;
        Health = MaxHealth;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            alive = false;
            UIManager.GameOver();
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
