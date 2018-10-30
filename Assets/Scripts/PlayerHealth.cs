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

    // private void OnGUI()
    // {
    //     healthStatus.text = "Health: " + health;
    // }

    private void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        rayShooter = transform.Find("Character").GetComponent<RayShooter>();
        gameOverMessage.enabled = false;

        healthStatus.text = "Health: " + health;
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
        else
        {
            healthStatus.text = "Health: " + health;
        }
    }

    public void Heal(int health)
    {
        this.health += health;
        healthStatus.text = "Health: " + this.health;
    }

    public void Reset()
    {
        firstPersonController.dead = false;
        gameOverMessage.enabled = false;
        health = 100;
        rayShooter.dead = false;
    }
}
