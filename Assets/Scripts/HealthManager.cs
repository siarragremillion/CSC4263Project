using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image[] Hearts;
    public int numHearts;

    public Sprite fullHeart;
    public Sprite unfilledHeart;

    public Rocky rocky;

    public bool cached;

    // Start is called before the first frame update
    void Start()
    {   
        currentHealth = 3;
        numHearts = 3;
        cached = false;

        rocky = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cached)
        {


            if (currentHealth <= 0)
            {
                rocky.alive = false;
                StartCoroutine(UIManager.GameOver());
            }

            rocky.Health = currentHealth;

            if (currentHealth > numHearts)
            {
                currentHealth = numHearts;
            }

            for (int i = 0; i < Hearts.Length; i++)
            {
                if (i < currentHealth)
                {
                    Hearts[i].sprite = fullHeart;
                }
                else
                {
                    Hearts[i].sprite = unfilledHeart;
                }

                if (i < numHearts)
                {
                    Hearts[i].enabled = true;
                }
                else
                {
                    Hearts[i].enabled = false;
                }
            }
            rocky.Health = currentHealth;
            cached = true;
        }
    }

    public void HurtPlayer(int damage){
        currentHealth -= damage;
        cached = false;
    }

    public void HealPlayer(int health)
    {
        currentHealth += health;
        cached = false;
    }
}
