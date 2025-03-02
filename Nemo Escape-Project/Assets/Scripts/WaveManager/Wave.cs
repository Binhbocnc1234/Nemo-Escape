using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;




public class Wave : MonoBehaviour{
    public List<GameObject> level1 = new List<GameObject>();
    protected List<GameObject> level2 = new List<GameObject>();
    protected List<GameObject> level3 = new List<GameObject>();

    protected static Wave instance;
    public static Wave Instance{ get => instance; }

    // Field
    public int level;
    public float time_count = 1f;
    public GameObject container;
    Timer timer = new Timer(1f);
    
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

    void Add(string s, List<GameObject> list_entity){
        Transform child = container.transform.Find(s); 

        foreach (Transform c in child){
            list_entity.Add(c.gameObject);
        }

    }
    public void Start(){

        
        Add("Level1", level1);
        // Add("Level2", level2);
        // Add("Level3", level3);

       

    }

    public void Update(){

        Spawn();

    }

    protected GameObject GetRandomObject(List<GameObject> objects){
        int closestIndex = Mathf.Clamp(Player.Instance.level - 1, 0, 3);

        Debug.Log(Player.Instance.level);
        Debug.Log(closestIndex);

        float[] percent = new float[4] { 10f, 10f, 10f, 10f };
        percent[closestIndex] = 70f;

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
                RandomModule randoms = new RandomModule();
                if(Player.Instance.level < 5){
                    if(timer.Count()){
                        // Debug.Log("Spawn");
                        GameObject random = GetRandomObject(level1);
                        var instance = GameManager.Instance; 
                        Transform fishContainer = ObjectRef.Instance.fishContainer;
                        float random_Y = randoms.RandomBetween(instance.minBounds.y, instance.maxBounds.y);
                        // Random point to be spawn, left or right
                        if(randoms.RadomOneTwo()){
                            Vector3 pos = new Vector3(instance.minBounds.x, random_Y, 0f);
                            GameObject clone = Instantiate(random, pos, Quaternion.identity, fishContainer);
                            clone.GetComponent<Fish>().SetMainDirection(true);
                        }
                        else{
                            Vector3 pos = new Vector3(instance.maxBounds.x, random_Y, 0f);
                            GameObject clone = Instantiate(random, pos, Quaternion.identity, fishContainer);
                            clone.GetComponent<Fish>().SetMainDirection(false);
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
