using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public GameObject[] points;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name.Equals("Player"))
        {
            collider.gameObject.transform.position = points[Random.Range(0, points.Length)].transform.position;
        }
    }
}
