using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : Enemy
{
    //2,2,3
    public Transform playerTransform;
    public float attackSpeed;
    public float timeBetweenAttacks;
    private float attackTime;
    public float stopDistance;
    AIDestinationSetter aIDestinationSetter;
    public AudioClip attackSound;
    public AudioClip hurtSound;
    //Player player;
    public override void Start() {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        base.Start();
    }

    private void Update() {
        if(player !=  null){
            FindObjectOfType<AIDestinationSetter>().target = player.transform;
            playerTransform = player.transform;
              if (Vector2.Distance(transform.position, playerTransform.position) <= stopDistance)
            {
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        source.clip = attackSound;
        source.Play();
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = playerTransform.position;

        float percent = 0f;
        while (percent <= 1)
        {

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;

        }

    }

    public override void Damage()
    {
        base.Damage();
        AudioSource.PlayClipAtPoint(hurtSound, transform.position);
    }

}
