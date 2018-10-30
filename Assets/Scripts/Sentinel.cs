using System.Collections;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    private float fireRate = 0.8f;
    private float elapsedTime;
    private GameObject player;
    private PlayerHealth playerHealth;

    public GameObject bullet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 15f)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x,
                    transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);

            if (playerHealth.health > 0)
            {
                if (elapsedTime < fireRate)
                {
                    elapsedTime += Time.deltaTime;
                } else {
                    elapsedTime = 0.0f;
                    StartCoroutine(Shoot());
                }
            }
        }
    }

    private IEnumerator Shoot()
    {
        GameObject projectile = Instantiate(bullet);
        Vector3 position = transform.TransformPoint(Vector3.forward * 1.5f);

        projectile.transform.position = new Vector3(position.x, player.transform.position.y, position.z);
        projectile.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(4);

        Destroy(projectile);
    }
}
