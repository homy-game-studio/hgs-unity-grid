using System.Collections.Generic;
using UnityEngine;

namespace HGS.Grid.Utility
{
  public static class HexUtility
  {
    public static Vector3 GetFlatCorner(int corner)
    {
      var angleDeg = 60f * corner;
      var angleRad = Mathf.PI / 180f * angleDeg;

      return new Vector3
      {
        x = Mathf.Cos(angleRad),
        y = Mathf.Sin(angleRad),
        z = 0,
      };
    }

    public static Vector3Int WorldToFlat(Vector3 localPos, float size, Vector2 spacement)
    {
      var x = (localPos.x / (spacement.x + size)) / -(3f / 2f);
      var y = ((localPos.y / (spacement.y + size)) - ((Mathf.Sqrt(3) / 2) * x)) / -Mathf.Sqrt(3);

      return new Vector3Int
      {
        x = Mathf.RoundToInt(x),
        y = Mathf.RoundToInt(y),
        z = 0
      };
    }

    public static Vector3Int WorldToPointy(Vector3 localPos, float size, Vector2 spacement)
    {
      var y = (localPos.y / (spacement.y + size)) / -(3f / 2f);
      var x = ((localPos.x / (spacement.y + size)) - ((Mathf.Sqrt(3) / 2) * y)) / -Mathf.Sqrt(3);

      return new Vector3Int
      {
        x = Mathf.RoundToInt(x),
        y = Mathf.RoundToInt(y),
        z = 0
      };
    }

    public static Vector3 FlatToWorld(Vector3Int coord, float size, Vector2 spacement)
    {
      var result = new Vector3
      {
        x = 3f / 2f * coord.x,
        y = Mathf.Sqrt(3) / 2f * coord.x + Mathf.Sqrt(3) * coord.y,
        z = 0,
      };

      return new Vector3
      {
        x = (result.x * size) + (result.x * spacement.x),
        y = (result.y * size) + (result.y * spacement.y),
        z = 0
      };
    }

    public static Vector3 PontyToWorld(Vector3Int coord, float size, Vector2 spacement)
    {
      var result = new Vector3
      {
        x = Mathf.Sqrt(3) * coord.x + Mathf.Sqrt(3) / 2f * coord.y,
        y = 3f / 2f * coord.y,
        z = 0,
      };

      return new Vector3
      {
        x = (result.x * size) + (result.x * spacement.x),
        y = (result.y * size) + (result.y * spacement.y),
        z = 0
      };
    }

    public static Vector3 GetPointyCorner(int corner)
    {
      var angleDeg = 60f * corner - 30f;
      var angleRad = Mathf.PI / 180f * angleDeg;

      return new Vector3
      {
        x = Mathf.Cos(angleRad),
        y = Mathf.Sin(angleRad),
        z = 0,
      };
    }

    public static List<Vector3> PointyCorners = new List<Vector3>
    {
        GetPointyCorner(0),
        GetPointyCorner(1),
        GetPointyCorner(2),
        GetPointyCorner(3),
        GetPointyCorner(4),
        GetPointyCorner(5),
    };

    public static List<Vector3> FlatCorners => new List<Vector3>
    {
        GetFlatCorner(0),
        GetFlatCorner(1),
        GetFlatCorner(2),
        GetFlatCorner(3),
        GetFlatCorner(4),
        GetFlatCorner(5),
    };
  }
}