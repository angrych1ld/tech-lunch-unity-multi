using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Dependancies
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private LightHolder lightHolder;
    [SerializeField] private Digger digger;

    private void Update()
    {
        characterMovement.desiredMoveDirection = GetInputMoveDir();

        if (Input.GetKeyDown(KeyCode.P))
        {
            lightHolder.SetLightActive(!lightHolder.IsLightOn);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            digger.Dig();
        }
    }

    private Vector3 GetInputMoveDir()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector3.back;
        }

        if (dir != Vector3.zero)
        {
            return dir.normalized;
        }

        return Vector3.zero;
    }
}
