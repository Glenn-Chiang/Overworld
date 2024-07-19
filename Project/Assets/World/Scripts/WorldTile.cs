using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile")]
public class WorldTile : ScriptableObject
{
    [SerializeField] private RuleTile tile;
    public RuleTile Tile => tile;
    [SerializeField] private float weight;
    [SerializeField] private List<WorldTile> allowedNeighbors;
}