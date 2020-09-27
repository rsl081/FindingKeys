using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coroutine : MonoBehaviour
{
   Player player;
    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        if(player ==  null){   
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn(){  
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

  
}
