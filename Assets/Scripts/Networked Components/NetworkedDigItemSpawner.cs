using UnityEngine;
using Mirror;

public class NetworkedDigItemSpawner : NetworkBehaviour
{
    [SerializeField]
    private NetworkedDigItem digItemPrefab;

    private float nextSpawn = 5f;

    public override void OnStartServer()
    {
        nextSpawn = (float)NetworkTime.time + 5f;
    }

    private void Update()
    {
        if (isServer)
        {
            if (NetworkTime.time > nextSpawn)
            {
                nextSpawn = (float)NetworkTime.time + Random.Range(1f, 2f + 50 / Time.time);
                SpawnDigItem();
            }
        }
    }

    private void SpawnDigItem()
    {
        var item = Instantiate(digItemPrefab);
        item.transform.position = new Vector3(Random.Range(1, 28), 0.5f, Random.Range(1, 28));
        NetworkServer.Spawn(item.gameObject);
    }
}
