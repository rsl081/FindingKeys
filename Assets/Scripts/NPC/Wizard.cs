using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public string[] lines;
    public GameObject textBox;
    private Animator openTextBox;
    private bool canActive;

    // Start is called before the first frame update
    void Start()
    {
        openTextBox = textBox.GetComponent<Animator>();
    }

    void Update() {
        if(canActive && Input.GetKeyDown(KeyCode.T) && !DialogueBoxManager.instance.dialogBox.activeInHierarchy){
            DialogueBoxManager.instance.ShowDialog(lines);
        }    
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("Player")){
          openTextBox.SetBool("talk", true); 
          canActive = true;
       }
   }
   private void OnTriggerExit2D(Collider2D other) {
       if(other.CompareTag("Player")){
          openTextBox.SetBool("talk", false); 
          canActive = false;
       }
   }

}
