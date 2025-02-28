using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


public class RandomModule{

    public float RandomBetween(float first, float second){
        return Random.Range(first, second);
    }

    public bool RadomOneTwo(){

        float randomValue = Random.Range(0f, 100f);

        if(randomValue < 50){
            return true;
        }
        else{
            return false;
        }

    }





}