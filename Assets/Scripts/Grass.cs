using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("Player")){
           animator.SetTrigger("move");
       }
   }
}
