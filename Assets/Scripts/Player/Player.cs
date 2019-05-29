using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IAlive
{
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

    void Start()
    {
        moveable = true;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        timer = cooldown;
    }

    private void Update()
    {

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

    void Attack()
    {
        GetComponentInChildren<Gun>().Shoot();
        GameObject.FindWithTag("Weapon").GetComponent<Gun>().Shoot();
    }

    public void TakeDmg(int dmg)
    {
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
