using UnityEngine;
using System.Collections.Generic;

public class Player : Singleton<Player>{
    public float speed = 5f;
    public float drag = 2f;

    public SpriteRenderer ren;
    public Animator animator;

    private Vector2 velocity;
    private Queue<Vector2> movementHistory = new Queue<Vector2>();
    private Queue<float> timeStamps = new Queue<float>();
    private float recordTime = 0.25f; // 0.5 seconds delay
    //State
    [HideInInspector] public bool isTurnAround = false;
    void Update()
    {
        
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
            velocity = input.normalized * speed;
        }
        else
        {
            // Apply water resistance (gradual slow down)
            velocity = Vector2.Lerp(velocity, Vector2.zero, drag * Time.deltaTime);
        }
        movementHistory.Enqueue(velocity);
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
        transform.position += new Vector3(velocity.x, velocity.y, 0) *  Time.deltaTime;
    }

    void ClampPosition()
    {
        // Restrict the player's position within the defined bounds
        GameManager g = GameManager.Instance;
        float clampedX = Mathf.Clamp(transform.position.x, g.minBounds.x, g.maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, g.minBounds.y, g.maxBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    void HandlingRenderer(){
        if (velocity.x > 0)
        {
            ren.flipX = true;
        }
        else if (velocity.x < 0)
        {
            ren.flipX = false;
        }
        if (velocity.x*movementHistory.Peek().x < 0){
            animator.Play("Turn around");
            isTurnAround = true;
        }
        if (isTurnAround){
            animator.Play("Turn around");
        }
        else{
            animator.Play("Idle");
        }
    }
    void ToLevel(int level){
        
    }
}
