using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            ScoreManager.Instance.score += 100;
            Debug.Log(ScoreManager.Instance.score);
        }
    }
}
