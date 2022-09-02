using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            /*aca tendria que chequear si la vida<=0 para destruirlo
             aunque mi idea es que solo el boss tenga mas vida y los demas mueran de un solo disparo*/
            Destroy(gameObject);
            Destroy(col.gameObject);
            ScoreManager.Instance.score += 100;
            Debug.Log(ScoreManager.Instance.score);
        }
    }
}