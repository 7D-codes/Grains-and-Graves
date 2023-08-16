using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeSpawner : MonoBehaviour
{
    public GameObject[] treePrefabs; // An array of tree prefabs
    Tilemap tilemap; // Reference to the tilemap
    Camera mainCamera; // Reference to the camera

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnTree();
            Debug.Log("Spawned trees");
        }
    }

    void SpawnTree()
    {
        BoundsInt bounds = tilemap.cellBounds;
        Vector3 cameraTopLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
        Vector3 cameraBottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));

        foreach (var prefab in treePrefabs)
        {
            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    Vector3Int cellPosition = new Vector3Int(x, y, 0);
                    Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPosition);

                    // Align the position to the grid
                    cellCenter.x = Mathf.Floor(cellCenter.x / 8) * 8;
                    cellCenter.y = Mathf.Floor(cellCenter.y / 8) * 8;

                    // Check if the spawn position is within the camera's view
                    Debug.Log("Spawning at: " + cellCenter);
                    Instantiate(prefab, cellCenter, Quaternion.identity);
                }
            }
        }
    }
}
