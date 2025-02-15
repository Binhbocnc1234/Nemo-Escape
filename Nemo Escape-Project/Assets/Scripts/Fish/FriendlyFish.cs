using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Fish : MonoBehaviour
{

    Timer timer = new Timer(1f);
    void ChillFish()
    {
        Move();
        transform.Translate(diff.normalized*Time.deltaTime*speed);
        if (CheckOutOfBound(0)){
            direction *= -1;
        }
        else if (timer.Count()){
            direction += new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            if (direction != Vector3.zero){
                direction.Normalize();
            }
            else{
                direction = Vector3.up;
            }

        }
        
    }
    void Escape(){
        direction = (transform.position - Player.Instance.transform.position).normalized;
        Move();
        
    }

}
