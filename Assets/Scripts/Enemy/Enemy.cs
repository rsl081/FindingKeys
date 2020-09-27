using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    protected Slider slder;
    public int health;
    public float speed;
    protected float waitTime;
    public float startWaitTime;
    public GameObject blood;
    protected Player player;
    private SpriteRenderer[] spriteRenderer;
    public AudioSource source;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = FindObjectOfType<Player>();  
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    public virtual void Damage()
    {
        HurtEffect();
        health -= player.damage;
        if(health <= 0){
            HurtEffect();
            Destroy(this.gameObject);
        }else{
            Invoke("ResetMaterial", .1f);
        }
        Instantiate(blood, transform.position, Quaternion.identity);
    }

    protected void HurtEffect(){
         for(int x = 0; x < spriteRenderer.Length-1; x++){
            spriteRenderer[x].material.color = Color.red;
        }
    }

    protected void ResetMaterial(){
        for(int x = 0; x < spriteRenderer.Length-1; x++){
            spriteRenderer[x].material.color = Color.white;
        }
    }

}
