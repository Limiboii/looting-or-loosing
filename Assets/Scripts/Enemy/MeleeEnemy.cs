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
    {
        float dst = Vector3.Distance(targetPos, transform.position);
        if (dst <= 8)
            moveable = true;
        else if (dst > 12)
            moveable = false;
        base.Move();
    }
}