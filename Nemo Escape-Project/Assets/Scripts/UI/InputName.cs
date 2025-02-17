using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : Singleton<InputName>
{
    public TMP_Text tmp;
    void Start(){
        tmp.text = PlayerPrefs.GetString("name", "");
    }
    void Update(){
        PlayerPrefs.SetString("name", tmp.text);
    }
}
