using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float timer;
    public int routine;
    public Quaternion angle;
    public float grade;
    public GameObject target;
    public bool attacking;
    public int maxHealth = 20;
    public int currentHealth;
    public int damage = 20;
    public HealthBar healthBar;// esta mal pero no lo saco para poder compilar
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);// este me decias que no iba aca sino solo en el script de ball?
    }
    private void Update()
    {
        EnemyRoutine();
    }

    public void EnemyRoutine()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 15)
        {
            timer += 1 - Time.deltaTime;
            if (timer >= 3)
            {
                routine = Random.Range(0, 30);
                timer = 0;
            }
            switch (routine)
            {
                case 0:
                    anim.SetBool("Run", false);
                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("Run", true);
                    break;
            }          
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position)>1 && !attacking)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                anim.SetBool("Run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                anim.SetBool("Attack", false);
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetBool("Attack", true);
                attacking = true;
            }
            
        }

    }
    public void FinalAnim()
    {
        anim.SetBool("Attack", false);
        attacking = false;
    }
    public void TakeDamage()// Esta funcion tendria que estar en el script ball?
    {
        maxHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
