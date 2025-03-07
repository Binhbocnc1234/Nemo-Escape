using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{
    Win, Lose, Play
}
public class GameManager : Singleton<GameManager>{
    public int game_level;
    public bool fastPaced = false;
    [HideInInspector] GameState gameState  = GameState.Play;
    List<Level> levelContainer;
    public Vector2 minBounds = new Vector2(-10f, -5f); // Minimum X, Y position
    public Vector2 maxBounds = new Vector2(10f, 5f);  // Maximum X, Y position
    //Saved data
    [HideInInspector] public string playerName;
    [HideInInspector] public int completedLevel;
    void Start(){
        playerName = PlayerPrefs.GetString("name", "");
        levelContainer = new List<Level>(){
            new Level("Bumble fish tank", 5, Creature.Neon, 1),
            new Level("Chimelong Ocean Kingdom", 10, Creature.ElectriclEel, 5),
            new Level("Black Sea", 15, Creature.KillerWhale, 10)
        };
        Player.Instance.SetLevel(levelContainer[game_level-1].initLevel);
        string sceneName = $"Level {game_level} Enviroment";
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!(scene.IsValid() && scene.isLoaded)){
            SceneManager.LoadScene($"Level {game_level} Enviroment", LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameState == GameState.Play && Player.Instance.level >= levelContainer[game_level-1].requiredLevel){
            StartCoroutine(Win());
        }
    }
    public IEnumerator Win(){
        PlayerPrefs.SetInt("level", game_level + 1);
        Debug.Log("Player Win");
        gameState = GameState.Win;
        Wave.Instance.gameObject.SetActive(false);
        PlayerInfoUI.Instance.gameObject.SetActive(false);
        SceneManager.LoadScene("Stage Clear", LoadSceneMode.Additive);
        foreach(Transform child in ObjectRef.Instance.transform){
            Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene($"Level {game_level} ending");

    }
    public IEnumerator Lose(){
        Debug.Log("Player lose");
        gameState = GameState.Lose;
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
        PlayerPrefs.SetInt("level", game_level);
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
