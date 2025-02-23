using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Entity))]
public class Player : Singleton<Player>{
    public int level;
    public float speed = 5f;
    public float drag = 2f;
    [HideInInspector] public int exp = 0;

    public int healthLoss = 1;
    Timer healthLossTimer = new Timer(1);

    public SpriteRenderer ren;
    public Animator animator;
    Entity entity;

    private Vector2 dir;
    private Queue<Vector2> movementHistory = new Queue<Vector2>();
    private Queue<float> timeStamps = new Queue<float>();
    private float recordTime = 0.25f; // 0.5 seconds delay
    //State
    [HideInInspector] public bool isTurnAround = false, isEating = false;
    void Start(){
        entity = GetComponent<Entity>(); //Entity bị trùng với SetLevel
        SetLevel(PlayerPrefs.GetInt("level", 1));
    }
    void Update()
    {
        if (healthLossTimer.Count()){
            entity.TakeDamage(healthLoss);
        }
        RecordMovement();
        Move();
        ClampPosition(); // Ensure the player stays inside the bounds
        HandlingRenderer();
        
    }
    void RecordMovement(){
        // Get input from W, A, S, D
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input != Vector2.zero)
        {
            // Accelerate in the input direction
            dir = input.normalized;
        }
        else
        {
            // Apply water resistance (gradual slow down)
            dir = Vector2.Lerp(dir, Vector2.zero, drag * Time.deltaTime);
        }
        movementHistory.Enqueue(dir);
        timeStamps.Enqueue(Time.time);

        // Remove old movements older than 0.5s
        while (timeStamps.Count > 0 && Time.time - timeStamps.Peek() > recordTime)
        {
            movementHistory.Dequeue();
            timeStamps.Dequeue();
        }
    }
    void Move()
    {
        transform.position += new Vector3(dir.x, dir.y, 0)*speed*Time.deltaTime;
    }

    void ClampPosition(){
        // Restrict the player's position within the defined bounds
        GameManager g = GameManager.Instance;
        float clampedX = Mathf.Clamp(transform.position.x, g.minBounds.x, g.maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, g.minBounds.y, g.maxBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    void HandlingRenderer(){
        if (dir.x > 0) // Moving right
        {
            Vector3 oldScale = ren.transform.localScale;
            if (oldScale.x < 0) // If facing left, flip to right
            {
                oldScale.x *= -1;
            }
            ren.transform.localScale = oldScale;
        }
        else if (dir.x < 0) // Moving left
        {
            Vector3 oldScale = ren.transform.localScale;
            if (oldScale.x > 0) // If facing right, flip to left
            {
                oldScale.x *= -1;
            }
            ren.transform.localScale = oldScale;
        }

        if (dir.x*movementHistory.Peek().x < 0){
            animator.Play("Turn around");
            isTurnAround = true;
        }
        if (isTurnAround){
            animator.Play("Turn around");
        }
        else if (isEating){
            animator.Play("Eat");
        }
        else{
            animator.Play("Idle");
        }
    }
    public void SetLevel(int level){
        level = Mathf.Max(1, level);
        this.level  = level;
        transform.localScale *= level;
        if (entity == null){
            Debug.LogError("Null ref");
        }
        entity.SetMaxHealth(level*100);
    }
}
