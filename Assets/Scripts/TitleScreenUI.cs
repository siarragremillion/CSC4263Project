using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] GameObject titleSelector;
    [SerializeField] public List<Text> titleItems;

    [SerializeField] GameObject aboutSelector;
    [SerializeField] public List<Text> aboutItems;
    [SerializeField] public bool aboutFlag;

    private int selector;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;
    [SerializeField] private Text previousText;

    // Start is called before the first frame update
    void Start()
    {
        aboutFlag = false;
        hideAbout();
    }

    // Update is called once per frame
    void Update()
    {
        if (aboutFlag)
        {
            SelectHandler(aboutItems);
        }
        else
        {
            SelectHandler(titleItems);
        }
    }

    public void showAbout()
    {
        aboutFlag = true;
        aboutSelector.SetActive(true);
    }

    //hides about objects
    public void hideAbout()
    {
        aboutFlag = false;
        aboutSelector.SetActive(false);
    }

    //shows title objects 
    public void showTitleButtons()
    {
        titleSelector.SetActive(true);
    }

    //hides title objects
    public void hideTitleButtons()
    {
        titleSelector.SetActive(false);
    }

    // Controls the about page on the title screen
    public void aboutControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showAbout();
            hideTitleButtons();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hideAbout();
            showTitleButtons();
        }
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

            case "Start":
                UIManager.LoadLevel("Level0");
                break;
            case "Quit":
                UIManager.Quit();
                break;
            case "About":
                aboutControl();
                break;
            case "<":
                ItemSelected(previousText);
                break;
            default:
                break;
        }

        previousText = selectedText;
        selector = 0;
    }
}
