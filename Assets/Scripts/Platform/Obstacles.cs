using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject blood;
    private AudioSource source;
    public AudioClip hurtSound;
    private void Start() {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            source.clip = hurtSound;
            source.Play();
            Destroy(other.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }   

}
