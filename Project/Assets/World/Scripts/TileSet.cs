using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile set")]
public class TileSet : ScriptableObject
{
    [SerializeField] private List<TileType> tileTypes;
    public IReadOnlyList<TileType> TileTypes => tileTypes;
}