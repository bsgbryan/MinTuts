using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(ProceduralTerrain), true, isFallback = true)]
[CanEditMultipleObjects]
public class ProceduralTerrain_Editor: Editor {

  private ProceduralTerrain Terrain;

  private ReorderableList TerrainLayer_Containers;

  private void OnEnable() {
    Terrain = (ProceduralTerrain) target;

    TerrainLayer_Containers = new ReorderableList(
      serializedObject,
      serializedObject.FindProperty("TerrainLayer_Containers"),
      true, true, true, true
    );

    TerrainLayer_Containers.drawHeaderCallback = rect =>
      EditorGUI.LabelField(rect, "Terrain Layer Containers", EditorStyles.boldLabel);

    TerrainLayer_Containers.drawElementCallback = (
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
        TerrainLayer_Containers.serializedProperty.GetArrayElementAtIndex(index),
        GUIContent.none
      );
  }

  public override void OnInspectorGUI() {
    serializedObject.Update();

    if (TerrainLayer_Containers != null)
      TerrainLayer_Containers.DoLayoutList();

    EditorGUI.BeginChangeCheck();

    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainSize"))  ;
    EditorGUILayout.PropertyField(serializedObject.FindProperty("TerrainHeight"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("CellSize"))     ;

    serializedObject.ApplyModifiedProperties();

    ProceduralTerrain procedural_terrain = serializedObject.targetObject as ProceduralTerrain;

    if (GUILayout.Button("Generate") || (EditorGUI.EndChangeCheck() && procedural_terrain.AutoUpdate))
      procedural_terrain.GenerateTerrain();
  }
}
