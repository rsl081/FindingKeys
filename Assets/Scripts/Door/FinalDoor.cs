using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalDoor : MonoBehaviour
{
    string[] typeOfDoors = {"Door Of Happiness",
                            "Door Of Love",
                            "Door Of Luck",
                            "Door Of Finesse"};
    string[] quotes = {
        "You have open the doors to all healings.\nThe path that negates bad feelings.\nWhere the laughter nest. \nThe joyful door of happiness."
        ,"Finally, you reach your romance. \nThe fruit of hardships and resilience.\nTopples all vengeance.\nThe sweet kiss of a loving presence."
        ,"You unleash the limitless possibilites to turn tides over enemies. \nWith the power of luck inside. \nThere is no reason to hide."
        ,"Showing them the yourself with class. \nDestroying them with style. \nNo challenges may pass. \nChest up, before entering the door with smile."};
    int randomDoors;
    public TextMeshProUGUI meshDoors;
    public TextMeshProUGUI meshQuotes;
    public GameObject doorPanel;
    private Animator panelAnim;
    private Animator doorAnim;
    private AudioSource source;
    public AudioClip openDoorSound;
    public GameObject openDoorEffect;
    public Transform openDoorPoss;
    public GameObject cursorOn;
    // Start is called before the first frame update
    void Start() {
        panelAnim = doorPanel.GetComponent<Animator>();
        doorAnim = GetComponent<Animator>();
        randomDoors = Random.Range(0, typeOfDoors.Length);        
        source = GetComponent<AudioSource>();
        //Debug.Log(typeOfDoors[randomDoors] + " " + quotes[randomDoors]);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Key")){
            Instantiate(openDoorEffect, openDoorPoss.position, Quaternion.identity);
            source.clip = openDoorSound;
            source.Play();
            panelAnim.SetTrigger("trans");
            doorAnim.SetTrigger("open");
            meshDoors.text = typeOfDoors[randomDoors];
            meshQuotes.text = quotes[randomDoors];
            Destroy(other.gameObject);
            cursorOn.SetActive(true);
        }
    }
    


}
