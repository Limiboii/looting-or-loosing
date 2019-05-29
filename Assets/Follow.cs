using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform path;

    private void Start()
    {
        //path = transform.GetComponentInChildren<Transform>();
        //if(path != null)
        //{
        //    print("heeej");
        //}
    }
    private void Update()
    {
        gameObject.transform.position = path.position;
        print(path.position);
    }

}
