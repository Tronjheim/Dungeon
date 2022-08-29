using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthText;

    void Update()
    {
        healthText.text = Player.health.ToString();
       
    }
}