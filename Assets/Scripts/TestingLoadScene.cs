using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingLoadScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene("Final");
            other.transform.position = new Vector2(-5.66f, -1.76f);
            DontDestroyOnLoad(other.gameObject);
        }
    }
}
