using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int health;

    private SpriteRenderer spriteRender;

    private bool isHit;
    private int blinkTimer;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        blinkTimer = 0;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(isHit){
           if(blinkTimer == 0 || blinkTimer == 5 || blinkTimer == 10 || blinkTimer == 15 || blinkTimer == 20 ){
                blink();
           }
           blinkTimer++;
       }
       if(blinkTimer > 24){
            isHit = false;
            blinkTimer = 0;
            spriteRender.enabled = true;
       }
    }

    public void blink(){
        spriteRender.enabled = !spriteRender.enabled;
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "EnemyLaser"){
            if(health > 0){
                health--;
                isHit = true;
            }
            else{
                spriteRender.enabled = false;
                Destroy(gameObject, 1f);
            }
        }
    }
}
