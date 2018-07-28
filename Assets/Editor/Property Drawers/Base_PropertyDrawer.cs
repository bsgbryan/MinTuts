using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class Base_PropertyDrawer<R> :
  PropertyDrawer
  where R : class
{
  protected enum state { EDITING, NAMING };

  protected Dictionary<string, state>  states;
  protected Dictionary<string, string> names ;

  protected static int count = 0;

  protected R InitializeReference(SerializedProperty property, string contextual_name) {
    R reference;

    if (property.objectReferenceValue == null) {
      reference = ScriptableObject.CreateInstance(typeof(R)) as R;

      string path = $"Assets/Serialized Data/References/{contextual_name}.asset";

      AssetDatabase.CreateAsset(reference as UnityEngine.Object, path);
      
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh()   ;
      
      property.objectReferenceValue = AssetDatabase.LoadAssetAtPath(path, typeof(R));
      
      property.serializedObject.ApplyModifiedProperties();
    } else {
      reference = property.objectReferenceValue as R;
    }

    return reference;
  }

  protected void Clear(string name) {
    states[name] = state.EDITING;
    names[name]  = ""           ;
  }
}
