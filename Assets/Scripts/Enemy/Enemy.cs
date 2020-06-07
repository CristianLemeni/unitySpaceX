using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship
{

    [SerializeField]
    public GameObject enemyBullet;

    [SerializeField]
    public Transform spawnPoint;

    private int moveTimer;

    private IState currentState;

    public bool switchPatrol = false;

    public float minX = -7;
    public float maxX = 7;



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Speed = 2;
        moveTimer = 0;
        SpaceshipRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer++;
        if(moveTimer == 1){
            ChangeState(new Idle());
        }
        if(moveTimer == 90){
            ChangeState(new Patrol());
        }
        if(moveTimer == 100){
            ChangeState(new Attack());
            moveTimer = 0;
        }
        ExecuteState();
    }

    public void Move(){
        
    }

    public void ChangeState(IState newState){
        if(currentState != null){
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }


    public void ExecuteState(){
        currentState.Execute();
    }

    public void Shoot(){
        Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "PlayerBullet"){
            SpacesphipAnimator.SetTrigger("Destroyed");
            Destroy(gameObject, 1f);
        }
        if(collider.tag == "PlayerRotator"){
            SpacesphipAnimator.SetTrigger("Destroyed");
            Destroy(gameObject, 1f);
        }
        if(collider.tag == "PlayerArrow"){
            SpacesphipAnimator.SetTrigger("Destroyed");
            Destroy(gameObject, 1f);
        }
        if(collider.tag == "PlayerBeamWeapon"){
            SpacesphipAnimator.SetTrigger("Destroyed");
            Destroy(gameObject, 1f);
        }
        if(collider.tag == "PlayerLightning"){
            SpacesphipAnimator.SetTrigger("Destroyed");
            Destroy(gameObject, 1f);
        }
    }

}
