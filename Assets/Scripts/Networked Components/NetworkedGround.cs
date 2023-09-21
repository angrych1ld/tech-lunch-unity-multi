using UnityEngine;
using Mirror;

public class NetworkedGround : NetworkBehaviour
{
    public static NetworkedGround Instance { get; private set; }

    [SerializeField]
    private Ground ground;

    private void Awake()
    {
        Instance = this;
    }

    public bool isGroundSolid(Vector3 position)
    {
        return isGroundSolid(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z));
    }

    public bool isGroundSolid(int x, int y)
    {
        return ground.isGroundSolid(x, y);
    }

    public void SetGroundSolid(Vector3 position, bool isSolid)
    {
        SetGroundSolid(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z), isSolid);
    }

    public void SetGroundSolid(int x, int y, bool isSolid)
    {
        ground.SetGroundSolid(x, y, isSolid);

        if (isServer)
        {
            Rpc_SetGroundSolid(x, y, isSolid);
        }

        if (isClient)
        {
            Cmd_SetGroundSolid(x, y, isSolid);
        }
    }

    [Command(requiresAuthority = false)]
    private void Cmd_SetGroundSolid(int x, int y, bool isSolid)
    {
        ground.SetGroundSolid(x, y, isSolid);
        Rpc_SetGroundSolid(x, y, isSolid);
    }

    [ClientRpc]
    private void Rpc_SetGroundSolid(int x, int y, bool isSolid)
    {
        ground.SetGroundSolid(x, y, isSolid);
    }
}
