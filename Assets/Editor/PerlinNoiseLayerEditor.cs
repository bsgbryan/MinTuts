using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PerlinNoiseLayer), true, isFallback = true)]
[CanEditMultipleObjects]
public class PerlinNoiseLayerEditor : Editor {

  public override void OnInspectorGUI() {
    serializedObject.Update();

    EditorGUILayout.ObjectField(  serializedObject.FindProperty("Noise"),         new GUIContent("Noise")          );
    EditorGUILayout.PropertyField(serializedObject.FindProperty("AutoUpdate"),    new GUIContent("Auto Update")    );
    EditorGUILayout.PropertyField(serializedObject.FindProperty("UseFalloffMap"), new GUIContent("Use Falloff Map"));

    if (serializedObject.FindProperty("UseFalloffMap").boolValue == true)
      EditorGUILayout.ObjectField(serializedObject.FindProperty("FalloffMap"), new GUIContent("Falloff Map"));
    
    serializedObject.ApplyModifiedProperties();
  }
}