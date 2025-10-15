using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float speed = 1f;
    public float cameraFollowSpeed = 2f;
    public Vector3 cameraOffset = new Vector3(0, 0, -10);

    void Update()
    {
        Vector2 input = Input.mousePosition;
        
        // Convert screen position to world position at the same Z depth as the object
        Vector3 screenPos = new Vector3(input.x, input.y, cam.WorldToScreenPoint(transform.position).z);
        Vector3 worldInput = cam.ScreenToWorldPoint(screenPos);

        transform.position = Vector3.MoveTowards(transform.position, worldInput, speed * Time.deltaTime);
        
        // Make camera follow the object
        Vector3 targetCameraPosition = transform.position + cameraOffset;
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetCameraPosition, cameraFollowSpeed * Time.deltaTime);
        
    }
}
