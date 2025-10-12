using UnityEngine;
using UnityEngine.Tilemaps;

public class PotionSpawner : MonoBehaviour
{
    public GameObject potionPrefab;
    public int totalPotions = 3;
    public Tilemap tilemap;

    public int margin = 2;

    void Start()
    {
        SpawnPotions();
    }

    void SpawnPotions()
    {
        BoundsInt bounds = tilemap.cellBounds; // Get the tile bounds

        int attempts = 0;
        int spawned = 0;

        while (spawned < totalPotions && attempts < 100)
        {
            attempts++;

            // Random cell within bounds minus margin
            int randomX = Random.Range(bounds.xMin + margin, bounds.xMax - margin);
            int randomY = Random.Range(bounds.yMin + margin, bounds.yMax - margin);

            Vector3Int cellPos = new Vector3Int(randomX, randomY, 0);

            // Only spawn if a tile exists at that position
            if (tilemap.HasTile(cellPos))
            {
                Vector3 worldPos = tilemap.GetCellCenterWorld(cellPos);
                Instantiate(potionPrefab, worldPos, Quaternion.identity);
                spawned++;
            }
        }
    }
}
