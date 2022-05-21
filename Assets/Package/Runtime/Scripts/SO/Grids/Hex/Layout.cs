using System.Collections.Generic;
using UnityEngine;

namespace HGS.Grid.Hex
{
  public static class Layout
  {
    public static Vector3 HexToWorld(Orientation orientation, Vector2 size, Vector3Int coord)
    {
      return new Vector3
      {
        x = (orientation.F0 * coord.x + orientation.F1 * coord.y) * size.x,
        y = (orientation.F2 * coord.x + orientation.F3 * coord.y) * size.y,
        z = 0
      };
    }

    public static Vector3Int WorldToHex(Orientation orientation, Vector2 size, Vector3 localPos)
    {
      var point = new Vector2
      {
        x = localPos.x / size.x,
        y = localPos.y / size.y,
      };

      var q = Mathf.RoundToInt(orientation.B0 * point.x + orientation.B1 * point.y);
      var r = Mathf.RoundToInt(orientation.B2 * point.x + orientation.B3 * point.y);

      return new Vector3Int
      {
        x = q,
        y = r,
        z = -q - r
      };
    }

    public static Vector3 HexCornerOffset(Orientation orientation, Vector2 size, int corner)
    {
      var angle = 2f * Mathf.PI * (orientation.StartAngle - corner) / 6f;
      return new Vector3
      {
        x = size.x * Mathf.Cos(angle),
        y = size.y * Mathf.Sin(angle)
      };
    }

    public static List<Vector3> HexCornerOffsets(Orientation orientation, Vector2 size)
    {
      var corners = new List<Vector3>();
      for (int i = 0; i < 6; i++)
      {
        corners.Add(HexCornerOffset(orientation, size, i));
      }
      return corners;
    }
  }
}