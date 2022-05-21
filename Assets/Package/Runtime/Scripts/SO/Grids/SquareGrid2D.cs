using System;
using System.Collections.Generic;
using UnityEngine;

namespace HGS.Grid
{
  [CreateAssetMenu(fileName = "SquareGrid2D", menuName = "HGS/Grid/SquareGrid2D")]
  public class SquareGrid2D : GridBase
  {
    public override List<Vector3> CeilVertex => new List<Vector3>
    {
        CornerOffset(ceilSize, 0),
        CornerOffset(ceilSize, 1),
        CornerOffset(ceilSize, 2),
        CornerOffset(ceilSize, 3),
    };

    public Vector3 CornerOffset(Vector2 objSize, int corner)
    {
      var angle = 2f * Mathf.PI * (0.5f - corner) / 4f;
      return new Vector3
      {
        x = ceilSize.x * Mathf.Cos(angle),
        y = ceilSize.y * Mathf.Sin(angle)
      };
    }

    public override Vector3 CoordToWorldPos(Vector3Int coord)
    {
      return new Vector3
      {
        x = worldPosition.x + (coord.x * ceilSize.x * 2 * (Mathf.Sqrt(2f) / 2f)),
        y = worldPosition.y + (coord.y * ceilSize.y * 2 * (Mathf.Sqrt(2f) / 2f)),
        z = worldPosition.z,
      };
    }

    public override Vector3Int WorldPosToCoord(Vector3 pos)
    {
      var worldPos = new Vector3
      {
        x = (pos.x - worldPosition.x) / (ceilSize.x * 2 * (Mathf.Sqrt(2f) / 2f)),
        y = (pos.y - worldPosition.y) / (ceilSize.y * 2 * (Mathf.Sqrt(2f) / 2f)),
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
      for (int x = -size.x; x < size.x; x++)
      {
        for (int y = -size.y; y < size.y; y++)
        {
          callback.Invoke(new Vector3Int(x, y, 0));
        }
      }
    }
  }
}