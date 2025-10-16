using UnityEngine;

public class Cell_Behavior : MonoBehaviour
{
    [Header("Cell Properties")]
    public float mass = 1f;
    public float baseSpeed = 5f;
    public float currentSpeed;
    
    [Header("Growth Settings")]
    public int massPerPellet = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateCellSize();
    }

    void Update()
    {
        UpdateSpeed();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            EatPellet(collision.gameObject);
        }
    }
    
    void EatPellet(GameObject pellet)
    {
        // Increase mass
        mass += massPerPellet;
        
        // Update cell size
        UpdateCellSize();
        
        // Destroy the eaten pellet
        Destroy(pellet);
    }
    
    void UpdateCellSize()
    {
        // Scale cell based on mass
        float scale = Mathf.Sqrt(mass);
        transform.localScale = Vector3.one * scale;
    }
    
    void UpdateSpeed()
    {
        currentSpeed = baseSpeed / Mathf.Sqrt(mass);
    }
}
