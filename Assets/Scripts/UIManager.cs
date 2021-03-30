using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverSelector;
    [SerializeField] public List<Text> gameOverItems;

    [SerializeField] GameObject completeSelector;
    [SerializeField] public List<Text> completeItems;

    [SerializeField] GameObject pauseSelector;
    [SerializeField] public List<Text> pauseItems;

    [SerializeField] GameObject titleSelector;
    [SerializeField] public List<Text> titleItems;

    [SerializeField] GameObject aboutSelector;
    [SerializeField] public List<Text> aboutItems;
    [SerializeField] public bool aboutFlag;

    [SerializeField] GameObject journalSelector;
    [SerializeField] public List<Text> journalItems;
    [SerializeField] public bool journalFlag;

    private int selector;
    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;

    [SerializeField] private Text previousText;

    [SerializeField] private bool InUI;

    Rocky rocky;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        InUI = false;

        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                hideAbout();
                break;
            case "GameOver":
                break;
            default:
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
                InUI = true;
                showPaused();
            }
            else if (Time.timeScale == 0 && rocky.alive == true)
            {
                Time.timeScale = 1;
                InUI = false;
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
            case "GameOver":
                break;
            default:
                if (journalFlag)
                {
                    SelectHandler(journalItems);
                }
                else
                {
                    SelectHandler(pauseItems);
                }
                break;
        }
    }

    // shows journal objects
    public void showJournal()
    {
        journalSelector.SetActive(true);
        journalFlag = true;
    }

    public void hideJournal()
    {
        journalSelector.SetActive(false);
        journalFlag = false;
    }

    public void journalControl()
    {
        if (!journalFlag)
        {
            journalFlag = true;
            showJournal();
            hidePaused();
            
        }
        else
        {
            journalFlag = false;
            hideJournal();
            showPaused();
        }
    }

    //shows level complete objects
    public void showComplete()
    {
        Time.timeScale = 0;
        completeSelector.SetActive(true);
    }

    //hides level complete objects
    public void hideComplete()
    {
        Time.timeScale = 1;
        completeSelector.SetActive(false);
    }

    //shows pause objects
    public void showPaused()
    {
        pauseSelector.SetActive(true);
    }

    //hides pause objects
    public void hidePaused()
    {
        pauseSelector.SetActive(false);
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
        if (InUI)
        {
            Debug.Log(selector);
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
            case "Resume":
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
