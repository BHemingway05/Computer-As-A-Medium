// Health Pickup
using UnityEngine;
public class HealthPickup : MonoBehaviour
{
    public PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth.health == 100) return;
            else
            {
                playerHealth.health += 10;
                Destroy(gameObject);
            }
        }
    }
}


// Trap Modification (SetActive)
using UnityEngine;
public class Trap : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject hurt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.health -= 10;
            hurt.SetActive(true);
        }
    }
}