using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    private SpriteRenderer sprite;
    public bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(facingRight){
            sprite.flipX = true;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }else{
            sprite.flipX = false;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Destroy(this.gameObject);
        }
    }
}
