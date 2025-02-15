using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public Transform prefab;
    public float delay = 0.3f;
    Timer timer;
    GameManager g;
    void Start(){
        g = GameManager.Instance;
        timer = new Timer(delay);
    }
    void Update(){
        if (timer.Count()){
            Transform particle = Instantiate(prefab, g.RandomPosInBox(), Quaternion.identity, this.transform);
            particle.gameObject.SetActive(true);
        }
    }
}
