using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string names;
    private Animator anim;
    Player player;
    public GameObject doorEffect;
    AudioSource source;
    public AudioClip openSound;
    private void Start() {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // sa last ibang key n lng gamitin ko para maging ayos
        Key key = FindObjectOfType<Key>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(other.CompareTag("Key")){
            source.clip = openSound;
            source.Play();
            player.canMove = false;
            player.move = 0;
            player.playerAnim.SetBool("isRunning", false);
            key.transform.position = transform.position; 
            key.isFollowing = false;
            Instantiate(doorEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            StartCoroutine(LoadScene(names));
        }
        if(other.CompareTag("Player")){
            if(player.canMove == key.isFollowing){
                other.GetComponent<Player>().Health = 5;
                other.GetComponent<Player>().stopSoundAtDoor = true;
            }
            //DontDestroyOnLoad(other.gameObject);
        }
    }


    IEnumerator LoadScene(string names){
        anim.SetBool("open", true);
        yield return new WaitForSeconds(2f);
        // FindObjectOfType<Player>().enabled = true;
        // FindObjectOfType<Player>().transform.position = new Vector2(-5.66f, -1.76f);
        SceneManager.LoadScene(names);
    }

}
