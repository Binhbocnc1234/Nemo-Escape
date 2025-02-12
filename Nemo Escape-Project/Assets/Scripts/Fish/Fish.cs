using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script used by Nemo and other fish
/// </summary>
public class Fish : MonoBehaviour
{
    public int level;
    public int score; //Điểm ghi được khi bị Nemo ăn
    public bool canEat; //Sẽ quyết định cá lành hay cá dữ
    public float speed, range; //range: tầm phát hiện của Fish
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
