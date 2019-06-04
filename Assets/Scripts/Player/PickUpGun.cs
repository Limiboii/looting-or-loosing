using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUpGun : MonoBehaviour
{
    //Allt i detta script har jag gjort
    public bool shotgun;

    private void Start()
    {
        //När vapnet spawnas vill jag att player ska kunna hitta eventet som har med just detta object att göra. 
        GameObject.FindWithTag("Player").GetComponent<Player>().FindEvent(this);
    }

    public event Action PickUpShotgun;
    public event Action PickUpAr;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //När jag tar upp objectet så kommer jag byta till rätt vapen. Antingen shotgun eller ar. Dock finns inte Ar.
            if (shotgun)
                PickUpShotgun?.Invoke();
            else if (!shotgun)
                PickUpAr?.Invoke();
            Destroy(gameObject);
        }
    }
}
