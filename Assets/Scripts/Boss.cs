using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public void TakeDamage2()
    {
        currentHealth -= damage;
    }
}