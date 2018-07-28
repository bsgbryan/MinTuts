using System;

using UnityEditor;
using UnityEngine;

public class Int_MinMax_PropertyDrawer : Int_Drawable_PropertyDrawer {
  public void DrawRowFor_Local_Int_MinMax_Values(string name, Int_MinMax_Reference reference, Rect position) {
    if (states[name] == state.EDITING) {
      reference.Min = EditorGUI.IntField(new Rect(position.x + 20f, position.y, 60f, 16f), reference.Min);
      reference.Max = EditorGUI.IntField(new Rect(position.x + 80f, position.y, 60f, 16f), reference.Max);

      reference.Value = (int) GUI.HorizontalSlider(
        new Rect(position.x + 140f, position.y, 100f, 16f),
        reference.Value,
        reference.Min,
        reference.Max
      );

      reference.Value = EditorGUI.IntField(
        new Rect(position.x + 240f, position.y, 80f, 16f),
        reference.Value
      );

      if (GUI.Button(new Rect(position.x + 325f, position.y, 20f, 16f), "N"))
        states[name] = state.NAMING;
    } else {
      names[name] = EditorGUI.TextField(
        new Rect(position.x + 20f, position.y, 207.5f, 16f),
        name
      );

      if (GUI.Button(new Rect(position.x + 230f, position.y, 20f, 16f), "S"))
        CreateFetchAndClearAsset(name, reference);

      if (GUI.Button(new Rect(position.x + 250f, position.y, 20f, 16f), "C"))
        Clear(name);
    }
  }

  private void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    DoOnGUI(
      position,
      property,
      new Action<string, Int_MinMax_Reference, Rect>(DrawRowFor_Local_Int_MinMax_Values),
      label
    );
  }
}