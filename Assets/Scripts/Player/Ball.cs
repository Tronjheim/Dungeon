using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     void Start()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Enemy"))
        {   
                Destroy(gameObject);
                Destroy(col.gameObject);
                ScoreManager.Instance.score += 100;
                   
        }
        else if (col.transform.CompareTag("Boss"))
        {
            col.transform.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
        
    }

}