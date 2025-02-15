using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformMotion : MonoBehaviour
{
    public Vector3 direction;
    void Update(){
        transform.Translate(direction*Time.deltaTime);
    }
    public void SetRandomDirection(float magnitude){
        float angle = Random.Range(0, 360f);
        direction  = (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized)*magnitude; 
    }
}
