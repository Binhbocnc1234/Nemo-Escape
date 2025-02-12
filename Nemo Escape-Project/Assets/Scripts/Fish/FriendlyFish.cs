using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFish : MonoBehaviour
{
    public Vector3 target, oldTarget;
    void Start(){

    }
    void SetNewTarget()
    {
        const float targetDistance = 4f;
        const float maxAngle = 30f;

        // Try to find a suitable new target
        for (int i = 0; i < 100; i++) // Limit attempts to avoid infinite loops
        {
            // Choose a random angle in radians
            float randomAngle = Random.Range(0, 2 * Mathf.PI);

            // Calculate new potential target position
            Vector3 newTarget = target + new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0) * targetDistance;

            // Calculate vectors
            Vector3 targetToOld = (target - oldTarget).normalized;
            Vector3 newToTarget = (newTarget - target).normalized;

            // Calculate angle between the vectors
            float angle = Vector3.Angle(targetToOld, newToTarget);

            // Check if the angle is within the allowed range
            if (angle <= maxAngle)
            {
                oldTarget = target;
                target = newTarget;
                return; // Exit once a valid target is found
            }
        }

        Debug.LogWarning("Failed to find a suitable new target after 100 attempts.");
    }

}
