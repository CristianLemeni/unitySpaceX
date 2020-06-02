using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IState
{
    private Enemy enemy;

    public void Enter(Enemy enemy){
        this.enemy = enemy;

    }
    public void Execute(){
        Shoot();
    }
    public void Exit(){

    }

    private void Shoot(){
        enemy.Shoot();
    }
}
