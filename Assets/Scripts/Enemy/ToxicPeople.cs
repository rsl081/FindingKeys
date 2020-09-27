using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPeople : Enemy
{
    public Transform[] targetPosition;
    int currentIndex;
    private Animator animator;
    //private Player player;
    public int leftQuaternion;
    public int rightQuaternion;
    public float stopDistance;
    public AudioClip hurt;
    public override void Start(){
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        base.Start();
        transform.position = targetPosition[0].position;
        transform.rotation = targetPosition[0].rotation;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(player !=  null){
            if(Vector2.Distance(transform.position, player.transform.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, targetPosition[currentIndex].position, speed * Time.deltaTime);
            }

            if(Vector2.Distance(transform.position, player.transform.position) < stopDistance){
                Vector2 relativePoint = player.transform.localPosition - transform.localPosition;
                if (relativePoint.x < 0.0){
                    print ("Object is to the left");
                    transform.rotation = Quaternion.Euler(new Vector3(0,leftQuaternion,0));
                }else if (relativePoint.x > 0.0){
                    print ("Object is to the right");
                    transform.rotation = Quaternion.Euler(new Vector3(0,rightQuaternion,0));
                }
                animator.SetTrigger("Attack");
                animator.SetBool("isWalking", false);

            }else{
                if(transform.position == targetPosition[currentIndex].position){
                    transform.rotation = targetPosition[currentIndex].rotation;
                    animator.SetBool("isWalking", false);
                if(waitTime <= 0){
                    if(currentIndex + 1 < targetPosition.Length){
                        currentIndex++;
                    }else{
                        currentIndex = 0;
                    }
                    waitTime = startWaitTime;
                }else{
                        waitTime -= Time.deltaTime;
                    }
                }else{
                    animator.SetBool("isWalking", true);
                }
            }
        }else{
            return;
        }
    }

    public override void Damage()
    {
        base.Damage();
        AudioSource.PlayClipAtPoint(hurt, transform.position);
    }

}
