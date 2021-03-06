﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numberOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.Health > numberOfHearts){
            player.Health = numberOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++){
            if(i < numberOfHearts){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }

            if(i < player.Health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = brokenHeart;
            }
        }

        
    }//end of update
}
