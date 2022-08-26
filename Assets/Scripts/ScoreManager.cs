using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;
    void Start()
    {
        if(Instance== null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
