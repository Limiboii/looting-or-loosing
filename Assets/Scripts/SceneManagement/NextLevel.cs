using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelToLoad;

    //en funktion som konstant känner av om någonting colliderar med objektet den sitter på
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om det är ett objekt med taggen "Player" colliderar med objektet så körs det som står nedan
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);

        }
    }

}
