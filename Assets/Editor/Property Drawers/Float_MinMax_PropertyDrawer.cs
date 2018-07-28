using System;

using UnityEditor;
using UnityEngine;

public class Float_MinMax_PropertyDrawer : Float_Drawable_PropertyDrawer {
  public void DrawRowFor_Local_Float_MinMax_Values(
    string name,
    Float_MinMax_Reference reference,
    Rect position
  ) {
    if (states[name] == state.EDITING) {
      reference.Min = EditorGUI.FloatField(
        new Rect(position.x + 20f, position.y, 60f, 16f),
        reference.Min
      );
      reference.Max = EditorGUI.FloatField(
        new Rect(position.x + 80f, position.y, 60f, 16f),
        reference.Max
      );

      reference.Value = GUI.HorizontalSlider(
        new Rect(position.x + 140f, position.y, 100f, 16f),
        reference.Value,
        reference.Min,
        reference.Max
      );

      reference.Value = EditorGUI.FloatField(
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
      new Action<string, Float_MinMax_Reference, Rect>(DrawRowFor_Local_Float_MinMax_Values),
      label
    );
  }
}