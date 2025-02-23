using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;




public class Wave : MonoBehaviour{

    int[] chance = new int[4] {10, 20, 30, 40};
    


    protected List<GameObject> level1 = new List<GameObject>();
    protected List<GameObject> level2 = new List<GameObject>();
    protected List<GameObject> level3 = new List<GameObject>();

    protected static Wave instance;
    public static Wave Instance{ get => instance; }

    // Field
    public int level;
    
    // When you click choose level button, it'll call singleton to change WaveLevel
    [HideInInspector] public int waveLevel = 1;

    // Click button
    public void ChooseSate(int levelIndex){
        
        this.waveLevel = levelIndex;

    }

    protected void Awake(){
    
        if (instance == null){
            instance = this;
        }
          
    }

    public void Start(){

        Spawn();

    }

    protected GameObject GetRandomObject(List<GameObject> objects){
        int closestIndex = Mathf.Clamp(Player.Instance.level - 1, 0, 3);

        float[] percent = new float[4] { 20f, 20f, 20f, 20f };
        percent[closestIndex] = 40f;

        // Random chọn GameObject theo tỷ lệ
        float randomValue = Random.Range(0f, 100f);
        float cumulative = 0f;

        for (int i = 0; i < 4; i++){
            cumulative += percent[i];
            if (randomValue <= cumulative){
                return objects[i];
            }
        }

        return objects[0]; 
    }

    
    protected void Spawn(){

        switch(waveLevel){
            // Fish tank
            case 1:
                Timer timer = new Timer(1f);
                RandomModule randoms = new RandomModule();
                while(Player.Instance.level < 5){
                    if(timer.Count()){
                        Debug.Log("Spawn");
                        GameObject random = GetRandomObject(level1);
                        // Random point to be spawn, left or right
                        if(randoms.RadomOneTwo()){
                            var instance = GameManager.Instance; 
                            float random_Y = randoms.RandomBetween(instance.minBounds.y, instance.maxBounds.y);
                            Vector3 pos = new Vector3(instance.minBounds.x, random_Y, 0f);
                            GameObject clone = Instantiate(random, pos, Quaternion.identity);
                        }
                        else{
                            var instance = GameManager.Instance; 
                            float random_Y = randoms.RandomBetween(instance.minBounds.y, instance.maxBounds.y);
                            Vector3 pos = new Vector3(instance.maxBounds.x, random_Y, 0f);
                            GameObject clone = Instantiate(random, pos, Quaternion.identity);
                        }

                    }
                }

                // EndState here
                break;

            case 2:

                break;
            case 3:

                break;
        }



    }




}
