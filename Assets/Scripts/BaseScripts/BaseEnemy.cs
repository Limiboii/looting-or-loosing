using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BaseEnemy : MonoBehaviour, IAlive
{
    //private int lookingAt = 0;
    [Header("Common Variables")]
    public int hp;
    public float speed;
    public Transform target;
    protected Vector3 targetPos;
    private Rigidbody2D rb;
    protected bool canAttack;
    public int dmg;

    [Space]
    [Header("Timer")]
    protected float timer;
    public float cooldown;

    [Space]
    [Header("Drops")]
    public GameObject gunPickUp;
    public GameObject coins;

    SpriteRenderer sr;

    protected bool moveable = true;
    public bool CanMove => moveable;

    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        GameObject.FindWithTag("Player").GetComponent<Player>().ShotgunGun += FindNewTarget;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    void FindNewTarget()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        FindPath();
        Move();
        Attack();
        if (timer >= cooldown)
            timer += Time.deltaTime;

    }

    protected void FixedUpdate()
    {
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime / 0.2f);
    }

    public void FindPath()
    {
        targetPos = new Vector2(target.position.x, target.position.y);
        transform.LookAt(targetPos);
        transform.Rotate(Vector3.up * 90);
    }

    public virtual void Move()
    {
        Vector2 movement = new Vector2(target.position.x - gameObject.transform.position.x, target.position.y - gameObject.transform.position.y);
        if (CanMove)
            rb.velocity = movement * speed * Time.deltaTime;
        else if (!CanMove)
            rb.velocity = movement * 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack && collision.gameObject.tag == "Player")
        {
            canAttack = false;
            collision.gameObject.GetComponent<IAlive>().TakeDmg(dmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Melee")
        {
            TakeDmg(5);
        }
    }

    protected virtual void Attack()
    {
        if (timer >= cooldown)
        {
            canAttack = true;
            timer = 0;
        }
        timer += Time.deltaTime;
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
        int u = Random.Range(0, 100);
        int coinAmount = Random.Range(1, 11);
        if (u > 75)
        {
            Instantiate(gunPickUp, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        }
        Instantiate(coins, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Destroy(gameObject);
    }
}
