using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemyShooter : Enemy
{
    public Transform shootingPoint;
    public GameObject fireBall;
    public float timeBetweenAttack;
    private float nextAttackTime;
    private bool facingRight = true;
    public bool faceFlip;
    public AudioClip hurt;
   // public AudioClip shoot;
    // Start is called before the first frame update
    public override void Start()
    {
       base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Attack(faceFlip);   

    }

    void Attack(bool whichAttack){
        if(Time.time >= nextAttackTime && whichAttack == true){
            Instantiate(fireBall, shootingPoint.position, transform.rotation);
            nextAttackTime = Time.time + timeBetweenAttack;
        }
        if(Time.time >= nextAttackTime && whichAttack == false){
            Instantiate(fireBall, shootingPoint.position, Quaternion.Euler(0f,0f,180f));
            nextAttackTime = Time.time + timeBetweenAttack;
        }

    }

    public override void Damage()
    {
        base.Damage();
        AudioSource.PlayClipAtPoint(hurt, transform.position, 0.2f);
        if(health <= 0){
            GameObject.Find(gameObject.name + ("spawn point")).GetComponent<Spawner>().Death = true;
        }
    }

    //ETO YUNG NABOBO AKO SA CODE HAHAHA
    // public override void Damage()
    // {
    //     base.Damage();
    //     HurtEffect();
    //     health -= FindObjectOfType<Player>().damage;
    //     if(health <= 0){
    //         HurtEffect();
    //         GameObject.Find(gameObject.name + ("spawn point")).GetComponent<Spawner>().Death = true;
    //         Destroy(this.gameObject);
    //     }else{
    //         Invoke("ResetMaterial", .1f);
    //     }
    //     Instantiate(blood, transform.position, Quaternion.identity);
    // }

}
