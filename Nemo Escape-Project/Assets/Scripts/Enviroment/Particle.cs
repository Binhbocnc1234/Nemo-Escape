using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float existTime;
    public float speed;
    public Timer existTimer;
    UniformMotion motion;
    SpriteRenderer ren;
    Color currentColor;
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
        currentColor = ren.color;
        motion = GetComponent<UniformMotion>();
        existTimer = new Timer(existTime);
        motion.SetRandomDirection(speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (existTimer.Count(false)){
            currentColor.a -= Time.deltaTime;
            if (currentColor.a <= 0){
                Destroy(this.gameObject);
            }
            else{
                ren.color = currentColor;
            }
        }
    }
}
