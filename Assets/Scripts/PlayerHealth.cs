using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }
}
