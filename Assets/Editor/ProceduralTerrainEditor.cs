using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralTerrain))]
[CanEditMultipleObjects]
public class ProceduralTerrainEditor: Editor {
  
  public override void OnInspectorGUI() {
    serializedObject.Update();

    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainSize"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainHeight"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("CellSize"));

    EditorGUILayout.PropertyField(serializedObject.FindProperty("Octaves"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("Scale"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("Persistance"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("Lacunarity"));

    EditorGUILayout.PropertyField(serializedObject.FindProperty("UseFalloffMap"));

    if (GUILayout.Button("Generate"))
      (serializedObject.targetObject as ProceduralTerrain).GenerateTerrain();

    serializedObject.ApplyModifiedProperties();
  }
}
