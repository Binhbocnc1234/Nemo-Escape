using UnityEngine;

public class MyCamera : MonoBehaviour
{
    Player player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothSpeed = 5f; // Adjust this for smoother or faster movement
    void Start(){
        player = Player.Instance;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
