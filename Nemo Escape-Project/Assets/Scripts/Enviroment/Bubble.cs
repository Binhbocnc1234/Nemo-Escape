using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    public float existTime;
    public Timer existTimer = new Timer(0);
    void Start()
    {
        existTimer.totalTime = existTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (existTimer.Count()){
            GetComponent<Animator>().Play("Death");
        }

    }
    public void EndExplode(){
        Destroy(this.gameObject);
    }
}
