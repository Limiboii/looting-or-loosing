using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUpGun : MonoBehaviour
{
    public bool shotgun;

    private void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().FindEvent(this);
    }

    public event Action PickUpShotgun;
    public event Action PickUpAr;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (shotgun)
                PickUpShotgun?.Invoke();
            else if (!shotgun)
                PickUpAr?.Invoke();
            Destroy(gameObject);
        }
    }
}
