using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatableFishUI : MonoBehaviour
{
    Image img;
    void Start(){
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update(){
        SpriteRenderer ren = Wave.Instance.GetBestFish().ren;
        img.sprite = ren.sprite;
        img.color = ren.color;
    }
}
