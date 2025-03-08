using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatableFishUI : MonoBehaviour
{
    Image img;
    public GameObject container;
    void Start(){
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update(){
        SpriteRenderer ren = GetBestFish().ren;
        img.sprite = ren.sprite;
        img.color = ren.color;
    }
    public Fish GetBestFish(){
        Fish highestFish = null;
        foreach(Transform child in container.transform){
            Fish f = child.GetComponent<Fish>();
            if (f.level <= Player.Instance.level){
                if (highestFish == null || highestFish.level < f.level){
                    highestFish = f;
                }
            }
        }
        return highestFish;
    }
}
