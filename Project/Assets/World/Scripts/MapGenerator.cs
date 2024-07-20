using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float scale;

    [SerializeField] private int octaves;
    [SerializeField, Range(0, 1)] private float persistence;
    [SerializeField] private float lacunarity;

    [SerializeField] private int seed;

    [SerializeField] private TileSet tileSet;
    [SerializeField] private MapDisplay mapDisplay;

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        float[,] heightMap = PerlinNoise.GenerateMap(width, height, seed, scale, octaves, persistence, lacunarity);

        TileType[,] tileMap = new TileType[width, height];

        // Determine the TileType at each cell on the map based on the noise height
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float height = heightMap[x, y];
                foreach (var tileType in tileSet.TileTypes)
                {
                    if (height <= tileType.Height)
                    {
                        tileMap[x, y] = tileType;
                        break;
                    }
                }
            }
        }

        mapDisplay.DisplayMap(tileMap);
    }

    // Ensure that valid values are entered for parameters
    private void OnValidate()
    {
        if (width < 1)
        {
            width = 1;
        }
        if (height < 1)
        {
            height = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}
