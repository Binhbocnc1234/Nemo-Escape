using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Fish : MonoBehaviour{
    // float perseverance = 3f;
    public float eatingRadius = 0.4f;
    public virtual void Attack(){
        Move(1.3f);
        dir = (Player.Instance.transform.position - transform.position).normalized;
    }
    void CheckNemo(){  
        if (Vector2.Distance(mouth.transform.position, Player.Instance.transform.position) <= 0.4f && this.level > Player.Instance.level){
            fishState = FishState.Eat;
            Destroy(Player.Instance.gameObject);
            StartCoroutine(GameManager.Instance.Lose());
            Invoke("ReturnToIdle", animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
    private void ReturnToIdle(){
        fishState = FishState.Idle;
    }
}