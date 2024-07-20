using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Vector2 position;

    private void Start()
    {
        tileMap.transform.position = position;
    }

    // Use input grid of TileTypes to set the actual Tiles onto the tileMap
    public void DisplayMap(TileType[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                var tileType = map[i, j];
                var position = new Vector3Int(i, j, 0);
                tileMap.SetTile(position, tileType.Tile);
            }
        }
    }
}