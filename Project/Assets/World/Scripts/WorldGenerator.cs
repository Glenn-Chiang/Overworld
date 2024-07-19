using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Vector2 position;
    [SerializeField] private int mapRows;
    [SerializeField] private int mapCols;
    [SerializeField] private float density; // Proportion of tiles that are walls

    [SerializeField] private TileSet tileSet;

    void Start()
    {
        tilemap.transform.position = position;

        var worldTile = tileSet.Tiles[0];
        var tile = worldTile.Tile;

        for (int i = 0; i < mapRows; i++)
        {
            for (int j = 0; j < mapCols; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j), tile);
            }
        }
    }
}
