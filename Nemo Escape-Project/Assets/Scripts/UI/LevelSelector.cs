using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int completedLevel;
    void Start()
    {
        completedLevel = PlayerPrefs.GetInt("level", 1);
        int cnt = 1;
        foreach(Transform child in this.transform){
            if (cnt <= completedLevel){
                child.GetComponent<Button>().interactable = true;
            }
            else{
                child.GetComponent<Button>().interactable = false;
            }
            ++cnt;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterLevel(int level){
        SceneManager.LoadScene($"Level{level}");
    }
}
