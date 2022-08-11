using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int healt = 50;
    int currentHealt;
    void Start()
    {
        currentHealt = healt;
    }

    public void Damage(int damage)
    {
        currentHealt -= damage;
        if(currentHealt <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("Death", true);
        Destroy(this);
    }
}
