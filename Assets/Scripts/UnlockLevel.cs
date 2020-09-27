﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    private Button button;
    public GameObject chains;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        button = GetComponent<Button>();
        if(PlayerPrefs.GetInt(sceneName, 0) == 1){
            button.interactable = true;
            chains.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
