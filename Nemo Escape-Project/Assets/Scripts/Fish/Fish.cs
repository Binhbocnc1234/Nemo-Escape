using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishState{
    Idle,
    Attack,
    Escape,
    Eat,
    Bored,
}
/// <summary>
/// A script used by Nemo and other fish
/// </summary>
public partial class Fish : MonoBehaviour{
    public Creature type;
    public int level;
    public int score; //Điểm ghi được khi bị Nemo ăn
    public float speed, range; //range: tầm phát hiện của Fish

    public SpriteRenderer ren;
    public Animator animator;
    public GameObject mouth;

    [HideInInspector] public FishState fishState = FishState.Idle;
    Vector2 diff; //different between Player and this Fish
    public Vector2 dir = Vector2.zero;
    
    void Start(){
        if (dir == null)
            dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    } 
    // Update is called once per frame
    void Update(){
        if (CheckOutOfBound()){Destroy(this.gameObject);}
        if (Player.Instance == null){
            ChillFish();
            return;
        }
        switch(fishState){
            case FishState.Bored:
                Move(1.5f);
                break;
            case FishState.Eat:
                animator.Play("Eat");
                break;
            case FishState.Idle:
                HandlingState();
                ChillFish();
                break;
            case FishState.Attack:
                Attack();
                break;
            case FishState.Escape:
                Escape();
                break;
        }
        StartCoroutine(SelfDestroy(8));
        CheckNemo();
    }
    bool CheckOutOfBound(int tolerance = 3){
        Vector3 pos = transform.position;
        GameManager g = GameManager.Instance;
        if (pos.x < g.minBounds.x - tolerance || pos.x > g.maxBounds.x + tolerance ||
        pos.y < g.minBounds.y - tolerance || pos.y > g.maxBounds.y + tolerance){
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
        transform.Translate(dir.normalized*Time.deltaTime*speed);
        if (dir.x > 0) // Moving right
        {
            Vector3 oldScale = transform.localScale;
            if (oldScale.x < 0) // If facing left, flip to right
            {
                oldScale.x *= -1;
            }
            transform.localScale = oldScale;
        }
        else if (dir.x < 0) // Moving left
        {
            Vector3 oldScale = transform.localScale;
            if (oldScale.x > 0) // If facing right, flip to left
            {
                oldScale.x *= -1;
            }
            transform.localScale = oldScale;
        }

    }
    public void SetMainDirection(bool isMoveToTheRight){
        if (isMoveToTheRight){
            dir = new Vector3(5, 0, 0);
        }
        else{
            dir = new Vector3(-5, 0, 0);
        }
    }
    IEnumerator SelfDestroy(int time){
        yield return new WaitForSeconds(time);
        fishState = FishState.Bored;
    }

}
