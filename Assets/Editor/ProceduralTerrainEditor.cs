using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralTerrain))]
[CanEditMultipleObjects]
public class ProceduralTerrainEditor: Editor {
  
  public override void OnInspectorGUI() {
    serializedObject.Update();

    EditorGUI.BeginChangeCheck();

    EditorGUILayout.PropertyField(serializedObject.FindProperty("AutoUpdate"));

    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainSize"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainHeight"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("CellSize"));

    EditorGUILayout.PropertyField(serializedObject.FindProperty("Octaves"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("Scale"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("Persistance"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("Lacunarity"));

    EditorGUILayout.PropertyField(serializedObject.FindProperty("UseFalloffMap"));

    serializedObject.ApplyModifiedProperties();

    ProceduralTerrain procedural_terrain = serializedObject.targetObject as ProceduralTerrain;

    if (GUILayout.Button("Generate") || (EditorGUI.EndChangeCheck() && procedural_terrain.AutoUpdate))
      procedural_terrain.GenerateTerrain();
  }
}
