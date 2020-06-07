using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Spaceship
{
    [SerializeField]
    public float minX;
    [SerializeField]
    public float minY;
    [SerializeField]
    public float maxX;
    [SerializeField]
    public float maxY;

    [SerializeField]
    private GameObject playerMissile;

    [SerializeField]
    private Transform spawnPoint;

    private bool shieldIsDown = false;

    private bool isBeamWeapon = false;

    private Vector3 touchPosition;
    private Vector3 direction;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Speed = 5;
        weaponCooldown = 0;
        SpacesphipBody = GetComponent<Rigidbody2D>();
        SpaceshipTransform = GetComponent<Transform>();
        if(playerMissile.tag == "PlayerBeamWeapon" || playerMissile.tag == "PlayerLightning"){
            isBeamWeapon = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //player movement with touchscreen
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            SpacesphipBody.velocity = new Vector2(direction.x, direction.y) * Speed;

            if(touch.phase == TouchPhase.Ended){
                SpacesphipBody.velocity = Vector2.zero;
            }
        }
        if(weaponCooldown == 60 && !isBeamWeapon){
            Instantiate(playerMissile, spawnPoint.position, Quaternion.identity);
            weaponCooldown = 0;
        }
        if(weaponCooldown == 0 && isBeamWeapon){
            Vector3 temp = spawnPoint.position;
            if(playerMissile.tag == "PlayerBeamWeapon"){
                temp.y -= temp.y;
            }
             if(playerMissile.tag == "PlayerLightning"){
                temp.y -= temp.y/2.5f;
            }
            GameObject missile = Instantiate(playerMissile, temp, Quaternion.identity) as GameObject;
            missile.transform.parent = transform;
        }
        weaponCooldown++;

        //pc functions
        Move();
        Attack();
    }

    public void Move(){
        if(Input.GetAxisRaw("Vertical") > 0f){
            Vector3 temp = transform.position;
            temp.y += Speed * Time.deltaTime;

            if(temp.y > maxY){
                temp.y = maxY;
            }
            transform.position = temp;
        }
        else if(Input.GetAxisRaw("Vertical") < 0f){
            Vector3 temp = transform.position;
            temp.y -= Speed * Time.deltaTime;

            if(temp.y < minY){
                temp.y = minY;
            }
            transform.position = temp;
        }

         if(Input.GetAxisRaw("Horizontal") > 0f){
            Vector3 temp = transform.position;
            temp.x += Speed * Time.deltaTime;
            if(temp.x > maxX){
                temp.x = maxX;
            }
            transform.position = temp;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0f){
            Vector3 temp = transform.position;
            temp.x -= Speed * Time.deltaTime;
            if(temp.x < minX){
                temp.x = minX;
            }
            transform.position = temp;
        }

    }

    void Attack(){
        
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(playerMissile, spawnPoint.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "EnemyBullet"){
            SpacesphipAnimator.SetBool("isDestroyed", true);
            Destroy(gameObject, 1f);
        }
        if(collider.tag == "EnemyLaser" ){
            if(shieldIsDown == true){
                SpacesphipAnimator.SetBool("isDestroyed", true);
                Destroy(gameObject, 1f);
            }
            else if(shieldIsDown == false){
                
            }
        }
    }

}
