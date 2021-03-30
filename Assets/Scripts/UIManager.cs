using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] completeObjects;
    GameObject[] journalObjects;
    GameObject[] aboutObjects;
    GameObject[] titleButtonsObjects;

    [SerializeField] GameObject titleSelector;
    [SerializeField] public List<Text> titleItems;

    [SerializeField] GameObject aboutSelector;
    [SerializeField] public List<Text> aboutItems;
    [SerializeField] public bool aboutFlag;

    private int selector;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;

    [SerializeField] private Text previousText;

    Rocky rocky;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                hideAbout();
                break;
            case "Level1":
                hidePaused();
                hideJournal();
                hideComplete();
                break;
            case "GameOver":
                break;
            default:
                hideAbout();
                hidePaused();
                hideComplete();
                hideJournal();
                break;
        }



        if (SceneManager.GetActiveScene().name.Equals("Level1"))
        {

            rocky = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1 && rocky.alive == true)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0 && rocky.alive == true)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                if (aboutFlag)
                {
                    SelectHandler(aboutItems);
                }
                else
                {
                    SelectHandler(titleItems);
                }
                
                break;
            case "Level1":
                hidePaused();
                hideComplete();
                break;
            case "GameOver":
                break;
            default:
                hideAbout();
                hidePaused();
                hideComplete();
                hideJournal();
                break;
        }
    }

    public void showJournal()
    {
        /*var button = new GameObject();
        button.transform.SetParent(GameObject.FindGameObjectWithTag("ShowOnJournalOpen").transform);
        button.transform.t*/
        foreach (GameObject g in journalObjects)
        {
            g.SetActive(true);
        }

    }

    public void hideJournal()
    {
        foreach (GameObject g in journalObjects)
        {
            g.SetActive(false);
        }
    }

    public void journalControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showJournal();
            hidePaused();
            
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hideJournal();
            showPaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showComplete()
    {
        Time.timeScale = 0;
        foreach (GameObject g in completeObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hideComplete()
    {
        foreach (GameObject g in completeObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showAbout()
    {
        aboutFlag = true;
        aboutSelector.SetActive(true);
        /*foreach (GameObject g in aboutObjects)
        {
            g.SetActive(true);
        }*/
    }

    //hides about objects
    public void hideAbout()
    {
        aboutFlag = false;
        aboutSelector.SetActive(false);
        /*foreach (GameObject g in aboutObjects)
        {
            g.SetActive(false);
        }*/
    }

    //shows title objects 
    public void showTitleButtons()
    {
        titleSelector.SetActive(true);
        /*foreach (GameObject g in titleButtonsObjects)
        {
            g.SetActive(true);
        }*/
    }

    //hides title objects
    public void hideTitleButtons()
    {
        titleSelector.SetActive(false);
        /*foreach (GameObject g in titleButtonsObjects)
        {
            g.SetActive(false);
        }*/
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

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        //Application.LoadLevel(level);
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
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
        
        switch (choice)
        {
            case "Start": 
                LoadLevel("Level1");
                break;
            case "Quit":
                Quit();
                break;
            case "About":
                aboutControl();
                break;
            case "Continue":
                pauseControl();
                break;
            case "Journal":
                journalControl();
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
