using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerSounds : MonoBehaviour
{
    public static ManagerSounds instancia;
    public Sound[] sounds;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
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
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
   
}
