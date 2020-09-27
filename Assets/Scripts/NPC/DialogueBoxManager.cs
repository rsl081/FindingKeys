using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBoxManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public GameObject dialogBox;
    public string[] dialogLines;

    public int currentLine;
    public static DialogueBoxManager instance;
    Player player;
    private bool isRunning = false;
    public float typeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(dialogBox.activeInHierarchy){
            if(Input.GetKeyDown(KeyCode.Return) && isRunning == true){
                    isRunning = false; 
                    currentLine++;
                    if(currentLine >= dialogLines.Length){
                        dialogBox.SetActive(false);
                        player.canMove = true;
                    }else{
                        checkIfName();
                        StartCoroutine(typeLetter());
                    }
                
            }
        }
    }
    IEnumerator typeLetter(){
     
        for(int i = 0; i <= dialogLines[currentLine].ToCharArray().Length; i++){
            dialogText.text = dialogLines[currentLine].Substring(0,i);
            yield return new WaitForSeconds(typeSpeed);
        }
        isRunning = true;
        //Debug.Log(dialogLines[currentLine].ToCharArray().Length);
        
    }

    public void ShowDialog(string[] newLines){
        dialogLines = newLines;

        currentLine = 0;
        checkIfName();
        //dialogText.text = dialogLines[0];
        //Debug.Log(dialogLines[currentLine].ToCharArray().Length);
        StartCoroutine(typeLetter());
        dialogBox.SetActive(true);
        player.canMove = false;
        player.move = 0;
    }


    public void checkIfName(){
        if(dialogLines[currentLine].StartsWith("n-")){
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}
