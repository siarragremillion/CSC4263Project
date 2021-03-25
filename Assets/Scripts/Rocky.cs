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

    public List<JournalEntry> Journal;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 3;
        Crystals = 0;
        Health = MaxHealth;
        alive = true;
        Journal = new List<JournalEntry>() { new JournalEntry() { Title = "HELP!!!!", 
            Content = string.Format("Dear Rocky, /n/n I'm trapped at the bottom of this cave. I was searching for the secrets hidden within. Please come find me! You can switch weapons by pressing the E key."),
            Author = "Crystal \"Chris\" Chrisington ",
            Date = "01/11/19XX"
        } };
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
