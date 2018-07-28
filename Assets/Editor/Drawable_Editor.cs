using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Root_Reference))]
[CanEditMultipleObjects]
public class Drawable_Editor<R, V> :
  Editor
  where R : CanBeLocalOrShared<V>
{
  protected enum state { EDITING, NAMING };

  protected Dictionary<string, state>  states;
  protected Dictionary<string, string> names ;

  protected int left       ;
  protected int top    = 50;
  protected int height = 20;

  protected int row_height = 16;

  protected int label_width  =  60;
  protected int button_width =  20;
  protected int slider_width = 100;
  protected int value_width  =  65;
  protected int limit_width  =  30;

  protected int right_padding = 5;

  protected int text_width;

  protected int full_obj_width   ;
  protected int full_text_width  ;
  protected int full_label_width ;
  protected int full_button_width;
  protected int full_slider_width;
  protected int full_value_width ;
  protected int full_limit_width ;

  #region Int Min-Max Helper Methods
    protected void Int_MinMax_Field(
      string context,
      string name,
      Int_MinMax_Reference input,
      int x,
      int y
    ) {
      string contextual_name = $"{context}{name}";
      
      EditorGUI.PrefixLabel(
        new Rect(x, y, label_width, row_height),
        new GUIContent(name)
      );

      DrawLocal_Int_MinMax_SharedButtons(name, input, x += full_label_width, y);

      if (input.UseLocal) {
        if (states[contextual_name] == state.EDITING) {
          input.Min = EditorGUI.IntField(
            new Rect(x += full_button_width, y, limit_width, row_height),
            input.Min
          );

          input.Max = EditorGUI.IntField(
            new Rect(x += full_limit_width, y, limit_width, row_height),
            input.Max
          );

          input.Value = (int) GUI.HorizontalSlider(
            new Rect(x += full_limit_width, y, slider_width, row_height),
            input.Value,
            input.Min,
            input.Max
          );

          input.Value = EditorGUI.IntField(
            new Rect(x += full_slider_width, y, value_width, row_height),
            input.Value
          );

          if (GUI.Button(new Rect(x += full_value_width, y, button_width, row_height), "N"))
            states[contextual_name] = state.NAMING;
        } else {
          names[contextual_name] = EditorGUI.TextField(
            new Rect(x += full_button_width, y, text_width, row_height),
            names[contextual_name]
          );

          if (GUI.Button(new Rect(x += full_text_width, y, button_width, row_height), "S")) {
            string path = $"Assets/Serialized Data/Variables/Int/{names[contextual_name]}.asset";

            Int_MinMax_Variable variable = ScriptableObject.CreateInstance<Int_MinMax_Variable>();

            variable.name  = names[contextual_name];
            variable.Min   = input.Min;
            variable.Max   = input.Max;
            variable.Value = input.Value;

            AssetDatabase.CreateAsset(variable, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Int_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Int_MinMax_Variable>(path);

            input.UseLocal = false;
            input.Shared   = loaded;

            states[contextual_name] = state.EDITING;
            name = "";
          } else if (GUI.Button(new Rect(x += full_button_width, y, button_width, row_height), "C")) {
            states[contextual_name] = state.EDITING;
            name = "";
          }
        }
      } else {
        input.Shared = EditorGUI.ObjectField(
          new Rect(x += full_button_width, y, full_obj_width, row_height),
          input.Shared,
          typeof(Int_MinMax_Variable),
          false
        ) as Int_MinMax_Variable;
      }
    }

    protected void DrawLocal_Int_MinMax_SharedButtons(
      string name,
      Int_MinMax_Reference input,
      int x,
      int y
    ) {
      if (GUI.Button(new Rect(x, y, button_width, row_height), input.UseLocal ? "L" : "S")) {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(
          new GUIContent("Local Value"),
          input.UseLocal == true,
          (object _) => input.UseLocal = true,
           null
        );

        menu.AddItem(
          new GUIContent("Shared Value"),
          input.UseLocal == false,
          (object _) => {
            if (input != null)
              states[name] = state.EDITING;
            else
              states[name] = state.NAMING;

            input.UseLocal = false;
          },
          null
        );

        menu.ShowAsContext();
      }
    }

    protected void Int_MinMax_CreateFetchAndClearAsset(string name, Int_MinMax_Reference reference) {
      string path = $"Resources/Serialized Data/Variables/Int/{name}.asset";

      Int_MinMax_Variable variable = ScriptableObject.CreateInstance<Int_MinMax_Variable>();

      variable.Min   = reference.Min;
      variable.Max   = reference.Max;
      variable.Value = reference.Value;

      AssetDatabase.CreateAsset(variable, path);
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();

      Int_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Int_MinMax_Variable>(path);

      reference.UseLocal = false;
      reference.Shared   = loaded;

      Clear(name);
    }
  #endregion

  #region Float Min-Max Helper Methods
    protected void Float_MinMax_Field(
      string context,
      string name,
      Float_MinMax_Reference input,
      int x,
      int y
    ) {
      string contextual_name = $"{context}{name}";
      
      EditorGUI.PrefixLabel(
        new Rect(x, y, label_width, row_height),
        new GUIContent(name)
      );

      DrawLocal_Float_MinMax_SharedButtons(name, input, x += full_label_width, y);

      if (input.UseLocal) {
        if (states[contextual_name] == state.EDITING) {
          input.Min = EditorGUI.FloatField(
            new Rect(x += full_button_width, y, limit_width, row_height),
            input.Min
          );

          input.Max = EditorGUI.FloatField(
            new Rect(x += full_limit_width, y, limit_width, row_height),
            input.Max
          );

          input.Value = GUI.HorizontalSlider(
            new Rect(x += full_limit_width, y, slider_width, row_height),
            input.Value,
            input.Min,
            input.Max
          );

          input.Value = EditorGUI.FloatField(
            new Rect(x += full_slider_width, y, value_width, row_height),
            input.Value
          );

          if (GUI.Button(new Rect(x += full_value_width, y, button_width, row_height), "N"))
            states[contextual_name] = state.NAMING;
        } else {
          names[contextual_name] = EditorGUI.TextField(
            new Rect(x += full_button_width, y, text_width, row_height),
            names[contextual_name]
          );

          if (GUI.Button(new Rect(x += full_text_width, y, button_width, row_height), "S")) {
            string path = $"Assets/Serialized Data/Variables/Float/{names[contextual_name]}.asset";

            Float_MinMax_Variable variable = ScriptableObject.CreateInstance<Float_MinMax_Variable>();

            variable.name  = names[contextual_name];
            variable.Min   = input.Min;
            variable.Max   = input.Max;
            variable.Value = input.Value;

            AssetDatabase.CreateAsset(variable, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Float_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Float_MinMax_Variable>(path);

            input.UseLocal = false;
            input.Shared   = loaded;

            states[contextual_name] = state.EDITING;
            names[contextual_name]  = "";
          } else if (GUI.Button(new Rect(x += full_button_width, y, button_width, row_height), "C")) {
            states[contextual_name] = state.EDITING;
            names[contextual_name]  = "";
          }
        }
      } else {
        input.Shared = EditorGUI.ObjectField(
          new Rect(x += full_button_width, y, full_obj_width, row_height),
          input.Shared,
          typeof(Float_MinMax_Variable),
          false
        ) as Float_MinMax_Variable;
      }
    }

    protected void DrawLocal_Float_MinMax_SharedButtons(
      string name, 
      Float_MinMax_Reference property,
      int x,
      int y
    ) {
      if (GUI.Button(new Rect(x, y, button_width, row_height), property.UseLocal ? "L" : "S")) {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(
          new GUIContent("Local Value"),
          property.UseLocal == true,
          (object _) => property.UseLocal = true,
           null
        );

        menu.AddItem(
          new GUIContent("Shared Value"),
          property.UseLocal == false,
          (object _) => {
            if (property != null)
              states[name] = state.EDITING;
            else
              states[name] = state.NAMING;

            property.UseLocal = false;
          },
          null
        );

        menu.ShowAsContext();
      }
    }

    protected void Float_MinMax_CreateFetchAndClearAsset(string name, Float_MinMax_Reference reference) {
      string path = $"Resources/Serialized Data/Variables/Float/{name}.asset";

      Float_MinMax_Variable variable = ScriptableObject.CreateInstance<Float_MinMax_Variable>();

      variable.Min   = reference.Min;
      variable.Max   = reference.Max;
      variable.Value = reference.Value;

      AssetDatabase.CreateAsset(variable, path);
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();

      Float_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Float_MinMax_Variable>(path);

      reference.UseLocal = false;
      reference.Shared   = loaded;

      Clear(name);
    }
  #endregion

  protected void Clear(string name) {
    states[name] = state.EDITING;
    names[name]  = ""           ;
  }

  private void OnEnable() {
    full_label_width  = label_width  + right_padding;
    full_button_width = button_width + right_padding;
    full_slider_width = slider_width + right_padding;
    full_value_width  = value_width  + right_padding;
    full_limit_width  = limit_width  + right_padding;

    text_width = full_slider_width + (full_limit_width * 2) + value_width;

    full_text_width = text_width      + right_padding                   ;
    full_obj_width  = full_text_width + button_width - right_padding - 2;
  }
}