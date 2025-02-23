using UnityEngine;

public class HarmonicOscillation : MonoBehaviour
{
    public float A = 2f;   // Maximum displacement
    public float f = 1f;   // Oscillations per second
    public Vector3 axis = Vector3.up; // Axis of oscillation
    public float x;
    void Start()
    {
        
    }

    void Update()
    {
        x = A * Mathf.Sin(2 * Mathf.PI * f * Time.time);
        
    }
}
