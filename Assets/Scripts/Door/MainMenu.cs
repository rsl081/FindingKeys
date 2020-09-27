using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelTransistion;
    private Animator anim;

    private void Start() {
        anim = panelTransistion.GetComponent<Animator>();
    }
    public void LoadScene(string name){ 
        StartCoroutine(Transistion(name));
    }

    IEnumerator Transistion(string name){
        anim.SetTrigger("transis");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }

}
