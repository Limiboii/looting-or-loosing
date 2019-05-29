using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FindPath();
        Move();
    }

    private void FindPath()
    {
        Vector2 direction = (Vector2)player.position - rb.position;

        direction.Normalize();

        float roatateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -roatateAmount * rotateSpeed;


    }

    private void Move()
    {
        rb.velocity = transform.up * speed;
    }
}
