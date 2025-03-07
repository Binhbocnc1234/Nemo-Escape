using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoEat : Singleton<NemoEat>
{
    public Transform mouth;
    public float eatRadius = 0.2f;
    private Vector3 mouthPos;
    void Start()
    {
        mouthPos = mouth.position;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in ObjectRef.Instance.fishContainer){
            Fish fish = child.GetComponent<Fish>();
            float dist = Vector3.Distance(child.position, mouth.position);
            // Debug.Log(dist);
            if (fish.level <= Player.Instance.level && dist <= eatRadius){
                Player.Instance.exp += fish.score;
                Player.Instance.GetComponent<Entity>().GetHealth(fish.score/10);
                Player.Instance.isEating = true;
                Destroy(fish.gameObject);
            }
        }
    }
}
