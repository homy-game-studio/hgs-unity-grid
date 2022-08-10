using HGS.GridSystem.Interfaces;
using UnityEngine;

namespace HGS.GridSystem.Layouts
{
  public class RectangleLayout : ICellLayout
  {
    public Vector3[] GetCorners(Vector2 cellSize)
    {
      return new Vector3[4]{
        GetCorner(0,cellSize),
        GetCorner(1,cellSize),
        GetCorner(2,cellSize),
        GetCorner(3,cellSize),
      };
    }

    public Vector3[] GetLines(Vector2 cellSize)
    {
      return new Vector3[8]{
        GetCorner(0,cellSize), GetCorner(1,cellSize),
        GetCorner(1,cellSize), GetCorner(2,cellSize),
        GetCorner(2,cellSize), GetCorner(3,cellSize),
        GetCorner(3,cellSize), GetCorner(0,cellSize),
      };
    }

    public Vector3 GetCorner(int corner, Vector2 cellSize)
    {
      var angle = 2f * Mathf.PI * (0.5f - corner) / 4f;
      return new Vector3
      {
        x = cellSize.x * Mathf.Cos(angle),
        y = cellSize.y * Mathf.Sin(angle)
      };
    }

    public Vector3 CellToLocal(Vector3Int coord, Vector2 cellSize)
    {
      return new Vector3
      {
        x = coord.x * cellSize.x * 2 * (Mathf.Sqrt(2f) / 2f),
        y = coord.y * cellSize.y * 2 * (Mathf.Sqrt(2f) / 2f),
        z = 0,
      };
    }

    public Vector3Int LocalToCell(Vector3 pos, Vector2 cellSize)
    {
      var localPos = new Vector3
      {
        x = pos.x / (cellSize.x * 2 * (Mathf.Sqrt(2f) / 2f)),
        y = pos.y / (cellSize.y * 2 * (Mathf.Sqrt(2f) / 2f)),
        z = 0,
      };

      return new Vector3Int
      {
        x = Mathf.RoundToInt(localPos.x),
        y = Mathf.RoundToInt(localPos.y),
        z = 0,
      };
    }
  }
}