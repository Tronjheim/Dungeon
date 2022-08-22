using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int score = 0;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            score += 100;
            Debug.Log(score);
        }
    }
}
