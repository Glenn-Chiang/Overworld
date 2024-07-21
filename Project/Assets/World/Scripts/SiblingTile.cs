using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SiblingTile : RuleTile<SiblingTile.Neighbor> {
    public TileBase sibling;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Sibling = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.Sibling:
                return sibling == tile;
        }
        return base.RuleMatch(neighbor, tile);
    }
}