using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CineMachine : MonoBehaviour
{
    //public static CineMachine instance;
    public CinemachineVirtualCamera vcm;
    public Transform tFollowTarget;
    Player player;
    // private void Awake() {
    //     DontDestroyOnLoad(this.gameObject);
    // }

    private void Start() {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player = FindObjectOfType<Player>();
        vcm = GetComponent<CinemachineVirtualCamera>();
        // if (player == null)
        // {
        //     player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // }

        if (player != null)
        {
            tFollowTarget = player.transform;
            vcm.LookAt = tFollowTarget;
            vcm.Follow = tFollowTarget;
        }

       
    }
   
}
