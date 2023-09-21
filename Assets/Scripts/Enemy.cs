using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5;

    [SerializeField]
    private Rigidbody rb;

    private Flag target;

    private void Awake()
    {
        target = FindObjectOfType<Flag>();
    }

    private void FixedUpdate()
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
