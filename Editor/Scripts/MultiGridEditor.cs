using System.Linq;
using HGS.GridSystem.Utility;
using UnityEditor;
using UnityEngine;

namespace HGS.GridSystem.EditorExtensions
{
  [CustomEditor(typeof(MultiGrid))]
  public class MultiGridEditor : Editor
  {
    MultiGrid _grid = null;
    Vector3[] _segments = new Vector3[] { };

    void AddSegment(Vector3Int coord)
    {
      var position = _grid.CellToWorld(coord);
      var corners = _grid
           .GetLines()
           .Select(corner => corner + position)
           .ToArray();

      ArrayUtility.AddRange(ref _segments, corners);
    }

    void UpdateSegments()
    {
      ArrayUtility.Clear(ref _segments);

      switch (_grid.Layout)
      {
        case MultiGrid.CellLayout.Rectangle: ShapeUtility.Square(-5, 5, -5, 5, AddSegment); break;
        case MultiGrid.CellLayout.HexagonFlat: ShapeUtility.SquareHexPointy(-5, 5, -5, 5, AddSegment); break;
        case MultiGrid.CellLayout.HexagonPointy: ShapeUtility.SquareHexFlat(-5, 5, -5, 5, AddSegment); break;
      }
    }

    void OnEnable()
    {
      _grid = (MultiGrid)target;
      UpdateSegments();
    }

    void OnSceneGUI()
    {
      if (Event.current.type == EventType.Repaint)
      {
        UpdateSegments();
        Handles.DrawLines(_segments);
      }
    }
  }
}