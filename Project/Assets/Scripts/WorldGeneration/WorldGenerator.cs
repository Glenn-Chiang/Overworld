using System;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
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
        // Initialize grid with empty tiles
        // The grid only stores the TileType at each cell in the grid, not actual Tile objects
        // grid = new TileType[mapRows, mapCols];

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

    }

    private void SetTile(int row, int col, TileType tileType)
    {
        var position = new Vector3Int(row, col);
        tilemap.SetTile(position, tiles[tileType]);
    }
}
