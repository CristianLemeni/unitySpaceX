﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaser : MonoBehaviour, IMissile
{
    public float minY = -10;

    public float speed = 5f;
    public float deactivateTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
        Vector3 temp = transform.position;
        temp.y -=  speed * Time.deltaTime;
        if(temp.y < minY){
            Delete();
        }
        transform.position = temp;
    }

    public void Delete(){
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            Destroy(gameObject, 0.1f);
        }
         if(collider.tag == "Shield"){
            Destroy(gameObject, 0.1f);
        }
    }
}
