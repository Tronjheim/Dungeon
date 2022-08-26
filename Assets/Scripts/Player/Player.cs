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
    public int attackDamage = 50;
    public GameObject ball;
    public float shotForce = 1500f;
    public int health = 100;
    public int score = 0;

    void Start()
    {
        
    }
    void Update()
    {
        AttackAnim();
        Movement();
        Death();
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
    void AttackAnim()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
       
    }
    public void Attack()
    {
        GameObject newBall;
        newBall = Instantiate(ball, attackPoint.position, attackPoint.rotation);
        newBall.GetComponent<Rigidbody>().AddForce(attackPoint.forward * shotForce);
        Destroy(newBall, 3);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Sword"))
        {
            health -= 30;
        }
        else if(col.CompareTag("Box"))
        {
            if(health < 70)
            {
                health = 100;
            }
            else
            {
                score += 50;
                Debug.Log(score);
            }
        }
    }
    void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
