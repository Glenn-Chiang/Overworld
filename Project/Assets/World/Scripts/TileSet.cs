using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile set")]
public class TileSet : ScriptableObject
{
    [SerializeField] private List<WorldTile> tiles;
    public IReadOnlyList<WorldTile> Tiles => tiles;
}