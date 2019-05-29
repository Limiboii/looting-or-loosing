using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAlive
{
    bool CanMove { get; }
    void Move();
    void TakeDmg(int dmg);
    void Die();
}