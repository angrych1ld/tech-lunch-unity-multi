using UnityEngine;

public class DigItemSpawner : MonoBehaviour
{
    [SerializeField]
    private DigItem digItemPrefab;

    private float nextSpawn = 5f;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Random.Range(1f, 2f + 50 / Time.time);
            SpawnDigItem();
        }
    }

    private void SpawnDigItem()
    {
        var item = Instantiate(digItemPrefab);
        item.transform.position = new Vector3(Random.Range(1, 28), 0.5f, Random.Range(1, 28));
    }
}
