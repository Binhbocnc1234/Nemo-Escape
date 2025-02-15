using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int score;
    public int level;
    public string playerName;
    List<Level> levelContainer;
    public Vector2 minBounds = new Vector2(-10f, -5f); // Minimum X, Y position
    public Vector2 maxBounds = new Vector2(10f, 5f);  // Maximum X, Y position
    void Start()
    {
        Player.Instance.SetLevel(PlayerPrefs.GetInt("level", 1));
        levelContainer = new List<Level>(){
            new Level("Bumble fish tank", 500, Creature.Neon),
            new Level("Chimelong Ocean Kingdom", 1000, Creature.ElectrilEel),
            new Level("Black Sea", 1500, Creature.KillerWhale)
        };
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win(){
        PlayerPrefs.SetInt("level", Player.Instance.level);
    }
    public void Lose(){

    }
    public void Pause(){
        Time.timeScale = 0;
    }
    public void Resume(){
        Time.timeScale = 1;
    }
    public Vector3 RandomPosInBox(){
        return new Vector3(Random.Range(minBounds.x, maxBounds.x), 
            Random.Range(minBounds.y, maxBounds.y), 0);
    }
}
