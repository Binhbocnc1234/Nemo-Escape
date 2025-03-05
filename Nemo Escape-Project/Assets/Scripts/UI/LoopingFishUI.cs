using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopingFishUI : MonoBehaviour
{
    GridLayoutGroup grid;
    RectTransform rectTrans;
    public float speed;
    float initX;
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();
        rectTrans = GetComponent<RectTransform>();
        initX = rectTrans.anchoredPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos =  rectTrans.anchoredPosition;
        pos.x += speed*Time.deltaTime;
        
        if (speed > 0 && pos.x >= initX + grid.cellSize.x + grid.spacing.x){
            pos.x = initX;
        }
        else if (speed < 0 && pos.x <= initX - grid.cellSize.x - grid.spacing.x){
            pos.x = initX;
        }
        rectTrans.anchoredPosition = pos;
    }

}
