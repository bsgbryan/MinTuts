using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class Float_Drawable_PropertyDrawer : MinMax_PropertyDrawer<Float_MinMax_Reference, Float_MinMax_Variable> {
  protected void CreateFetchAndClearAsset(string name, Float_MinMax_Reference reference) {
    string path = $"Resources/Serialized Data/Variables/Float/{name} {count++}.asset";

    Float_MinMax_Variable variable = ScriptableObject.CreateInstance<Float_MinMax_Variable>();

    variable.Min   = reference.Min;
    variable.Value = reference.Value;
    variable.Max   = reference.Max;

    AssetDatabase.CreateAsset(variable, path);

    Float_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Float_MinMax_Variable>(path);

    reference.UseLocal = false;
    reference.Shared   = loaded;

    Clear(name);
  }

  protected Float_MinMax_Variable DrawObjectFieldForVariable(UnityEngine.Object value, Rect position) {
    return EditorGUI.ObjectField(
      new Rect(position.x + 20f, position.y, 252f, 16f),
      value,
      typeof(Float_MinMax_Variable)
    ) as Float_MinMax_Variable;
  }

  protected void DoOnGUI(
    Rect position,
    SerializedProperty property,
    Action<string, Float_MinMax_Reference, Rect> action,
    GUIContent label
  ) {
    EditorGUI.BeginProperty(position, label, property);

    Float_MinMax_Reference reference = InitializeReference(property, property.name);

    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    DrawLocalSharedButtons(property.name, reference, position);

    if (reference.UseLocal)
      action.Invoke(property.name, property.objectReferenceValue as Float_MinMax_Reference, position);
    else
      reference.Shared = DrawObjectFieldForVariable(reference, position);

    property.objectReferenceValue = reference as UnityEngine.Object;

    property.serializedObject.ApplyModifiedProperties();
    
    EditorGUI.EndProperty();
  }
}