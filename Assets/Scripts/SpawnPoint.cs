using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject _enemy;

    public GameObject enemyPrefab;

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = transform.position;
            _enemy.transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
}
