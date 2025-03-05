using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Electric : Fish{

    Timer timer;
    Timer Elec;
    float time = 3f;
    float time2 = 0.5f;
    public override void Start(){
        timer = new Timer(time);
        Elec = new Timer(time2);
    }

    public override void Attack(){
        base.Attack();

        if(timer.Count()){
            Player.Instance.speed = 0f;
            Elec.curTime = 0f;
        }

        if(Elec.Count()){
            Player.Instance.speed = Player.Instance.speed_raw;
        }

    }



}