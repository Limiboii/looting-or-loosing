using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{

    public static DeathMenuScript instance;
    public int lvl;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("PauseMenuController"));
        }

        PlayerPrefs.SetInt("lvl", SceneManager.GetActiveScene().buildIndex);
        lvl = SceneManager.GetActiveScene().buildIndex;

    }
}
