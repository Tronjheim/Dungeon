using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public void TakeDamage2()
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            Destroy(gameObject);
            ScoreManager.Instance.score += 100;
        }
    }
}