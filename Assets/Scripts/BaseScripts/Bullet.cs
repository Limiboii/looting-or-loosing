using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public float speed;
    public int dmg;

    private void Update()
    {
        transform.Translate((Vector2.right * speed), Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != gameObject.tag)
        {
            IAlive hit = collision.GetComponent<IAlive>();
            if (hit != null)
                hit.TakeDmg(dmg);
            Destroy(gameObject);
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}