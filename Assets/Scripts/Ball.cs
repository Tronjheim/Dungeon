using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public HealthBar healthBar;
    int damage = 5;
    private void Start()
    {
        Enemy.currentHealth = Enemy.maxHealth;
        healthBar.SetMaxHealth(Enemy.maxHealth);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            TakeDamage();
            Destroy(gameObject);
            if (Enemy.maxHealth <= 0)
            {
                Destroy(col.gameObject);
                ScoreManager.Instance.score += 100;
                Debug.Log(ScoreManager.Instance.score);
            }
            
        }
    }
    void TakeDamage()
    {
        Enemy.maxHealth -= damage;
        healthBar.SetHealth(Enemy.currentHealth);
    }
}