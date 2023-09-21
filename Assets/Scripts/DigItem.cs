using UnityEngine;

public class DigItem : MonoBehaviour
{
    private bool hasCharge = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasCharge)
        {
            return;
        }

        if (other.TryGetComponent(out Digger digger))
        {
            hasCharge = false;
            digger.ReceiveCharge();
            Destroy(gameObject);
        }
    }
}
