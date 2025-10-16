using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float cameraFollowSpeed = 2f;
    public Vector3 cameraOffset = new Vector3(0, 0, -10);
    public float cameraZoomSpeed = 2f;
    
    private Cell_Behavior cellBehavior;

    void Start()
    {
        cellBehavior = GetComponent<Cell_Behavior>();
    }

    void Update()
    {
        Vector2 input = Input.mousePosition;
        
        // Convert screen position to world position at the same Z depth as the object
        Vector3 screenPos = new Vector3(input.x, input.y, cam.WorldToScreenPoint(transform.position).z);
        Vector3 worldInput = cam.ScreenToWorldPoint(screenPos);

        // Move using cell's current speed (affected by mass)
        transform.position = Vector3.MoveTowards(transform.position, worldInput, cellBehavior.currentSpeed * Time.deltaTime);
        
        // Update camera position and zoom
        UpdateCameraPosition();
    }
    
    void UpdateCameraPosition()
    {
        // Calculate zoom distance based on cell mass
        float cellScale = Mathf.Sqrt(cellBehavior.mass);
        float targetZoom = -10f - (cellScale * 2f);  // Zoom out as cell grows
        
        // Make camera follow the object with dynamic zoom
        Vector3 targetCameraPosition = transform.position + new Vector3(0, 0, targetZoom);
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetCameraPosition, cameraFollowSpeed * Time.deltaTime);
    }
}
