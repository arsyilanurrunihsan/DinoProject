using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek yang diikuti (pemain)
    public Vector2 minLimit; // Batas minimum (X,Y)
    public Vector2 maxLimit; // Batas maksimum (X,Y)
    public float smoothSpeed; // Kehalusan gerakan kamera

    private void LateUpdate()
    {
        if (target == null) return;

        // Posisi target
        Vector3 targetPosition = target.position;

        // Batasi posisi kamera dalam rentang minLimit dan maxLimit
        float clampedX = Mathf.Clamp(targetPosition.x, minLimit.x, maxLimit.x);
        float clampedY = Mathf.Clamp(targetPosition.y, minLimit.y, maxLimit.y);

        // Posisi kamera yang diperhalus
        Vector3 smoothPosition = Vector3.Lerp(transform.position, 
        new Vector3(clampedX, clampedY, transform.position.z), smoothSpeed);
        
        // Terapkan ke kamera
        transform.position = smoothPosition;
    }
}
