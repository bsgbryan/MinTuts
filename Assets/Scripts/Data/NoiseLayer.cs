using UnityEngine;

using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(
  fileName = "NoiseLayer",
  menuName = "MinTuts/NoiseLayer",
  order    = 1
)]
[System.Serializable]
public class NoiseLayer : ScriptableObject {
  [Range(1,  20 )] public int   Octaves     = 5;
  [Range(1f, 30f)] public float Scale       = 3f;

  [Range(0f,  1f)] public float Persistance = 0.5f;
  [Range(0f,  4f)] public float Lacunarity  = 2f;

  [Range(-1f,   1f)] public float Root      = 0.5f;
  [Range( 0.1f, 1f)] public float Magnitude = 0.5f;
}