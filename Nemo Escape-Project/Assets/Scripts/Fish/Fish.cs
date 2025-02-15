using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script used by Nemo and other fish
/// </summary>
public class Fish : MonoBehaviour
{
    public GameObject Nemo;
    public int level;
    public int score; //Điểm ghi được khi bị Nemo ăn
    public bool canEat = false; //Sẽ quyết định cá lành hay cá dữ
    public float normalSpeed, runSpeed, range; //range: tầm phát hiện của Fish
    
    
    void Update(){

        int nemo_level = Player.Instance.level;

        if(nemo_level < level){
            canEat = true;
        }

        inRange();

    }


    void inRange(){

        float distance = Vector3.Distance(Nemo.transform.position, transform.position);

        if(distance > range){
            return;
        }

        if (canEat){
            Run();
        }
        else{
            Hunt();
        }

    }


    void Run(){
        

    }

    void Hunt(){



    }



}
