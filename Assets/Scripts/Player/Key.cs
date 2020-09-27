using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keySpeed;
    public Transform keyFollow;
    public bool isFollowing;   

    Player player;
    AudioSource source;
    public AudioClip pickSound;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null){
            if(isFollowing){
                transform.position = Vector3.Lerp(transform.position, keyFollow.position, keySpeed * Time.deltaTime);
            }
        }



       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(player != null){
                if(isFollowing == false){
                    source.clip = pickSound;
                    source.Play();
                }
                keyFollow = player.playerKeyFollow;
                isFollowing = true;
            }
        }
       
    }
}
