using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishState{
    Idle,
    Attack,
    Escape
}
/// <summary>
/// A script used by Nemo and other fish
/// </summary>
public partial class Fish : MonoBehaviour
{
    public GameObject Nemo;
    public int level;
    public int score; //Điểm ghi được khi bị Nemo ăn
    public float speed, range; //range: tầm phát hiện của Fish
    [HideInInspector] public FishState fishState = FishState.Idle;
    Vector3 diff; //different between Player and this Fish
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckOutOfBound()){Destroy(this.gameObject);}
        HandlingState();
        Debug.Log(fishState);
        switch(fishState){
            case FishState.Idle:
                ChillFish();
                break;
            case FishState.Attack:
                Attack();
                break;
            case FishState.Escape:
                Escape();
                break;
        }
    }
    bool CheckOutOfBound(int tolerance = 3){
        Vector3 pos = transform.position;
        GameManager g = GameManager.Instance;
        if ((pos.x < g.minBounds.x - tolerance && pos.x > g.maxBounds.x + tolerance) ||
        (pos.y < g.minBounds.y - tolerance && pos.y > g.maxBounds.y + tolerance)){
            return true;
        }
        return false;
    }
    void HandlingState(){
        diff = Player.Instance.transform.position - this.transform.position;
        if (diff.magnitude <= range){
            if (level <= Player.Instance.level){
                fishState = FishState.Escape;
            }
            else{
                fishState = FishState.Attack;
            }
        }
        else{
            fishState = FishState.Idle;
        }
    }
    void Move(float multiplier = 1f){
        transform.Translate(direction.normalized*Time.deltaTime*speed);
        if (direction.x > 0)
        {
            Vector3 oldScale = transform.localScale;
            if (oldScale.x > 0){
                oldScale.x *= -1;
            }
            transform.localScale = oldScale;
        }
        else if (direction.x < 0)
        {
            Vector3 oldScale = transform.localScale;
            if (oldScale.x < 0){
                oldScale.x *= -1;
            }
            transform.localScale = oldScale;
        }
    }



}
