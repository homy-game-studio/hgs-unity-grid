using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HGS.Grid;

public class CoordDetector : MonoBehaviour
{
  [SerializeField] GridBase grid = null;
  [SerializeField] TextMesh textMesh = null;

  Vector3Int coord = Vector3Int.zero;

  // Update is called once per frame
  void Update()
  {
    coord = grid.WorldPosToCoord(transform.position);
    textMesh.text = coord.ToString();
  }
}
