using UnityEngine;

public class HarmonicOscillation : MonoBehaviour
{
    public float A = 2f;   // Maximum displacement
    public float f = 1f;   // Oscillations per second
    public Vector3 axis = Vector3.up; // Axis of oscillation
    public float x;
    public bool isPosition = false, isSize = false;
    public Vector3 initPos;
    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        x = A * Mathf.Sin(2 * Mathf.PI * f * Time.time);
        if (isPosition){
            transform.position = initPos + (axis*x);
        }
    }
}
