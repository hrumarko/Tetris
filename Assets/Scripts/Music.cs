using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static AudioSource audSrc;
    public static bool isMusic = true;
    void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    private void Update() {
        
    }

    // Update is called once per frame
    

    public static void StopMusic()
    {
        audSrc.Pause();
    }
    public static void StartMusic(){
        audSrc.Play();
    }
}
