using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;

    Rocky rocky;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");

        //hidePaused();

        if (Application.loadedLevelName == "TitleScene")
        {
            //rocky = GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>();
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
        //SceneManager.LoadScene(level);
        Application.LoadLevel(level);
    }

    //Reloads the Level
    public void Reload()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene());
        Application.LoadLevel(Application.loadedLevel);
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
        Application.LoadLevel("GameOverScene");
    }
}
