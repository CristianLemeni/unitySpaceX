using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    
    public Animator SpacesphipAnimator{get; set;}

    public Rigidbody2D SpacesphipBody {get; set;}

    public GameObject SpaceshipGameObject {get; set;}

    public Transform SpaceshipTransform {get; set;}

    public SpriteRenderer SpaceshipRenderer {get; set;}

    public float Speed{get; protected set;}

    protected int Health;

    protected int Damage;

    protected int WeaponType;
    protected int weaponCooldown;
    // Start is called before the first frame update
    public virtual void Start()
    {
        SpacesphipAnimator = GetComponent<Animator>();
        SpacesphipBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
