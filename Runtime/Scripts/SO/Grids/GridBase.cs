using System.Collections.Generic;
using System;
using UnityEngine;

namespace HGS.Grid
{
  public abstract class GridBase : ScriptableObject
  {
    [Header("Ceil")]
    public Vector2 ceilSize = Vector2.one;

    [Header("Grid")]
    public Vector3 worldPosition = Vector3.zero;
    public Vector2Int size = new Vector2Int(5, 5);

    public abstract Vector3 CoordToWorldPos(Vector3Int coord);
    public abstract Vector3Int WorldPosToCoord(Vector3 pos);
    public abstract void ForEach(Action<Vector3Int> callback);

    public abstract List<Vector3> CeilVertex { get; }
  }
}