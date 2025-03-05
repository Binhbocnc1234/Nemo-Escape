using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>{
    public int level;
    List<Level> levelContainer;
    public Vector2 minBounds = new Vector2(-10f, -5f); // Minimum X, Y position
    public Vector2 maxBounds = new Vector2(10f, 5f);  // Maximum X, Y position
    //Saved data
    [HideInInspector] public string playerName;
    [HideInInspector] public int completedLevel;
    void Start(){
        playerName = PlayerPrefs.GetString("name", "");
        levelContainer = new List<Level>(){
            new Level("Bumble fish tank", 500, Creature.Neon),
            new Level("Chimelong Ocean Kingdom", 1000, Creature.ElectriclEel),
            new Level("Black Sea", 1500, Creature.KillerWhale)
        };
        string sceneName = $"Level {level} Enviroment";
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!(scene.IsValid() && scene.isLoaded)){
            SceneManager.LoadScene($"Level {level} Enviroment", LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win(){
        PlayerPrefs.SetInt("level", Player.Instance.level);
    }
    public IEnumerator Lose(){
        Debug.Log("Player lose");
        PlayerInfoUI.Instance.gameObject.SetActive(false);
        SceneManager.LoadScene("Sorry", LoadSceneMode.Additive);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Try Again");
        yield return null;
    }
    public void Pause(){
        Time.timeScale = 0;
    }
    public void Resume(){
        Time.timeScale = 1;
    }
    public void Save(){
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("player_level", Player.Instance.level);
        PlayerPrefs.SetString("name", playerName);
    }
    public void Exit(){
        Save();
        Application.Quit();
    }
    public Vector3 RandomPosInBox(){
        return new Vector3(Random.Range(minBounds.x, maxBounds.x), 
            Random.Range(minBounds.y, maxBounds.y), 0);
    }
}
