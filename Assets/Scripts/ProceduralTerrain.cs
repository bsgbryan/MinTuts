using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class ProceduralTerrain : MonoBehaviour {

  [Range(10, 1000)] public int TerrainSize;
  [Range( 5,  250)] public int CellSize;

  public void GenerateTerrain() {
    int x_segments = TerrainSize / CellSize;
    int z_segments = TerrainSize / CellSize;

    for (int x = 0; x < x_segments; x++) {
      for (int z = 0; z < z_segments; z++) {
        float height00 = GetHeight(x + 0f, z + 0f, x_segments, z_segments);
        float height01 = GetHeight(x + 0f, z + 1f, x_segments, z_segments);
        float height10 = GetHeight(x + 1f, z + 0f, x_segments, z_segments);
        float height11 = GetHeight(x + 1f, z + 1f, x_segments, z_segments);

        int x0 =  x      * CellSize;
        int z0 =  z      * CellSize;
        int x1 = (x + 1) * CellSize;
        int z1 = (z + 1) * CellSize;

        var vertex00 = new Vector3((float) x0, height00 * (float) TerrainHeight, (float) z0);
        var vertex01 = new Vector3((float) x0, height01 * (float) TerrainHeight, (float) z1);
        var vertex10 = new Vector3((float) x1, height10 * (float) TerrainHeight, (float) z0);
        var vertex11 = new Vector3((float) x1, height11 * (float) TerrainHeight, (float) z1);
      }
    }
  }

  private float GetHeight(float x, float z, int x_segments, int z_segments) {
    return Mathf.PerlinNoise(x / (float) x_segments, z / (float) z_segments);
  } 
}
