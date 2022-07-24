using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSounds : MonoBehaviour
{
    public static ManagerSounds instancia;
    void Awake()
    {
        if(ManagerSounds.instancia == null)
        {
            ManagerSounds.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    
    void Update()
    {
        
    }
}
