using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public GameObject vcm;
  //  public Vector2 parallaxEffectMultiplier
    private float textureUnitSizeX;
    //DAni
    public float parallaxEffect;
    private float length, startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       float temp = (vcm.transform.position.x * (1 - parallaxEffect));
       float dist = (vcm.transform.position.x * parallaxEffect);

       transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if(temp > startPos + length){
            startPos += length;
        }else if(temp < startPos - length){
            startPos -= length;
        }
    }
}
