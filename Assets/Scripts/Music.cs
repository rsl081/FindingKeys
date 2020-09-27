using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource BGM;
    private void Start() {
        DontDestroyOnLoad(gameObject);
        if(FindObjectsOfType<Music>().Length > 1){
            Destroy(gameObject);
        }
        
    }

    
    public void ChangeBGM(AudioClip music){
        if(BGM.name == music.name){
            return;
        }

        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }



}
