using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCam : MonoBehaviour
{
    public GameObject camMain;
    public Camera cineMachine;
    public bool isActive;
    public GameObject finalKey;
    public GameObject finalDoor;
    private void Start() {
       // cineMachine = FindObjectOfType<CineMachine>(); 
    }
  
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){ 
            //Destroy(cineMachine.vcm.gameObject);
            Destroy(cineMachine.gameObject);
            Destroy(gameObject);
            camMain.SetActive(isActive);
        }
    }
}
