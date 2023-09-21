using UnityEngine;
using Mirror;

public class NetworkedDigger : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnChargesLeftChanged))]
    private int chargesLeft = 10;

    [SerializeField]
    private Transform digTarget = null;

    private void OnChargesLeftChanged(int oldValue, int newValue)
    {
        if (isLocalPlayer)
        {
            DigChargeCanvas.Instance.SetDigCharges(newValue);
        }
    }

    public override void OnStartClient()
    {
        if (isLocalPlayer)
        {
            DigChargeCanvas.Instance.SetDigCharges(chargesLeft);
        }
    }

    [Client]
    public void Dig()
    {
        if (chargesLeft <= 0)
        {
            return;
        }

        if (!NetworkedGround.Instance.isGroundSolid(digTarget.position))
        {
            return;
        }

        Cmd_DeductCharge();

        NetworkedGround.Instance.SetGroundSolid(digTarget.position, false);
    }

    [Command]
    public void Cmd_DeductCharge()
    {
        chargesLeft--;
    }

    [Server]
    public void ReceiveCharge()
    {
        chargesLeft++;
    }
}
