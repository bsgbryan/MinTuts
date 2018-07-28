using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class Int_Drawable_PropertyDrawer :
  MinMax_PropertyDrawer<Int_MinMax_Reference, Int_MinMax_Variable>
{
  protected void CreateFetchAndClearAsset(string name, Int_MinMax_Reference reference) {
    string path = $"Assets/Serialized Data/Variables/Float/{name}.asset";

    Int_MinMax_Variable variable = ScriptableObject.CreateInstance<Int_MinMax_Variable>();

    variable.Min   = reference.Min  ;
    variable.Value = reference.Value;
    variable.Max   = reference.Max  ;

    AssetDatabase.CreateAsset(variable, path);

    Int_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Int_MinMax_Variable>(path);

    reference.UseLocal = false ;
    reference.Shared   = loaded;

    Clear(name);
  }

  protected Int_MinMax_Variable DrawObjectFieldForVariable(UnityEngine.Object value, Rect position) {
    return EditorGUI.ObjectField(
      new Rect(position.x + 20f, position.y, 252f, 16f),
      value,
      typeof(Int_MinMax_Variable)
    ) as Int_MinMax_Variable;
  }

  protected void DoOnGUI(
    Rect position,
    SerializedProperty property,
    Action<string, Int_MinMax_Reference, Rect> action,
    GUIContent label
  ) {
    EditorGUI.BeginProperty(position, label, property);

    Int_MinMax_Reference reference = InitializeReference(property, property.name);

    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    DrawLocalSharedButtons(property.name, reference, position);

    if (reference.UseLocal)
      action.Invoke(property.name, property.objectReferenceValue as Int_MinMax_Reference, position);
    else
      reference.Shared = DrawObjectFieldForVariable(reference, position);

    property.objectReferenceValue = reference as UnityEngine.Object;
 
    property.serializedObject.ApplyModifiedProperties();
    
    EditorGUI.EndProperty();
  }
}