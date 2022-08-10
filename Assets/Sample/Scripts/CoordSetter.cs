using HGS.GridSystem;
using UnityEngine;

public class CoordSetter : MonoBehaviour
{
  [SerializeField] Vector3Int coord;
  [SerializeField] MultiGrid grid;

  void Start()
  {
    var worldPos = grid.CellToWorld(coord);
    transform.position = worldPos;
  }
}