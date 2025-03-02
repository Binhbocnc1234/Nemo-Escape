using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Fish : MonoBehaviour{
    // float perseverance = 3f;
    void Attack(){
        Move(1.3f);
        dir = (Player.Instance.transform.position - transform.position).normalized;
    }
    void CheckNemo(){
        if (diff.magnitude <= 0.3f && this.level > Player.Instance.level){
            fishState = FishState.Eat;
            Destroy(Player.Instance.gameObject);
            GameManager.Instance.Lose();
        }
    }
    private IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        fishState = FishState.Idle;
    }
}