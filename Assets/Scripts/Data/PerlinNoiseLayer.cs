using UnityEngine;

using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(
  fileName = "PerlinNoiseLayer",
  menuName = "MinTuts/PerlinNoiseLayer",
  order    = 1
)]
[System.Serializable]
public class PerlinNoiseLayer : ScriptableObject {

  public NoiseLayer Noise;
  public NoiseLayer FalloffMap;

  public bool AutoUpdate    = false;
  public bool UseFalloffMap = false;
}