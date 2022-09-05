using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text text;
    void Start()
    {
         ScoreManager.Instance.scoreText = text;
        text.text = ScoreManager.Instance.score.ToString();
    }
}
