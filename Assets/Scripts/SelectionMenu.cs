using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour
{
    public GameObject menuSelection;
    public GameObject cursor;
    bool pressOne;
    private void Start() {
        // = Input.mousePosition;
    }
    void Update() {
        if(menuSelection.activeInHierarchy){
            pressOne = true;
        }else{
            pressOne = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && pressOne == false){
            menuSelection.SetActive(true);
            cursor.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && pressOne == true){
            menuSelection.SetActive(false);
            cursor.SetActive(false);
        }
        
    }
    public void LevelSelection(string name){
        SceneManager.LoadScene(name);
    }

    public void ExitQuit(){
        Application.Quit();
    }
}
