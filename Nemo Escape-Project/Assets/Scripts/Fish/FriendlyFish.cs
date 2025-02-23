using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Fish : MonoBehaviour
{

    Timer timer = new Timer(1f);
    void ChillFish()
    {
        Move();

        if (timer.Count()){
            dir += new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
        }
        
    }
    void Escape(){
        dir = (transform.position - Player.Instance.transform.position).normalized;
        Move();
        
    }

}
