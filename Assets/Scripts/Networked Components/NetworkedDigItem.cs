using UnityEngine;
using Mirror;

public class NetworkedDigItem : NetworkBehaviour
{
    private bool hasCharge = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer)
        {
            return;
        }

        if (!hasCharge)
        {
            return;
        }

        if (other.TryGetComponent(out NetworkedDigger digger))
        {
            hasCharge = false;
            digger.ReceiveCharge();
            Destroy(gameObject);
        }
    }
}
