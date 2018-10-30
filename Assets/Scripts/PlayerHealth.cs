using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    private FirstPersonController firstPersonController;
    private RayShooter rayShooter;

    public int health = 100;
    public Text gameOverMessage;
    public Text healthStatus;

    private void OnGUI()
    {
        healthStatus.text = "Health: " + health;
    }

    private void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        rayShooter = GetComponent<RayShooter>();
    }

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            firstPersonController.dead = true;
            rayShooter.dead = true;

            healthStatus.text = "Health: 0";

            gameOverMessage.enabled = true;
        }
    }

    public void Heal(int health)
    {
        this.health += health;
    }
}
