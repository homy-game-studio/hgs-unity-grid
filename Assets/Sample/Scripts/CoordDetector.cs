using HGS.GridSystem;
using UnityEngine;

public class CoordDetector : MonoBehaviour
{
  [SerializeField] MultiGrid grid = null;
  [SerializeField] TextMesh textMesh = null;

  Vector3Int coord = Vector3Int.zero;

  // Update is called once per frame
  void Update()
  {
    coord = grid.WorldToCell(transform.position);
    textMesh.text = coord.ToString();
  }
}
