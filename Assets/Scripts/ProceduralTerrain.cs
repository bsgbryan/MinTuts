using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class ProceduralTerrain : MonoBehaviour {

  [Range(10, 1000)] public int TerrainSize;
  [Range( 5,  250)] public int CellSize;

  public void GenerateTerrain() {
    int x_segments = TerrainSize / CellSize;
    int z_segments = TerrainSize / CellSize;

    int vertex_count = 6 * x_segments * z_segments;

    List<Vector3> vertices  = new List<Vector3>(new Vector3[vertex_count]);
    List<int>     triangles = new List<int>    (new int    [vertex_count]);

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

        int index0 = 6 * (x + z * x_segments);

        int index1 = index0 + 1;
        int index2 = index0 + 2;
        int index3 = index0 + 3;
        int index4 = index0 + 4;
        int index5 = index0 + 5;

        vertices[index0] = vertex00;
        vertices[index1] = vertex01;
        vertices[index2] = vertex11;
        vertices[index3] = vertex00;
        vertices[index4] = vertex11;
        vertices[index5] = vertex10;

        triangles[index0] = index0;
        triangles[index1] = index1;
        triangles[index2] = index2;
        triangles[index3] = index3;
        triangles[index4] = index4;
        triangles[index5] = index5;
      }
    }
  }

  private float GetHeight(float x, float z, int x_segments, int z_segments) {
    return Mathf.PerlinNoise(x / (float) x_segments, z / (float) z_segments);
  } 
}
