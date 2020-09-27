using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Boss : Enemy
{
   // private Player player;
    //public Transform playerPos;
    private Animator bossAnim;
    public GameObject healthBar;
    public GameObject imageLogo;
    public GameObject padLocks; 
    public Transform padLocksPos; 
    public int whichAttack;
    //Boss Dialogue
    public GameObject textBox;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public string[] dialogLines;
    int currentIndex;
    private int halfHealth;
    public bool goMoveStage2;
    private bool isRunning = false;
    private bool isTypingIsOn = false;
    //StageTwo
    
    public Transform[] targetPosition;
    int currentIndexStageTwo;
    private Animator animator;
    //private Player player;
    public int leftQuaternion;
    public int rightQuaternion;
    public float stopDistance;
    float timeStart = 2;
    public GameObject finalKey;
    public GameObject finalDoor;
    public GameObject bossBoom;
    public AudioClip sleepSound;
    public AudioClip hurtSound;
    public AudioClip attackClip;
    public GameObject hurtSoundPos;
    public GameObject shootSound;
    public GameObject awakeSound;
    public GameObject attackSound;
    public GameObject dieSound;
    public GameObject dashSound;
    bool playOnce = true;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossAnim = GetComponentInChildren<Animator>();
        slder = GameObject.FindGameObjectWithTag("healtbar").GetComponent<Slider>();
        slder.maxValue = health;
        slder.value = health;
        healthBar.SetActive(false);
        halfHealth = health / 2; 
        source.clip = sleepSound;
        source.loop = true;
        source.Play();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if(player != null){
            if(Vector2.Distance(transform.position, player.transform.position) < 10){
                healthBar.SetActive(true);
                imageLogo.SetActive(true);
                bossAnim.SetTrigger("wakeup");
                //eto yung mga naiwanan ko
                SoundAwake();
                source.clip = sleepSound;
                source.loop = false;
                source.Stop();
                textBox.SetActive(true);
                ShowDialog();
            }

        }//end of null
        
        if(health <= halfHealth){   
            goMoveStage2 = true;
            bossAnim.SetTrigger("stageTwo");
            if(player !=  null){
                transform.position = Vector2.MoveTowards(transform.position, targetPosition[currentIndexStageTwo].position, speed * Time.deltaTime);
                if(Vector2.Distance(transform.position, player.transform.position) < stopDistance){
                    Vector2 relativePoint = player.transform.localPosition - transform.localPosition;
                    if (relativePoint.x < 0.0){
                        //HitSound();
                        transform.rotation = Quaternion.Euler(new Vector3(0,leftQuaternion,0));
                        bossAnim.SetTrigger("Attack");
                    }else if (relativePoint.x > 0.0){
                        //HitSound();
                        transform.rotation = Quaternion.Euler(new Vector3(0,rightQuaternion,0));
                        bossAnim.SetTrigger("Attack");
                    } 
                    bossAnim.SetBool("isWalking", false);
                }
                    if(transform.position == targetPosition[currentIndexStageTwo].position){
                        transform.rotation = targetPosition[currentIndexStageTwo].rotation;
                        bossAnim.SetBool("isWalking", false);
                    if(timeStart <= 0){
                            bossAnim.SetBool("isSleeping", false);
                        if(currentIndexStageTwo + 1 < targetPosition.Length){
                            currentIndexStageTwo++;
                        }else{
                            currentIndexStageTwo = 0;
                        }
                            timeStart = startWaitTime;
                        }else{
                            bossAnim.SetBool("isSleeping", true);
                            timeStart -= Time.deltaTime;
                        }
                    }else{
                        bossAnim.SetBool("isWalking", true);
                    }
                
                //end of null
            }else{
                return;
            }
        }//end of checking health

        



    }
    void SoundAwake(){
         if(playOnce == true){
            Instantiate(awakeSound, transform.position, transform.rotation);
            playOnce = false;
           
        }
    }

    void ShowDialog(){
        if(isTypingIsOn == true && Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<Player>().canMove == false){
            currentIndex++;
            isRunning = false;
            isTypingIsOn = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<Player>().canMove == false){
            currentIndex = dialogLines.Length;
        }


        if(currentIndex < dialogLines.Length){
            FindObjectOfType<Player>().canMove = false;
            FindObjectOfType<Player>().move = 0;
            if(dialogLines[currentIndex].StartsWith("n-")){
                nameText.text = dialogLines[currentIndex].Replace("n-","");
                currentIndex++;
            }else{
                    //dialogText.text = dialogLines[currentIndex];
                if(isRunning == false){
                    StartCoroutine(TypeWriteText(currentIndex));
                    isRunning = true;
                }
            }//end of starwith
        }else{
            textBox.SetActive(false);
            FindObjectOfType<Player>().canMove = true;
            bossAnim.SetTrigger("stageOne");
        }
    }

    IEnumerator TypeWriteText(int currentIndexInEnumerator){
        for(int i = 0; i <= dialogLines[currentIndexInEnumerator].ToCharArray().Length; i++){
            dialogText.text = dialogLines[currentIndexInEnumerator].Substring(0,i);
            yield return new WaitForSeconds(0.1f);
        }
        isTypingIsOn = true;
    }




    public override void Damage()
    {
        base.Damage();
        Instantiate(hurtSoundPos, transform.position, transform.rotation);
        slder.value = health;
        if(health <= 0){
            Instantiate(dieSound, transform.position, transform.rotation);
            healthBar.SetActive(false);
            imageLogo.SetActive(false);
            finalKey.SetActive(true);
            finalDoor.SetActive(true);
            Instantiate(bossBoom, transform.position, Quaternion.identity);
        }
        
    }



    
    public  void Attack(){
        if(Time.time >= waitTime && whichAttack == 1){
            GameObject ss = GameObject.Instantiate(shootSound, transform.position, transform.rotation);
            Destroy(ss, 4f);
            Instantiate(padLocks, padLocksPos.position, Quaternion.Euler(360f, 0f, 0f));
            waitTime = Time.time + startWaitTime;
        }

        if(Time.time >= waitTime && whichAttack == 0){
            GameObject ss = GameObject.Instantiate(shootSound, transform.position, transform.rotation);
            Destroy(ss, 4f);
            Instantiate(padLocks, padLocksPos.position, Quaternion.Euler(180f, 0f, 180f));
            waitTime = Time.time + startWaitTime;
        }

    }

    public void HitSound(){
        GameObject attSd = GameObject.Instantiate(attackSound, transform.position, transform.rotation);
        Destroy(attSd, 4f);
    }
 
    public void Dash(){
        GameObject dash = Instantiate(dashSound, transform.position, transform.rotation);
        Destroy(dash, 4f);
    }
 


}
