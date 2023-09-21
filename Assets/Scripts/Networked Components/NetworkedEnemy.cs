using UnityEngine;
using Mirror;

public class NetworkedEnemy : NetworkBehaviour
{
    public float moveSpeed = 5;

    [SerializeField]
    private Rigidbody rb;

    private NetworkedFlag target;

    private void Awake()
    {
        target = FindObjectOfType<NetworkedFlag>();
    }

    private void FixedUpdate()
    {
        if (isServer)
        {
            Vector3 dir = (target.transform.position - rb.position);
            dir.y = 0;

            if (dir.sqrMagnitude < 0.01f)
            {
                return;
            }

            dir = dir.normalized;
            rb.AddForce(dir * Time.fixedDeltaTime * moveSpeed);
        }
    }
}
