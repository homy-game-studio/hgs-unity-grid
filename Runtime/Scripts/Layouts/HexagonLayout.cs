using HGS.GridSystem.Helpers;
using HGS.GridSystem.Interfaces;
using UnityEngine;

namespace HGS.GridSystem.Layouts
{
  public class HexagonLayout : ICellLayout
  {
    HexOrientation _orientation = null;

    public HexagonLayout(HexOrientation orientation)
    {
      _orientation = orientation;
    }

    public Vector3 CellToLocal(Vector3Int coord, Vector2 cellSize)
    {
      return new Vector3
      {
        x = (_orientation.F0 * coord.x + _orientation.F1 * coord.y) * cellSize.x,
        y = (_orientation.F2 * coord.x + _orientation.F3 * coord.y) * cellSize.y,
        z = 0
      };
    }

    public Vector3Int LocalToCell(Vector3 pos, Vector2 cellSize)
    {
      var point = new Vector2
      {
        x = pos.x / cellSize.x,
        y = pos.y / cellSize.y,
      };

      var q = Mathf.RoundToInt(_orientation.B0 * point.x + _orientation.B1 * point.y);
      var r = Mathf.RoundToInt(_orientation.B2 * point.x + _orientation.B3 * point.y);

      return new Vector3Int
      {
        x = q,
        y = r,
        z = -q - r
      };
    }

    public Vector3 GetCorner(int corner, Vector2 cellSize)
    {
      var angle = 2f * Mathf.PI * (_orientation.StartAngle - corner) / 6f;
      return new Vector3
      {
        x = cellSize.x * Mathf.Cos(angle),
        y = cellSize.y * Mathf.Sin(angle)
      };
    }

    public Vector3[] GetCorners(Vector2 cellSize)
    {
      return new Vector3[6]{
        GetCorner(0,cellSize),
        GetCorner(1,cellSize),
        GetCorner(2,cellSize),
        GetCorner(3,cellSize),
        GetCorner(4,cellSize),
        GetCorner(5,cellSize),
      };
    }
  }
}