using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float turnSpeed;
    public int damage;
    public Sprite GFX;
    public Color color;
    public int r;
    public int g;
    public int b;
    public GameObject pickUpEffect;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        color = new Color(r/255f, g/255f, b/255f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Player>().Equip(this);
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        }
    }
}
