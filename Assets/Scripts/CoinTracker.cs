using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTracker : MonoBehaviour
{
    //inte jag
    public TextMeshProUGUI scoreText;

    public int totalScore;

    private void Update()
    {
        //detta gör så att den uppdaterar scoretexten hela tiden så att den skriver ut det rätta värdet av variabeln "totalScore"
        if (scoreText != null)
            scoreText.text = string.Format("Coins: {0}", totalScore);
    }
}
