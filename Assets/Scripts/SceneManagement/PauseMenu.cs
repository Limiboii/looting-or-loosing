using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject[] pauseObjects;

    // Use this for initialization
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
        GameObject Player = GameObject.Find("PauseMenuInGame");
        Time.timeScale = 1;
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }

        if (Time.timeScale == 1)
        {
            HidePaused();
        }
    }



    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

  
    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

   
    public void LoadMainMenu(string level)
    {
        HidePaused();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        HidePaused();
        Application.Quit();
        print("quit");
    }
}

