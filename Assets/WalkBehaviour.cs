using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehaviour : StateMachineBehaviour
{
    public GameObject[] patrolPoints;
    private int currentIndex;
    private float waitTime;
    public float startWaitTime;
    public float speed;
    int randomInt;
    Boss boss;
    Player player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss = FindObjectOfType<Boss>();
       player = FindObjectOfType<Player>();
       randomInt = Random.Range(0, patrolPoints.Length);
       patrolPoints = GameObject.FindGameObjectsWithTag("patrolpoint");
       animator.transform.rotation = patrolPoints[randomInt].transform.rotation;
        if(randomInt == 1){ 
            boss.whichAttack = 1;
        }else if(randomInt == 0){
            boss.whichAttack = 0;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolPoints[randomInt].transform.position, speed * Time.deltaTime);  
       if(animator.transform.position == patrolPoints[randomInt].transform.position){
           if(boss.goMoveStage2 == false){
               animator.SetBool("shoot", true);
           }
        }
    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

  
}
