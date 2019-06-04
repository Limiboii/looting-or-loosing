using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IAlive
{
    //En bool som skulle förhindra movement för spelaren ifall t.ex någonting slowar/stunnar. Ifall den inte är true kan inte spelaren röra på sig.
    private bool moveable = true;
    public bool CanMove => moveable;

    Rigidbody2D rb;

    [Header("Sprint")]
    public bool runBoost = false;
    public float cooldown;
    public float runSpeed;
    public float sprintLength;
    public Slider timerBar;
    public float boost = 1.5f;
    public Animator anim;

    public GameObject ArPrefab;
    public GameObject shotgunPrefab;

    private float timer;
    private float vertical;
    private float horizontal;
    readonly float moveLimiter = 0.7f;

    public int hp;

    SpriteRenderer sr;

    void Start()
    {
        moveable = true;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        timer = cooldown;

        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Animationer har jag inte gjort men jag vet hur man gör dom iaf
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveHoriz", horizontal);
        anim.SetFloat("MoveVert", vertical);

        Move();

        if (Input.GetButtonDown("Sprint"))
        {
            SpeedBoost();
        }

        if (Input.GetButtonDown("Fire1"))
            Attack();
    }

    protected void FixedUpdate()
    {
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime / 0.2f);
    }

    public void Move()
    {
        if (CanMove)
        {
            if (timerBar != null)
                timerBar.value = timer;
            timer += Time.deltaTime;

            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

    }

    //Jag fixade till så att dashen fungerade men jag gjorde den inte från start.
    void SpeedBoost()
    {
        if (timer >= cooldown && !runBoost)
        {
            runBoost = true;
            runSpeed *= boost;
            Invoke("SpeedReset", sprintLength);
            timer = 0;
        }

    }

    void SpeedReset()
    {
        runSpeed /= boost;
        runBoost = false;
    }

    //Detta fungerar ifall man inte har några andra "Children". Härifrån och ner har jag gjort allt.
    void Attack()
    {
        GetComponentInChildren<Gun>().Shoot();
    }

    public void TakeDmg(int dmg)
    {
        sr.color = new Color(2, 0, 0);

        hp -= dmg;
        if (hp <= 0)
            Die();

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void FindEvent(PickUpGun gun)
    {
        gun.PickUpAr += ChangeToAr;
        gun.PickUpShotgun += ChangeToShotgun;
    }

    private void ChangeToAr()
    {
        if (ArPrefab != null)
        {
            Instantiate(ArPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    public event Action ShotgunGun;

    private void ChangeToShotgun()
    {
        Instantiate(shotgunPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        ShotgunGun?.Invoke();
    }
}
