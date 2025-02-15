using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameManager gm;
    public Transform fishBody;
    public float hor, rot;
    public bool turnAround;
    public bool turnAround1;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gm = GameManager.Instance;
        StartCoroutine(RandomMovement());
    }


    void Update()
    {
        ConstrainPosition();
        
    }

    void FixedUpdate()
    {

            if(turnAround1){
                rb2d.velocity = (hor * transform.up * _speed);
            }
            else if(turnAround){
                rb2d.velocity = (hor * transform.right * _speed);
            }
            else{
                rb2d.velocity = (hor * transform.right * _speed);
            }
            

            if (turnAround)
            {
                rot = 1;
            }

            if (rot != 0)
            {
                transform.Rotate(0, 0, rot * -_rotateSpeed);
            }

    }
    
    IEnumerator RandomMovement()
    {
        while (true)
        {
            hor = 1;
            
            if (turnAround)
            {
                rot = 1;
                yield return new WaitForSeconds(0.5f);
                turnAround = false;
                
            }
            else if(turnAround1){
                rot = -1;
                yield return new WaitForSeconds(0.5f);
                turnAround1 = false;
            }
            else
            {
                CheckBoundsCollision();
                rot = Random.Range(-1, 2);
            }
            
            yield return null;
        }
    }

    void ConstrainPosition()
    {
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, gm.minBounds.x, gm.maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, gm.minBounds.y, gm.maxBounds.y);
        transform.position = clampedPosition;
    }

    void CheckBoundsCollision()
    {
        if ((transform.position.x <= gm.minBounds.x + 3.0f || transform.position.x >= gm.maxBounds.x - 3.0f) )
        {
            turnAround = true;
            
        }
        if ((transform.position.y <= gm.minBounds.y || transform.position.y >= gm.maxBounds.y) )
        {
            turnAround1 = true;
        }
    }
}



