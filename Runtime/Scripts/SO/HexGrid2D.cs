using System;
using System.Collections.Generic;
using UnityEngine;
using HGS.Grid.Utility;

namespace HGS.Grid
{
  [CreateAssetMenu(fileName = "HexGrid2D", menuName = "HGS/Grid/HexGrid2D")]
  public class HexGrid2D : GridBase
  {
    public enum Mode
    {
      POINTY,
      FLAT
    }

    [Header("Grid")]
    public Vector2Int size = new Vector2Int(5, 5);
    public Mode mode = Mode.FLAT;

    [Header("Ceil")]
    public Vector2 ceilSpacement = Vector2.one;

    public override List<Vector3> CeilVertex => mode == Mode.FLAT
        ? HexUtility.FlatCorners
        : HexUtility.PointyCorners;

    public override Vector3 CoordToWorldPos(Vector3Int coord)
    {
      var localPos = mode == Mode.FLAT
        ? HexUtility.FlatToWorld(coord, ceilSize, ceilSpacement)
        : HexUtility.PontyToWorld(coord, ceilSize, ceilSpacement);

      return worldPosition + localPos;
    }

    public override void ForEach(Action<Vector3Int> callback)
    {
      for (int q = -size.x; q <= size.x; q++)
      {
        int r1 = Math.Max(-size.x, -q - size.x);
        int r2 = Math.Min(size.y, -q + size.y);

        for (int r = r1; r <= r2; r++)
        {
          var coord = new Vector3Int(q, r, -q - r);
          callback.Invoke(coord);
        }
      }
    }

    public override Vector3Int WorldPosToCoord(Vector3 pos)
    {

      var localPos = pos - worldPosition;

      return mode == Mode.FLAT
        ? HexUtility.WorldToFlat(localPos, ceilSize, ceilSpacement)
        : HexUtility.WorldToPointy(localPos, ceilSize, ceilSpacement);
    }
  }
}