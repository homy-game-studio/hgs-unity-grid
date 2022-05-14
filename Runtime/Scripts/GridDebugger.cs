using UnityEngine;

namespace HGS.Grid
{
  public class GridDebugger : MonoBehaviour
  {
    [SerializeField] GridBase grid = null;

    private void OnDrawGizmos()
    {
      if (grid == null) return;
      transform.position = grid.worldPosition;
      grid.ForEach(coord =>
      {
        var position = grid.CoordToWorldPos(coord);
        Gizmos.DrawWireCube(position, Vector3.one * grid.ceilSize);
      });
    }
  }
}