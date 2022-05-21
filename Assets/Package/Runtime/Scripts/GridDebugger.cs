#  if  UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace HGS.Grid
{
  public class GridDebugger : MonoBehaviour
  {
    public GridBase grid = null;

    private void DrawVertex(Vector3 position, List<Vector3> vertex)
    {
      for (int i = 0; i < vertex.Count - 1; i++)
      {
        if (vertex.Count - 1 < i + 1) return;

        DrawLine(position, vertex[i], vertex[i + 1]);
        Gizmos.DrawSphere(position, 0.1f);
      }
    }

    private void DrawCoord(Vector3Int coord, Vector3 position)
    {
      Handles.Label(position + (Vector3.left / 2f), coord.ToString());
    }

    private void DrawLine(Vector3 position, Vector2 offsetA, Vector2 offsetB)
    {
      Gizmos.DrawLine(position + (Vector3)offsetA, position + (Vector3)offsetB);
    }

    private void DrawClose(Vector3 position, List<Vector3> vertex)
    {
      if (vertex.Count < 2) return;

      var end = vertex.LastOrDefault();
      var start = vertex.FirstOrDefault();

      DrawLine(position, start, end);
    }

    private void OnDrawGizmos()
    {
      if (grid == null) return;

      transform.position = grid.worldPosition;

      grid.ForEach(coord =>
      {
        var position = grid.CoordToWorldPos(coord);
        DrawVertex(position, grid.CeilVertex);
        DrawClose(position, grid.CeilVertex);
        DrawCoord(coord, position);
      });
    }
  }
}
#endif