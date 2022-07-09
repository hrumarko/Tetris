using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip delete, step;
    public static bool isSound = true;
    public static bool isMusic = true;
    

    private void Start() {
        delete = Resources.Load<AudioClip>("deletelines");
        step = Resources.Load<AudioClip>("step");
        
        
        audioSource = GetComponent<AudioSource>();

    }

    public static void PlayAudio(string name){
        if(name == "step" && isSound){
        audioSource.PlayOneShot(step);
        }

        if(name == "delete" && isSound){
            audioSource.PlayOneShot(delete);
        }

        

    }

    
}
