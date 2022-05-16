using System;
using System.Collections.Generic;
using UnityEngine;

namespace HGS.Grid
{
  [CreateAssetMenu(fileName = "SquareGrid2D", menuName = "HGS/Grid/SquareGrid2D")]
  public class SquareGrid2D : GridBase
  {
    [Header("Grid")]
    public Vector2Int size = new Vector2Int(10, 10);

    [Header("Ceil")]
    public Vector2 ceilSpacement = Vector2.zero;

    public override List<Vector3> CeilVertex => new List<Vector3>
    {
        (Vector3.up+ Vector3.left)/2f,
        (Vector3.up+ Vector3.right)/2f,
        (Vector3.down+ Vector3.right)/2f,
        (Vector3.down+ Vector3.left)/2f,
    };

    public override Vector3 CoordToWorldPos(Vector3Int coord)
    {
      return new Vector3
      {
        x = (coord.x * ceilSize) + (coord.x * ceilSpacement.x) + worldPosition.x,
        y = (coord.y * ceilSize) + (coord.y * ceilSpacement.y) + worldPosition.y,
        z = worldPosition.z,
      };
    }

    public override Vector3Int WorldPosToCoord(Vector3 pos)
    {
      var worldPos = new Vector3
      {
        x = (-worldPosition.x + pos.x) / (ceilSize + ceilSpacement.x),
        y = (-worldPosition.y + pos.y) / (ceilSize + ceilSpacement.y),
        z = 0,
      };

      return new Vector3Int
      {
        x = Mathf.RoundToInt(worldPos.x),
        y = Mathf.RoundToInt(worldPos.y),
        z = 0,
      };
    }

    public override void ForEach(Action<Vector3Int> callback)
    {
      for (int x = 0; x < size.x; x++)
      {
        for (int y = 0; y < size.y; y++)
        {
          callback.Invoke(new Vector3Int(x, y, 0));
        }
      }
    }
  }
}