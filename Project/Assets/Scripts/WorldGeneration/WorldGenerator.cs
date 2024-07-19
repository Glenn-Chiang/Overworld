using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    private TileType[,] grid;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int mapRows;
    [SerializeField] private int mapCols;
    [SerializeField] private float density; // Proportion of tiles that are walls

    [Serializable]
    public enum TileType
    {
        EMPTY,
        WALL
    }

    [Serializable]
    public class TileDictionary : SerializableDictionary<TileType, Tile> { };


    [CustomPropertyDrawer(typeof(TileDictionary))]
    public class TileDictionaryDrawer : DictionaryDrawer<TileType, Tile> { }


    [SerializeField] private TileDictionary tiles;

    void Start()
    {
        int totalCells = mapRows * mapCols;
        int emptyCells = (int)((1 - density) * totalCells);
        var randomWalker = new RandomWalker(mapRows, mapCols, emptyCells);
        var grid = randomWalker.Generate();

        for (int i = 0; i < mapRows; i++)
        {
            for (int j = 0; j < mapCols; j++)
            {
                if (grid[i, j])
                {
                    SetTile(i, j, TileType.WALL);
                } else
                {
                    SetTile(i, j, TileType.EMPTY);
                }
            }
        }

        // Set the boundaries of the grid to wall tiles
        for (int col = 0; col < mapCols; col++)
        {
            // Top row
            SetTile(0, col, TileType.WALL);
            // Bottom row
            SetTile(mapRows - 1, col, TileType.WALL);
        }
        for (int row = 0; row < mapRows; row++)
        {
            // Leftmost col
            SetTile(row, 0, TileType.WALL);
            // Rightmost col
            SetTile(row, mapCols - 1, TileType.WALL);
        }

        
    }

    private void SetTile(int row, int col, TileType tileType)
    {
        var position = new Vector3Int(row, col);
        tilemap.SetTile(position, tiles[tileType]);
    }
}
