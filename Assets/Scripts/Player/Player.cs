using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Player : MonoBehaviour, IDamageable
{
    public int Health {get; set; }
    public Rigidbody2D _rigid;
    public float move;
    public float speed;
    bool isGrounded;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForce;
    bool facingRight = true;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public Animator playerAnim;
    public float timeBetweenAttack;
    private float nextAttackTime;
    public int health;
    public GameObject blood;
    //Hurt Panel
    public GameObject hurtPanel;
    private Animator hurtAnim;
    public Transform playerKeyFollow;
    public SpriteRenderer weaponRenderer;
    public int damage;
    //Trail
    public Transform trail;
    public Transform particle;
    private ParticleSystem trl;
    private ParticleSystem ps;
    //Can move                                                                                              
    public bool canMove = true;
    //Foot dust
    public ParticleSystem dust;
    //Audio
    private AudioSource source;
    private AudioSource source2;
    public GameObject walkSoundObject;
    public AudioClip walk;
    public AudioClip attack;
    public AudioClip hurt;
    public AudioClip jumpSound;
    public bool stopSoundAtDoor;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source2 = walkSoundObject.GetComponent<AudioSource>();
        Health = health;
        _rigid = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel");
        hurtAnim = hurtPanel.GetComponent<Animator>();
        trl = trail.GetComponent<ParticleSystem>();
        ps = particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if(move != 0){
            playerAnim.SetBool("isRunning", true);
        }else{
            playerAnim.SetBool("isRunning", false);
            source2.clip = walk;
            source2.loop = true;
            source2.Play();
        }
        if(canMove){
            MovePlayer();
            JumpPlayer();
            WallJumping();
        }else{
            _rigid.velocity = new Vector2(0,0);
        }
       Attack();
       if(stopSoundAtDoor){
            source2.clip = walk;
            source.loop = false;
            source2.Stop();
       }
    }
    

    void WallJumping(){
         isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if(isTouchingFront ==  true && isGrounded == false && move != 0){
            wallSliding = true;
            source2.clip = walk;
            source2.Stop();

            source.clip = attack;
            source.Stop();

       
        }else{
            // source.clip = jumpSound;
            // source.Play();
            wallSliding = false;
        }

        if(wallSliding){
            _rigid.velocity = new Vector2(_rigid.velocity.x, Mathf.Clamp(_rigid.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && wallSliding == true){
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if(wallJumping == true){
            _rigid.velocity = new Vector2(xWallForce * -move, yWallForce);
        }
    }

    void SetWallJumpingToFalse(){
        wallJumping = false;
    }

    void JumpPlayer(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded == true){
            _rigid.velocity = Vector2.up * jumpForce;
            source.clip = jumpSound;
            source.Play();

            source2.clip = walk;
            source2.Stop();
            CreateDust();
        }

        if(isGrounded == true){
            playerAnim.SetBool("isJumping", false);
        }else{
            source2.Play();
            playerAnim.SetBool("isJumping", true);
        }
        
    }
    void Attack(){
         if(Time.time > nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Space)){
                FindObjectOfType<ScreenShake>().ShakeCam();
                playerAnim.SetTrigger("Attack");
                source.clip = attack;
                source.Play();
                nextAttackTime = Time.time + timeBetweenAttack;
            }
            
        }
    }

    void MovePlayer(){
        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);
        if(move > 0 && facingRight == false){
            CreateDust();
            Flip();
        }else if(move < 0 && facingRight == true){
            Flip();
            CreateDust();
        }
    }

    void Flip(){
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, checkRadius);
        Gizmos.DrawSphere(frontCheck.position, checkRadius);
    }

    public void Damage(){
        FindObjectOfType<ScreenShake>().ShakeCam();
        AudioSource.PlayClipAtPoint(hurt, transform.position, 0.9f);
        Health--;
        if(Health <= 0){
            Destroy(this.gameObject);        
        }
        Instantiate(blood, transform.position, Quaternion.identity);
        hurtAnim.SetTrigger("hurt");
    }

    public void Equip(Weapon weapon){
       weaponRenderer.sprite = weapon.GFX;
       ParticleSystem.MainModule ma = trl.main;
       ParticleSystem.MainModule ma2 = ps.main;
       ma.startColor = weapon.color;
       ma2.startColor = weapon.color;
       damage = weapon.damage;
       Destroy(weapon.gameObject);
    }

    void CreateDust(){
        dust.Play();
    }


}
