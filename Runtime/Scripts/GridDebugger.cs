using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HGS.Grid
{
  public class GridDebugger : MonoBehaviour
  {
    [SerializeField] GridBase grid = null;

    private void DrawVertex(Vector3 position, List<Vector3> vertex, float size)
    {
      for (int i = 0; i < vertex.Count - 1; i++)
      {
        if (vertex.Count - 1 < i + 1) return;

        var origin = vertex[i] * size + position;
        var destination = vertex[i + 1] * size + position;

        Gizmos.DrawLine(origin, destination);
      }
    }

    private void DrawClose(Vector3 position, List<Vector3> vertex, float size)
    {
      if (vertex.Count < 2) return;

      var end = vertex.LastOrDefault() * size + position;
      var start = vertex.FirstOrDefault() * size + position;

      Gizmos.DrawLine(start, end);
    }

    private void OnDrawGizmos()
    {
      if (grid == null) return;

      transform.position = grid.worldPosition;

      grid.ForEach(coord =>
      {
        var position = grid.CoordToWorldPos(coord);
        DrawVertex(position, grid.CeilVertex, grid.ceilSize);
        DrawClose(position, grid.CeilVertex, grid.ceilSize);
      });
    }
  }
}