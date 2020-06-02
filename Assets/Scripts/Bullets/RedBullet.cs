using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
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

    void Move(){
        Vector3 temp = transform.position;
        temp.y -=  speed * Time.deltaTime;
        if(temp.y < minY){
            Delete();
        }
        transform.position = temp;
    }

    void Delete(){
        Destroy(gameObject);
    }
}
