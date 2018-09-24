using UnityEngine;

public class HealthKit : MonoBehaviour
{
    public int health = 50;

    private void OnTriggerEnter(Collider collider)
    {
        PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.Heal(health);
            Destroy(this.gameObject);
        }
    }
}
