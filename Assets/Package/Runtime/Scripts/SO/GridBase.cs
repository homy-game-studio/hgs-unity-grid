using System.Collections.Generic;
using System;
using UnityEngine;

namespace HGS.Grid
{
  public abstract class GridBase : ScriptableObject
  {
    [Header("Base config")]
    public int ceilSize = 1;
    public Vector3 worldPosition = Vector3.zero;

    public abstract Vector3 CoordToWorldPos(Vector3Int coord);
    public abstract Vector3Int WorldPosToCoord(Vector3 pos);

    public abstract List<Vector3Int> GetCoordNeighbors(Vector3Int coord);
    public abstract void ForEach(Action<Vector3Int> callback);
  }
}