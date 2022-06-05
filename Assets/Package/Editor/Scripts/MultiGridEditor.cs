using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HGS.GridSystem.EditorExtensions
{
  [CustomEditor(typeof(MultiGrid))]
  public class MultiGridEditor : Editor
  {
    MultiGrid _grid = null;

    Vector3[] _segments = null;

    void OnEnable()
    {
      _grid = (MultiGrid)target;
      UpdateSegments();
    }

    void UpdateSegments()
    {
      var segments = new List<Vector3>();

      for (var x = -50; x < 50; x++)
      {
        for (var y = -50; y < 50; y++)
        {
          var coord = new Vector3Int(x, y, 0);
          var position = _grid.CellToWorld(coord);
          var corners = _grid
            .GetCorners()
            .Select(corner => corner + position);

          segments.AddRange(corners);
        }
      }
      _segments = segments.ToArray();
    }

    void OnSceneGUI()
    {
      if (Event.current.type != EventType.Repaint)
        return;

      Handles.DrawLines(_segments);
    }
  }
}