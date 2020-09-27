using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    int currentPointIndex;
    float waitTime;
    public float startWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        if(transform.position == patrolPoints[currentPointIndex].position){
            if(waitTime <= 0){
               if(currentPointIndex + 1 < patrolPoints.Length){
                   currentPointIndex++;
               }else{
                   currentPointIndex = 0;
               }
               waitTime = startWaitTime;
            }else{
                waitTime -= Time.deltaTime;
            }
        }
    }//end of update

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.parent = null;
        }
    }
}
