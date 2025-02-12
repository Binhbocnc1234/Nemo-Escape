using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int score;
    
    public Vector2 minBounds = new Vector2(-10f, -5f); // Minimum X, Y position
    public Vector2 maxBounds = new Vector2(10f, 5f);  // Maximum X, Y position
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win(){

    }
    public void Lose(){

    }
    public void Pause(){
        Time.timeScale = 0;
    }
    public void Resume(){
        Time.timeScale = 1;
    }
}
