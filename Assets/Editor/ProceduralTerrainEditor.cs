using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(ProceduralTerrain), true, isFallback = true)]
[CanEditMultipleObjects]
public class ProceduralTerrainEditor: Editor {

  private ProceduralTerrain Terrain;

  private ReorderableList PerlinNoiseLayers;

  private void OnEnable() {
    Terrain = (ProceduralTerrain) target;

    PerlinNoiseLayers = new ReorderableList(
      serializedObject,
      serializedObject.FindProperty("PerlinNoiseLayers"),
      true, true, true, true
    );

    PerlinNoiseLayers.drawHeaderCallback = rect =>
			EditorGUI.LabelField(rect, "Perlin Noise Layers", EditorStyles.boldLabel);

    PerlinNoiseLayers.drawElementCallback = (
      Rect rect,
      int index,
      bool isActive,
      bool isFocused
    ) =>
      EditorGUI.ObjectField(
        new Rect (
          rect.x,
          rect.y,
          rect.width,
          EditorGUIUtility.singleLineHeight
        ),
        PerlinNoiseLayers.serializedProperty.GetArrayElementAtIndex(index),
        GUIContent.none
      );
  }

  public override void OnInspectorGUI() {
    serializedObject.Update();

    PerlinNoiseLayers.DoLayoutList();

    EditorGUI.BeginChangeCheck();

    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainSize")  );
    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainHeight"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("CellSize")     );

    serializedObject.ApplyModifiedProperties();

    ProceduralTerrain procedural_terrain = serializedObject.targetObject as ProceduralTerrain;

    if (GUILayout.Button("Generate") || (EditorGUI.EndChangeCheck() && procedural_terrain.AutoUpdate))
      procedural_terrain.GenerateTerrain();
  }
}
