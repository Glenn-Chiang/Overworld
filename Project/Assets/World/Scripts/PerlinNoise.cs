using System;
using UnityEngine;

public static class PerlinNoise
{
    public static float[,] GenerateMap(int width, int height, int seed, float scale, 
        int octaves, float persistence, float lacunarity)
    {
        float[,] noiseMap = new float[width, height];

        var rand = new System.Random(seed);

        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = rand.Next(-100000,100000);
            float offsetY = rand.Next(-100000, 100000);
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }


        // Clamp to min value to prevent zero division error
        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float frequency = 1;
                float amplitude = 1;
               
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency + octaveOffsets[i].x;
                    float sampleY = y / scale * frequency + octaveOffsets[i].y;
                
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    // Each octave has a higher frequency and lower amplitude than the previous one
                    frequency *= lacunarity;
                    amplitude *= persistence;
                }

                // Update max and min noise heights
                maxNoiseHeight = Mathf.Max(maxNoiseHeight, noiseHeight);
                minNoiseHeight = Mathf.Min(minNoiseHeight, noiseHeight);

                noiseMap[x, y] = noiseHeight;    
            }
        }

        // Normalize noise heights between min and max noise heights
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }

        return noiseMap;
    }
}