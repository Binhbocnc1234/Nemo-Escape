using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    public Scrollbar healthBar;
    public TMP_Text score;
    private Player pl;
    void Start(){
        pl = Player.Instance;
    }
    void Update(){

        healthBar.size = pl.GetComponent<Entity>().percent;
        score.text = GameManager.Instance.score.ToString();
    }
}
