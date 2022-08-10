using System.Collections.Generic;
using UnityEngine;

namespace HGS.GridSystem.Interfaces
{
  public interface ICellLayout
  {
    Vector3 CellToLocal(Vector3Int coord, Vector2 cellSize);
    Vector3Int LocalToCell(Vector3 pos, Vector2 cellSize);
    Vector3 GetCorner(int corner, Vector2 cellSize);
    Vector3[] GetCorners(Vector2 cellSize);
    Vector3[] GetLines(Vector2 cellSize);
  }
}