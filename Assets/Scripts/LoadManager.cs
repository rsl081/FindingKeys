using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoadManager : MonoBehaviour
{
    CinemachineConfiner confiner;
    // Start is called before the first frame update
    void Start()
    {
        var virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
 
        var confiner = virtualCamera.GetComponent<CinemachineConfiner>();
 
        confiner.InvalidatePathCache();
        confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Background").GetComponent<Collider2D>();
        
    }

}
