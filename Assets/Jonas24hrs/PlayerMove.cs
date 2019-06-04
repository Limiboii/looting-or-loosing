using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    //Orginal movement ej gjort av mig. Flyttade in detta i Player scriptet för att kunna använda Interfacet IAlive.
    Rigidbody2D rb;
    private float timer;
    public float cooldown;
    public float boost = 1.5f;
    public Slider timerBar;
    float horizontal;
    float vertical;
    readonly float moveLimiter = 0.7f;
    public bool runBoost = false;
   // public Animator anim;

    public float runSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        timerBar.value = timer;
        timer += Time.deltaTime;

        //anim.SetFloat("MoveHoriz", Mathf.Abs(horizontal));
        //anim.SetFloat("MoveVert", Mathf.Abs(vertical));


    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {

            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            SpeedBoost();
            runBoost = true;
        }
    }

    void SpeedBoost()
    {

        if (timer >= cooldown && !runBoost)
        {
            runSpeed *= boost;
            Invoke("SpeedReset", 5f);
            timer = 0;
        }

    }

    void SpeedReset()
    {
        runSpeed /= boost;
        runBoost = false;
    }

    //IEnumerator tid()
    //{
    //    //starta
    //    yield return new WaitForSeconds(5);
    //    //stoppa
    //}
}
