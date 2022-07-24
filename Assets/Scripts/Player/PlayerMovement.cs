using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     float speed = 5f;
    public Animator anim;
    float rotateSpeed = 200f;
    void Start()
    {
        
    }
    void Update()
    {
        Movement();
        Attack();
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
}
