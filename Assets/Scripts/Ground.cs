using UnityEngine;

public class Ground : MonoBehaviour
{
    public static Ground Instance { get; private set; }

    [SerializeField]
    private GameObject solidGroundPrefab;

    private GameObject[,] groundObjects = new GameObject[30, 30];

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < groundObjects.GetLength(0); i++)
        {
            for (int j = 0; j < groundObjects.GetLength(1); j++)
            {
                SetGroundSolid(i, j, true);
            }
        }
    }

    public bool isGroundSolid(Vector3 position)
    {
        return isGroundSolid(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z));
    }

    public bool isGroundSolid(int x, int y)
    {
        if (x < 0 || y < 0 || x >= groundObjects.GetLength(0) || y >= groundObjects.GetLength(1))
        {
            return false;
        }

        return groundObjects[x, y] != null;
    }

    public void SetGroundSolid(Vector3 position, bool isSolid)
    {
        SetGroundSolid(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z), isSolid);
    }

    public void SetGroundSolid(int x, int y, bool isSolid)
    {
        if (x < 0 || y < 0 || x >= groundObjects.GetLength(0) || y >= groundObjects.GetLength(1))
        {
            return;
        }

        if (groundObjects[x, y] != null)
        {
            Destroy(groundObjects[x, y]);
        }

        if (isSolid)
        {
            groundObjects[x, y] = Instantiate(solidGroundPrefab);
            groundObjects[x, y].transform.parent = transform;
            groundObjects[x, y].transform.localPosition = new Vector3(x, 0, y);
        }
    }
}
