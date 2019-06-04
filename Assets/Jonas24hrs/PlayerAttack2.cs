using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    //Har inte rört.
    public GameObject[] playerAttackObject;
    public GameObject attackRight, attackLeft, attackUp, attackDown;
    bool up, down, right, left;

    // Start is called before the first frame update
    void Start()
    {
        playerAttackObject = GameObject.FindGameObjectsWithTag("Weapon");
        HideSwordOnAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            up = false;
            left = false;
            right = false;
            down = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            up = true;
            left = false;
            right = false;
            down = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            up = false;
            left = false;
            right = true;
            down = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            up = false;
            left = true;
            right = false;
            down = false;
        }
        if (Input.GetKeyUp(KeyCode.L) && down)
        {
            ShowSwordOnAttackDown();
        }
        else if (Input.GetKeyUp(KeyCode.L) && up)
        {
            ShowSwordOnAttackUp();
        }
        else if (Input.GetKeyUp(KeyCode.L) && right)
        {
            ShowSwordOnAttackRight();
        }
        else if (Input.GetKeyUp(KeyCode.L) && left)
        {
            ShowSwordOnAttackLeft();
        }
        else
            HideSwordOnAttack();
    }

    public void ShowSwordOnAttackRight()
    {
        attackRight.SetActive(true);
    }

    public void ShowSwordOnAttackLeft()
    {
        attackLeft.SetActive(true);
    }

    public void ShowSwordOnAttackUp()
    {
        attackUp.SetActive(true);
    }

    public void ShowSwordOnAttackDown()
    {
        attackDown.SetActive(true);
    }

    public void HideSwordOnAttack()
    {
        foreach (GameObject g in playerAttackObject)
        {
            g.SetActive(false);
        }
    }
}
