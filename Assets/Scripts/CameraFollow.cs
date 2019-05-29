using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothX, smoothY;
    private Vector2 velocity;

    //public Vector2 minpos, maxpos;
    //public bool bound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothY);
        transform.position = new Vector3(posX, posY, transform.position.z);

        //if (bound)
        //{
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x), Mathf.Clamp(transform.position.y, minpos.y, maxpos.y), Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        //}
    }
}