using System;
using UnityEngine;

namespace HGS.GridSystem.Utility
{
  public static class ShapeUtility
  {
    public static void SquareHexFlat(int left, int right, int top, int bottom, Action<Vector3Int> callback)
    {
      var coord = Vector3Int.zero;

      for (int r = top; r <= bottom; r++)
      {
        int offset = Mathf.FloorToInt(r / 2.0f);
        for (int q = left - offset; q <= right - offset; q++)
        {
          coord = new Vector3Int(q, r, -q - r);
          callback.Invoke(coord);
        }
      }
    }

    public static void SquareHexPointy(int left, int right, int top, int bottom, Action<Vector3Int> callback)
    {
      var coord = Vector3Int.zero;

      for (int q = left; q <= right; q++)
      {
        int offset = Mathf.FloorToInt(q / 2.0f);
        for (int r = top - offset; r <= bottom - offset; r++)
        {
          coord = new Vector3Int(q, r, -q - r);
          callback.Invoke(coord);
        }
      }
    }

    public static void Square(int left, int right, int top, int bottom, Action<Vector3Int> callback)
    {
      var coord = Vector3Int.zero;

      for (int q = left; q <= right; q++)
      {
        for (int r = top; r <= bottom; r++)
        {
          coord = new Vector3Int(q, r, -q - r);
          callback.Invoke(coord);
        }
      }
    }
  }
}