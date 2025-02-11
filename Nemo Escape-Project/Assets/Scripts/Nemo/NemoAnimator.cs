using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoAnimator : MonoBehaviour
{
    public void EndTurnAround(){
        Player.Instance.isTurnAround = false;
    }
}
