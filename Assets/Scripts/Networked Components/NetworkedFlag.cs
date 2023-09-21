using UnityEngine;
using Mirror;

public class NetworkedFlag : NetworkBehaviour
{
    [SerializeField] private Transform cloth;

    [SerializeField] private float regularClothHeight;
    [SerializeField] private float loseClothHeight;

    [SyncVar]
    private bool isLost = false;

    private void Update()
    {
        if (isClient)
        {
            cloth.transform.position = new Vector3(
            cloth.transform.position.x,
            Mathf.MoveTowards(
                cloth.transform.position.y,
                isLost ? loseClothHeight : regularClothHeight,
                Time.deltaTime),
            transform.position.z
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isServer)
        {
            if (other.TryGetComponent(out NetworkedEnemy _))
            {
                isLost = true;
            }
        }
    }
}
