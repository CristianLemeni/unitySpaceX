using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : IState
{
    private Enemy enemy;

    public float minX = -8;

    public float maxX = 8;

    public void Enter(Enemy enemy){
        this.enemy = enemy;
    }
    public void Execute(){
        if(!enemy.switchPatrol){
            PatrolLeft();
        }
        if(enemy.switchPatrol){
            PatrolRight();
        }
    }
    public void Exit(){

    }

    private void PatrolLeft(){
         Vector3 temp = enemy.transform.position;

        temp.x -= enemy.Speed * Time.deltaTime;
            if(temp.x < minX){
                temp.x = minX;
                enemy.switchPatrol = !enemy.switchPatrol;
            }
        enemy.transform.position = temp;
    }



    private void PatrolRight(){
         Vector3 temp = enemy.transform.position;

        temp.x += enemy.Speed * Time.deltaTime;
            if(temp.x > maxX){
                temp.x = maxX;
                enemy.switchPatrol = !enemy.switchPatrol;
            }
        enemy.transform.position = temp;
    }
}
