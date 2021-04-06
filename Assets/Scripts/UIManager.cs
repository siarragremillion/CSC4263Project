using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject completeSelector;
    [SerializeField] public List<Text> completeItems;

    [SerializeField] GameObject pauseSelector;
    [SerializeField] public List<Text> pauseItems;

    [SerializeField] GameObject journalSelector;
    [SerializeField] public List<Text> journalItems;
    [SerializeField] GameObject journalEntry;
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
        InUI = true;



        InUI = false;
        hidePaused();
        hideComplete();
        hideJournal();




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
            if (journalFlag)
            {
                journalControl();
            }
            else
            {
                pauseControl();
            }
        }

        if (InUI)
        {
            if (journalFlag)
            {
                SelectHandler(journalItems);
            }
            else
            {
                SelectHandler(pauseItems);
            }

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
            InUI = true;
            journalEntry.SetActive(false);
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
            InUI = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
            InUI = false;
        }
    }

    public void SelectHandler(List<Text> selectorTexts)
    {
        if (InUI)
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
            case "Quit":
                Quit();
                break;
            case "Continue":
                LoadLevel("Level1");
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
                if (journalFlag)
                {

                    journalEntry.SetActive(true);
                }
                break;
        }

        previousText = selectedText;
        selector = 0;
    }

    //loads inputted level
    public static void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    //Reloads the Level
    public static void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Closes Game
    public static void Quit()
    {
        Application.Quit();
    }

    // Loads Game Over Screen
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
