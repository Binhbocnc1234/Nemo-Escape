using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Wave : MonoBehaviour{
    public List<GameObject> fishInLevel = new List<GameObject>();

    protected static Wave instance;
    public static Wave Instance{ get => instance; }

    // Field
    // public int level;
    public float time_count = 0.75f;
    public GameObject container;
    Timer timer;
    
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
        timer = new Timer(time_count);
    }

    public void Update(){
        Spawn();

    }

    protected GameObject GetRandomObject(List<GameObject> objects){

        
        int n = objects.Count;

        // Debug.Log(n);

        // int closestIndex = Mathf.Clamp(Player.Instance.level - 1, 0, n - 1);
        int player_level = Player.Instance.level;
        int closestIndex = 0;
        int diff = 10000001;

        for(int i = 0; i < n; i++){

            int fish_lvel = objects[i].GetComponent<Fish>().level;

            if(diff > System.Math.Abs(player_level - fish_lvel) || (diff == System.Math.Abs(player_level - fish_lvel) && player_level > fish_lvel)){
                closestIndex = i;
                diff = System.Math.Abs(player_level - fish_lvel);
            }

        }

        // Debug.Log(Player.Instance.level);
        // Debug.Log(closestIndex);
        float sum = 60f;
        float[] percent = new float[n];
        percent[closestIndex] = 60f;

        for(int i = 0; i < closestIndex; i++){
            percent[i] = 10f;
            sum += 10f;
        }

        for(int i = closestIndex + 1; i < n; i++){
            percent[i] = 20f;
            sum += 20f;
        }

        // Random chọn GameObject theo tỷ lệ
        float randomValue = Random.Range(0f, sum);
        float cumulative = 0f;

        for (int i = 0; i < n; i++){
            cumulative += percent[i];
            if (randomValue <= cumulative){
                // Debug.Log(i);
                return objects[i];
            }
        }

        return objects[0]; 
    }

    
    protected void Spawn(){
        RandomModule randoms = new RandomModule();
        if(timer.Count()){
            // Debug.Log("Spawn");
            GameObject random = GetRandomObject(fishInLevel);
            var instance = GameManager.Instance; 
            Transform fishContainer = ObjectRef.Instance.fishContainer;
            float random_Y = randoms.RandomBetween(instance.minBounds.y, instance.maxBounds.y);
            // Random point to be spawn, left or right
            if(randoms.RadomOneTwo()){
                Vector3 pos = new Vector3(instance.minBounds.x - 2, random_Y, 0f);
                GameObject clone = Instantiate(random, pos, Quaternion.identity, fishContainer);

                Fish cloneScript = clone.GetComponent<Fish>();
                cloneScript.SetMainDirection(true);
                if(cloneScript.Fish_child != null){
                    for(int i = 0; i < 3; i++){
                        GameObject cloneChild = Instantiate(cloneScript.Fish_child, pos, Quaternion.identity, fishContainer);
                        cloneChild.GetComponent<Fish>().fishState = FishState.Follow;
                        cloneChild.GetComponent<Fish>().Fish_boss = clone;
                    }
                }
            }   
            else{
                Vector3 pos = new Vector3(instance.maxBounds.x + 2, random_Y, 0f);
                GameObject clone = Instantiate(random, pos, Quaternion.identity, fishContainer);

                Fish cloneScript = clone.GetComponent<Fish>();
                cloneScript.SetMainDirection(false);
                if(cloneScript.Fish_child != null){
                    for(int i = 0; i < 3; i++){
                        GameObject cloneChild = Instantiate(cloneScript.Fish_child, pos, Quaternion.identity, fishContainer);
                        cloneChild.GetComponent<Fish>().fishState = FishState.Follow;
                        cloneChild.GetComponent<Fish>().Fish_boss = clone;
                    }
                }
            }

        }

    }

}
    


