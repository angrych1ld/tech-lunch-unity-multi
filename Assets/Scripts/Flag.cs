using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Transform cloth;

    [SerializeField] private float regularClothHeight;
    [SerializeField] private float loseClothHeight;

    private bool isLost = false;

    private void Update()
    {
        cloth.transform.position = new Vector3(
            cloth.transform.position.x,
            Mathf.MoveTowards(
                cloth.transform.position.y,
                isLost ? loseClothHeight : regularClothHeight,
                Time.deltaTime),
            transform.position.z
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            isLost = true;
        }
    }
}
