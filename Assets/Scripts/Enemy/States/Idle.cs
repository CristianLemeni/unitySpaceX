using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{
    private Enemy enemy;

    private int cooldown;
    private int timer;

    public void Enter(Enemy enemy){
        this.enemy = enemy;
        timer = 0;
        cooldown = 0;
    }
    public void Execute(){
        if(timer > 30){
            Float();
            cooldown++;
            if(cooldown > 5){
                cooldown = 0;
            }
            timer = 0;
        }
        else{
            timer++;
        }
    }
    public void Exit(){

    }

    private void Float(){
       Vector3 temp = enemy.transform.position;
       
       if(cooldown % 2 == 0){
            temp.x += enemy.Speed * Time.deltaTime;
            enemy.transform.position = temp;
       }
       if(cooldown % 2 == 1){
            temp.x -= enemy.Speed * Time.deltaTime;
            enemy.transform.position = temp;
       }
    }
}
