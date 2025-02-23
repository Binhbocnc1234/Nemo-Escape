using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Fish : MonoBehaviour{
    // float perseverance = 3f;
    void Attack(){
        Move(1.3f);
        dir = (Player.Instance.transform.position - transform.position).normalized;
    }
}