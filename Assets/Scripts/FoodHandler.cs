using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodHandler : MonoBehaviour
{

    public Image foodImage;
    public Image drinkImage;

    public Sprite unfilledDrink;
    public Sprite filledDrink;

    public Sprite unfilledFood;
    public Sprite filledFood;

    public Rocky rocky;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprites();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprites();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Should be eating " + rocky.hasDrink + " and " + rocky.hasFood);
            if (rocky.hasFood)
            {
                FindObjectOfType<HealthManager>().HealPlayer(1);
                rocky.hasFood = false;
            }
            else if (rocky.hasDrink)
            {
                FindObjectOfType<HealthManager>().HealPlayer(2);
                rocky.hasDrink = false;
            }
            
        }
    }

    public void UpdateSprites()
    {
        if (rocky.hasDrink)
        {
            drinkImage.sprite = filledDrink;
        }
        else
        {
            drinkImage.sprite = unfilledDrink;
        }

        if (rocky.hasFood)
        {
            foodImage.sprite = filledFood;
        }
        else
        {
            foodImage.sprite = unfilledFood;
        }
    }
}
