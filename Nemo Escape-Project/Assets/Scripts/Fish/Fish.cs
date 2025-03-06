using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishState{
    Idle,
    Attack,
    Escape,
    Eat,
    Bored,
    Follow,
}

/// <summary>
/// A script used by Nemo and other fish
/// </summary>
public partial class Fish : MonoBehaviour{
    public Creature type;
    public int level;
    public int score; //Điểm ghi được khi bị Nemo ăn
    public float speed, range; //range: tầm phát hiện của Fish

    public GameObject Fish_boss; // If in follow state, transform will move to this object 
    public GameObject Fish_child = null;

    public SpriteRenderer ren;
    public Animator animator;
    public GameObject mouth;

    [HideInInspector] public FishState fishState = FishState.Idle;
    Vector2 diff; //different between Player and this Fish
    public Vector2 dir = Vector2.zero;
    private Vector3 offset;
    
    public virtual void Start(){
        if (dir == null)
            dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        
        // Giữ offset cố định thay vì random mỗi frame
        offset = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);
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
            case FishState.Follow:
                HandlingState(FishState.Follow);
                FollowBoss();
                break;
            case FishState.Idle:
                HandlingState(FishState.Idle);
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
    void HandlingState(FishState defau){
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
            fishState = defau;
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

    void FollowBoss()
    {
        if ( System.Object.ReferenceEquals(Fish_boss, null) || Fish_boss == null )
        {
            Destroy(this.gameObject);
            return;
        }

        float minDistance = 2.5f;
        Vector2 bossPos = Fish_boss.transform.position;
        Vector2 currentPos = transform.position;

        Vector2 directionToBoss = (bossPos - currentPos).normalized;
        float distanceToBoss = Vector2.Distance(bossPos, currentPos);

        Fish bossScript = Fish_boss.GetComponent<Fish>();
        float bossSpeed = bossScript != null ? bossScript.speed : speed;

        // Giảm offset khi gần đến boss
        float distanceFactor = Mathf.Clamp01(distanceToBoss / 5.0f);
        Vector3 finalOffset = distanceToBoss > 2.0f ? offset * distanceFactor : Vector3.zero;

        if (distanceToBoss > minDistance)
        {
            transform.position = Vector2.MoveTowards(currentPos, bossPos + (Vector2)finalOffset, bossSpeed * Time.deltaTime);
        }

        if (directionToBoss.x > 0)
        {
            Vector3 oldScale = transform.localScale;
            oldScale.x = Mathf.Abs(oldScale.x);
            transform.localScale = oldScale;
        }
        else if (directionToBoss.x < 0)
        {
            Vector3 oldScale = transform.localScale;
            oldScale.x = -Mathf.Abs(oldScale.x);
            transform.localScale = oldScale;
        }
    }
}
