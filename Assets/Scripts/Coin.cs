using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    //RequireComponent och nullCheck
    public int score = 1;
    public GameObject effect;
    public GameObject sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject controller = GameObject.FindWithTag("GameController");
            if (controller != null)
            {
                if (sound != null)
                    Instantiate(sound, gameObject.transform.position, Quaternion.identity);
                CoinTracker tracker = controller.GetComponent<CoinTracker>();

                Destroy(gameObject);
                if (effect != null)
                    Instantiate(effect, transform.position, Quaternion.identity);

                if (tracker != null)
                {
                    tracker.totalScore += score;
                }
                else
                {
                    Debug.LogError("ScoreTracker saknas på GameController");
                }
            }
            else
            {
                Debug.LogError("GameController finns inte");
            }
        }
    }
}
