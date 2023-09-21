using Mirror;
using UnityEngine;

public class NetworkedLightHolder : NetworkBehaviour
{
    [SerializeField] private GameObject lightOffFrame;
    [SerializeField] private GameObject lightOnFrame;
    [SerializeField] private GameObject lightSource;

    [SyncVar]
    private bool isLightOn = true;

    public bool IsLightOn => isLightOn;

    public override void OnStartClient()
    {
        Local_SetLightOn(isLightOn);
    }

    [Command]
    public void Cmd_SetLightActive(bool on)
    {
        isLightOn = on;
        Rpc_SetLightOn(on);
    }

    [ClientRpc]
    private void Rpc_SetLightOn(bool on)
    {
        Local_SetLightOn(on);
    }

    private void Local_SetLightOn(bool on)
    {
        lightOffFrame.SetActive(!on);
        lightOnFrame.SetActive(on);

        lightSource.SetActive(on);
    }
}
