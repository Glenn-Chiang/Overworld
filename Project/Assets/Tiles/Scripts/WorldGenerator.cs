using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    private TileType[,] grid;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int mapRows;
    [SerializeField] private int mapCols;

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
        grid = new TileType[mapRows, mapCols];

        for (int i = 0; i < mapRows; i++)
        {
            for (int j = 0; j < mapCols; j++)
            {
                grid[i, j] = TileType.WALL;
            }
        }

        setTiles();
    }

    // Place tile assets according to the grid
    private void setTiles()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                TileType tileType = grid[i, j];
                Tile tile = tiles[tileType];
                var position = new Vector3Int(i, j);
                tilemap.SetTile(position, tile);
            }
        }
    }
}
