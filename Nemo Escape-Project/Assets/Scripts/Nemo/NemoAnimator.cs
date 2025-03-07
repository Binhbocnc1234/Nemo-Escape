using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoAnimator : Singleton<NemoAnimator>
{
    public Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void EndTurnAround(){
        Player.Instance.isTurnAround = false;
    }
    public void EndEat(){
        Player.Instance.isEating = false;
    }
    public void EndGrow(){
        Player.Instance.isGrow = false;
    }
}
