using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Reset : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerHealth>().Reset();
            player.transform.position = new Vector3(-20, 1, -20);
        }
    }
}
