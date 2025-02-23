using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public Transform bubblePrefab;
    public float delay = 2f;
    Timer delayTimer = new Timer(0);
    void Start(){
        delayTimer.totalTime = delay;
    }
    void Update(){
        if (delayTimer.Count()){
            Transform b = Instantiate(bubblePrefab, this.transform.position, this.transform.rotation, this.transform);
            b.gameObject.SetActive(true);
        }
    }
}
 