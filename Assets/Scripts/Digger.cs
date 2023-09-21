using UnityEngine;

public class Digger : MonoBehaviour
{
    private int chargesLeft = 10;

    [SerializeField]
    private Transform digTarget = null;

    public void Dig()
    {
        if (chargesLeft <= 0)
        {
            return;
        }

        if (!Ground.Instance.isGroundSolid(digTarget.position))
        {
            return;
        }

        chargesLeft--;

        Ground.Instance.SetGroundSolid(digTarget.position, false);
        DigChargeCanvas.Instance.SetDigCharges(chargesLeft);
    }

    public void ReceiveCharge()
    {
        chargesLeft++;
        DigChargeCanvas.Instance.SetDigCharges(chargesLeft);
    }
}
