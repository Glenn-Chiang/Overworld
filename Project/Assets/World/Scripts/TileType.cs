using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile")]
public class TileType : ScriptableObject
{
    [SerializeField] private TileBase tile;
    public TileBase Tile => tile;
    [SerializeField] private float height;
    public float Height => height;
}