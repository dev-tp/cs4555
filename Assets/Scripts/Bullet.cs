using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 40;

    private void OnTriggerEnter(Collider collider)
    {
        PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.Damage(damage);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
