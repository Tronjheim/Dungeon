using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 5f;
    public Animator anim;
    float rotateSpeed = 200f;

    //attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    float attackRate = 1.5f;
    float nextAttack = 0f;
    void Start()
    {
        
    }
    void Update()
    {
        nextAttack -= Time.deltaTime;
        if (nextAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttack = attackRate;
            }
        }
        Movement();      
    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 inputX = new Vector3(0, x, 0);
        transform.Rotate(inputX * rotateSpeed * Time.deltaTime);
        float y = Input.GetAxis("Vertical");
        Vector3 inputY = new Vector3(0, 0, y);
        transform.Translate(inputY * speed * Time.deltaTime);
        if ((inputX != Vector3.zero) || inputY != Vector3.zero)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

    }
    void Attack()
    {
        //play the animation
        anim.SetTrigger("Attack");
        //detect enemies in range attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position,attackRange,enemyLayers);
        //Damage
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Damage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
