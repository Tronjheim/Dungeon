using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Enemy enemy;
    int damage = 20;
     void Start()
    {
        enemy=GetComponent<Enemy>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            TakeDamage();//hice este cambio
            Destroy(gameObject);
            if (enemy.currentHealth <= 0)
            {
                Destroy(col.gameObject);
                ScoreManager.Instance.score += 100;
                Debug.Log(ScoreManager.Instance.score);
            }
        }
    }
    public void TakeDamage()// Esta funcion tendria que estar en el script ball?
    {
        enemy.currentHealth -= damage;
        // healthBar.SetHealth(currentHealth);
    }
}