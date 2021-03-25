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

    Rocky rocky;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        completeObjects = GameObject.FindGameObjectsWithTag("ShowOnLevelComplete");
        journalObjects = GameObject.FindGameObjectsWithTag("ShowOnJournalOpen");
        hidePaused();
        hideComplete();
        hideJournal();

        if (SceneManager.GetActiveScene().name != "TitleScene")
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

        /*if (rocky.alive == false)
        {
            LoadLevel("GameOverScene");
        }*/
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

    public void AddRupeeAndDisplayIt()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
