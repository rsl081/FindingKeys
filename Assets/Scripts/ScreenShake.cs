using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();    
    }
    
    public void ShakeCam(){
        anim.SetTrigger("shake");
    }
    
}
