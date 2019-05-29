using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateZucc : MonoBehaviour
{
    public GameObject realEnemy;
    private void Start()
    {
    }
    private void Update()
    {
        Vector3 pos = new Vector3(realEnemy.transform.position.x, realEnemy.transform.position.y, 0);
        gameObject.transform.position = pos;
    }
}
