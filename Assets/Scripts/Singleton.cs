using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.CompareTag ("Ladder"))
        {
            SceneManager.LoadScene(2);
        }
    }
    
}
