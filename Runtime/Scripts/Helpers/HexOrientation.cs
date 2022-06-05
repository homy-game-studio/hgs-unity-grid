using UnityEngine;

namespace HGS.GridSystem.Helpers
{
  public class HexOrientation
  {
    public float F0 { get; private set; }
    public float F1 { get; private set; }
    public float F2 { get; private set; }
    public float F3 { get; private set; }

    public float B0 { get; private set; }
    public float B1 { get; private set; }
    public float B2 { get; private set; }
    public float B3 { get; private set; }

    public float StartAngle { get; private set; }

    public static HexOrientation Flat = new HexOrientation
    {
      F0 = 3f / 2f,
      F1 = 0f,
      F2 = Mathf.Sqrt(3f) / 2f,
      F3 = Mathf.Sqrt(3f),

      B0 = 2f / 3f,
      B1 = 0f,
      B2 = -1f / 3f,
      B3 = Mathf.Sqrt(3) / 3,

      StartAngle = 0f
    };

    public static HexOrientation Pointy = new HexOrientation
    {
      F0 = Mathf.Sqrt(3f),
      F1 = Mathf.Sqrt(3f) / 2f,
      F2 = 0f,
      F3 = 3f / 2f,

      B0 = Mathf.Sqrt(3f) / 3f,
      B1 = -1f / 3f,
      B2 = 0f,
      B3 = 2f / 3f,

      StartAngle = 0.5f
    };
  }
}