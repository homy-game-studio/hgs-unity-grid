using System;
using UnityEngine;

namespace HGS.Grid.Hex
{
  public static class Shape
  {
    public static void Pointy(Vector2Int gridSize, Action<Vector3Int> callback)
    {
      var top = -gridSize.y;
      var bottom = gridSize.y;
      var left = -gridSize.x;
      var right = gridSize.x;

      for (int r = top; r <= bottom; r++)
      {
        var rOffset = Mathf.FloorToInt(r / 2f);
        for (int q = left - rOffset; q <= right - rOffset; q++)
        {
          var coord = new Vector3Int(q, r, -q - r);
          callback.Invoke(coord);
        }
      }
    }

    public static void Flat(Vector2Int gridSize, Action<Vector3Int> callback)
    {
      var top = -gridSize.y;
      var bottom = gridSize.y;
      var left = -gridSize.x;
      var right = gridSize.x;

      for (int q = left; q <= right; q++)
      {
        var qOffset = Mathf.FloorToInt(q / 2f);
        for (int r = top - qOffset; r <= bottom - qOffset; r++)
        {
          var coord = new Vector3Int(q, r, -q - r);
          callback.Invoke(coord);
        }
      }
    }
  }
}