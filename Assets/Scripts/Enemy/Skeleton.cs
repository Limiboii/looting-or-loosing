using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseEnemy
{
    public GameObject projectile;
    public GameObject firePoint;

    public override void Move()
    {
        float dst = Vector3.Distance(targetPos, transform.position);
        if (dst <= 6)
            moveable = false;
        else if (dst > 9)
            moveable = true;
        base.Move();
    }

    protected override void Attack()
    {
        if (!moveable)
        {
            if (timer >= cooldown)
            {
                Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }
}
