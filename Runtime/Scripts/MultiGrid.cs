using HGS.GridSystem.Layouts;
using HGS.GridSystem.Interfaces;
using UnityEngine;
using HGS.GridSystem.Helpers;
using System.Collections.Generic;

namespace HGS.GridSystem
{
  public class MultiGrid : MonoBehaviour
  {
    public enum CellLayout
    {
      Rectangle,
      HexagonPointy,
      HexagonFlat
    }

    [SerializeField] Vector2 cellSize = Vector2.one;
    [SerializeField] CellLayout cellLayout = CellLayout.Rectangle;

    Dictionary<CellLayout, ICellLayout> _layouts = new Dictionary<CellLayout, ICellLayout>
    {
      {CellLayout.Rectangle, new RectangleLayout()},
      {CellLayout.HexagonPointy, new HexagonLayout(HexOrientation.Pointy)},
      {CellLayout.HexagonFlat, new HexagonLayout(HexOrientation.Flat)},
    };

    public ICellLayout Layout
    {
      get => _layouts[cellLayout];
    }

    public Vector3[] GetCorners()
    {
      return Layout.GetCorners(cellSize);
    }

    public Vector3 GetCorner(int corner)
    {
      return Layout.GetCorner(corner, cellSize);
    }

    public Vector3 CellToWorld(Vector3Int cell)
    {
      return transform.position + Layout.CellToLocal(cell, cellSize);
    }

    public Vector3Int WorldToCell(Vector3 world)
    {
      return Layout.LocalToCell(world - transform.position, cellSize);
    }
  }
}