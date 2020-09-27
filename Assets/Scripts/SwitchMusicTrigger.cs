using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
   public AudioClip newTrack;
   private Music theMusic;

   private void Start() {
       theMusic = FindObjectOfType<Music>();
    
        if(newTrack != null){
            theMusic.ChangeBGM(newTrack);
        }
       
   }
}
