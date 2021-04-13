using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject gameOverSelector;
    [SerializeField] public List<Text> gameOverItems;

    private int selector;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;

    private void Update()
    {
        SelectHandler(gameOverItems);
    }

    public void Quit()
    {
        Application.Quit();
    }
    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void SelectHandler(List<Text> selectorTexts)
    {
        if (Input.GetKeyDown(KeyCode.S) && selector + 1 < selectorTexts.Count)
        {
            selector++;
        }
        else if (Input.GetKeyDown(KeyCode.W) && selector > 0)
        {
            selector--;
        }

        UpdateItemSelection(selector, selectorTexts);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ItemSelected(selectorTexts[selector]);
        }
    }

    public void UpdateItemSelection(int selectedItem, List<Text> selectorTexts)
    {
        for (int i = 0; i < selectorTexts.Count; i++)
        {
            if (i == selectedItem)
            {

                selectorTexts[i].color = highlightedColor;
            }
            else
            {
                selectorTexts[i].color = defaultColor;
            }
        }
    }

    public void ItemSelected(Text selectedText)
    {
        string choice = selectedText.text;
        Debug.Log(choice);
        switch (choice)
        {

            case "Continue":
                LoadLevel("Level0");
                break;
            case "Quit":
                Quit();
                break;
            default:
                Debug.LogError("Selection Invalid: GameOver");
                break;
        }
        selector = 0;
    }
}