using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoUI : Singleton<PlayerInfoUI>
{
    public Scrollbar healthBar, expBar;
    private Player pl;
    void Start(){
        pl = Player.Instance;
    }
    void Update(){

        healthBar.size = pl.GetComponent<Entity>().GetPercent();
        expBar.GetComponent<ScrollBarTrigger>().ChangeSize(pl.exp/((float)pl.max_exp));
    }
}
