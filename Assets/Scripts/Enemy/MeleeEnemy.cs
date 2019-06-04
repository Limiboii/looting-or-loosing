using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    protected override void Start()
    {
        base.Start();
        speed = (speed * 2);
    }

    public override void Move()
    { //Rör sig inte ifall den kommer för långt bort. Har en större area att följa efter dig på när den väl har börjat springa efter dig.
        float dst = Vector3.Distance(targetPos, transform.position);
        if (dst <= 8)
            moveable = true;
        else if (dst > 12)
            moveable = false;
        base.Move();
    }
}