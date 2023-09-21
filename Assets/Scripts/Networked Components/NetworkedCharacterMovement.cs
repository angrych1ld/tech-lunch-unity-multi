using UnityEngine;
using Mirror;

public class NetworkedCharacterMovement : NetworkBehaviour
{
    public float moveSpeed;
    public float rotSpeed;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Rigidbody rb;

    [HideInInspector]
    public Vector3 desiredMoveDirection;

    private void Update()
    {
        if (isLocalPlayer)
        {
            anim.SetBool("Walking", desiredMoveDirection != Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            if (desiredMoveDirection != Vector3.zero)
            {
                rb.MoveRotation(Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(desiredMoveDirection, Vector3.up),
                    Time.fixedDeltaTime * rotSpeed));

                rb.MovePosition(rb.position + desiredMoveDirection * Time.fixedDeltaTime * moveSpeed);
            }
        }
    }
}
