using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyPrefab;

    private float nextSpawn = 5f;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Random.Range(2f, 4f + 50 / Time.time);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        Vector3 pos = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * 20f
            + new Vector3(15, 0, 15);

        pos = new Vector3(
            Mathf.Clamp(pos.x, 1, 28),
            0,
            Mathf.Clamp(pos.z, 1, 28));

        enemy.transform.position = pos;
    }
}
