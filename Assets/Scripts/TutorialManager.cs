using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int currentIndex;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++){
            if(i == currentIndex){
                //Debug.Log(currentIndex + " " + i);
                popUps[i].SetActive(true);
            }else{
                popUps[i].SetActive(false);
            }
        }

        if(currentIndex == 0){
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                currentIndex++;
            }
        }
        else if(currentIndex == 1){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)
                || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
                currentIndex++;
            }
        }else if(currentIndex == 2){
                if(Input.GetKeyDown(KeyCode.Space)){
                    currentIndex++;
                }
        }else if(currentIndex == 3){
            if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))){
                currentIndex++;
            }
        }

    }
}
