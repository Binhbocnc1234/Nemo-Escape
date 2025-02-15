using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoEat : MonoBehaviour
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
            
            if (dist <= eatRadius){
                GameManager.Instance.score += fish.score;
                Player.Instance.GetComponent<Entity>().GetHealth(fish.score);
                Player.Instance.isEating = true;
                Destroy(fish.gameObject);
            }
        }
    }
}
