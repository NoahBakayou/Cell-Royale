using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet_Spawner : MonoBehaviour
{
    // Random position will be the position we want to place the object
    Vector2 randomPosition;
    public Transform xEnd;
    // xRange the range in the x axis that the object can be placed
    public Transform yEnd;
    // yRange the range in the y axis that the object can be placed
    public Transform origin;
    
    // Reference to the pellet prefab to spawn
    public GameObject pelletPrefab;

    public int numPellets = 1000;
    
    // Bright Agar.io-style colors
    private Color[] brightColors = {
        new Color(1f, 0.2f, 0.2f, 1f),    // Bright Red
        new Color(0.2f, 1f, 0.2f, 1f),    // Bright Green
        new Color(0.2f, 0.2f, 1f, 1f),    // Bright Blue
        new Color(1f, 1f, 0.2f, 1f),      // Bright Yellow
        new Color(1f, 0.2f, 1f, 1f),      // Bright Magenta
        new Color(0.2f, 1f, 1f, 1f),      // Bright Cyan
        new Color(1f, 0.6f, 0.2f, 1f),    // Bright Orange
        new Color(0.6f, 0.2f, 1f, 1f),    // Bright Purple
        new Color(0.2f, 0.8f, 0.2f, 1f),  // Bright Lime
        new Color(1f, 0.4f, 0.4f, 1f)     // Bright Pink
    };

    // Start is called before the first frame update
    void Start()
    {
        // Spawn pellets at random positions
        if (pelletPrefab != null)
        {
            for (int i = 0; i < numPellets; i++)
            {
                // Generate random position for each pellet
                float xPosition = Random.Range(origin.position.x, xEnd.position.x);
                float yPosition = Random.Range(origin.position.y, yEnd.position.y);
                randomPosition = new Vector2(xPosition, yPosition);
                GameObject newPellet = Instantiate(pelletPrefab, randomPosition, Quaternion.identity);
                
                // Assign random bright color to the pellet
                SpriteRenderer pelletRenderer = newPellet.GetComponent<SpriteRenderer>();
                if (pelletRenderer != null)
                {
                    int randomColorIndex = Random.Range(0, brightColors.Length);
                    pelletRenderer.color = brightColors[randomColorIndex];
                }
            }
        }
    }

}