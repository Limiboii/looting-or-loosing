using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseEnemy
{
    //All här.
    public GameObject projectile;
    public GameObject firePoint;
    
    public override void Move()
    {
        //Kollar distance mellan target och sig själv. Stannar när den är en viss distans ifrån och börjar gå igen när den kommit längre bort.
        //Kan ej skjuta ifall den kan röra på sig. Kommer den för långt bort slutar den röra på sig.
        float dst = Vector3.Distance(targetPos, transform.position);
        if (dst <= 6)
        {
            moveable = false;
            canAttack = true;
        }
        else if (dst > 15)
        {
            moveable = false;
            canAttack = false;
        }
        else if (dst > 9)
            moveable = true;
        base.Move();
    }

    protected override void Attack()
    {
        if (!moveable && canAttack)
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
