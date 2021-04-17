using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleteUI : MonoBehaviour
{

    [SerializeField] GameObject gameCompleteSelector;
    [SerializeField] public List<Text> gameCompleteItems;

    private int selector;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectHandler(gameCompleteItems);
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
                UIManager.LoadLevel("Level0");
                break;
            case "Quit":
                UIManager.Quit();
                break;
            default:
                Debug.LogError("Selection Invalid: GameComplete");
                break;
        }
        selector = 0;
    }
}