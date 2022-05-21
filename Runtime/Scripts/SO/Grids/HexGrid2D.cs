using System;
using System.Collections.Generic;
using HGS.Grid.Hex;
using UnityEngine;

namespace HGS.Grid
{
  [CreateAssetMenu(fileName = "HexGrid2D", menuName = "HGS/Grid/HexGrid2D")]
  public class HexGrid2D : GridBase
  {
    public enum OrientationType
    {
      POINTY = 0,
      FLAT = 1
    }

    [Header("Layout")]
    public OrientationType orientationType = OrientationType.FLAT;

    Dictionary<OrientationType, Orientation> _orientations = new Dictionary<OrientationType, Orientation>
    {
      {OrientationType.FLAT, Orientation.Flat},
      {OrientationType.POINTY, Orientation.Pointy},
    };

    public override List<Vector3> CeilVertex => Layout.HexCornerOffsets(_orientations[orientationType], ceilSize);

    public override Vector3 CoordToWorldPos(Vector3Int coord)
    {
      var localPos = Layout.HexToWorld(_orientations[orientationType], ceilSize, coord);
      return worldPosition + localPos;
    }

    public override Vector3Int WorldPosToCoord(Vector3 pos)
    {
      var localPos = pos - worldPosition;

      return Layout.WorldToHex(_orientations[orientationType], ceilSize, localPos);
    }

    public override void ForEach(Action<Vector3Int> callback)
    {
      if (orientationType == OrientationType.POINTY)
      {
        Shape.Pointy(size, callback);
      }
      else
      {
        Shape.Flat(size, callback);
      }
    }
  }
}