using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class MinMax_PropertyDrawer<R, V> :
  Drawable_PropertyDrawer<R, V>
  where R : CanBeLocalOrShared<V>
{
  public MinMax_PropertyDrawer() : base() {
    states = new Dictionary<string, state>() {
      { "Min",   state.EDITING },
      { "Max",   state.EDITING },
      { "Value", state.EDITING }
    };

    names = new Dictionary<string, string>() {
      { "Min",   "New Min"   },
      { "Max",   "New Max"   },
      { "Value", "New Value" }
    };
  }

  protected Int_MinMax_Reference Int_MinMax_Field(
    string context,
    string name,
    Int_MinMax_Reference input,
    int y
  ) {
    Int_MinMax_Reference property = input;

    string contextual_name = $"{context}{name}";
    
    EditorGUI.PrefixLabel(
      new Rect(15, y, 80, 16),
      new GUIContent(name)
    );

    if (GUI.Button(new Rect(110, y, 20, 16), property.UseLocal ? "L" : "S")) {
      GenericMenu menu = new GenericMenu();

      menu.AddItem(
        new GUIContent("Local Value"),
        property.UseLocal == true,
        (object result) => property.UseLocal = true,
         null
      );

      menu.AddItem(
        new GUIContent("Shared Value"),
        property.UseLocal == false,
        (object result) => {
          if (property != null)
            states[contextual_name] = state.EDITING;
          else
            states[contextual_name] = state.NAMING;

          property.UseLocal = false;
        },
        null
      );

      menu.ShowAsContext();
    }

    if (property.UseLocal) {
      if (states[contextual_name] == state.EDITING) {
        property.Min = EditorGUI.IntField(
          new Rect(135, y, 25, 16),
          property.Min
        );

        property.Max = EditorGUI.IntField(
          new Rect(165, y, 25, 16),
          property.Max
        );

        property.Value = EditorGUI.IntSlider(
          new Rect(195, y, 220, 16),
          property.Value,
          property.Min,
          property.Max
        );

        if (GUI.Button(new Rect(420, y, 20, 16), "N"))
          states[contextual_name] = state.NAMING;
      } else {
        names[contextual_name] = EditorGUI.TextField(new Rect(135, y, 207, 16), names[contextual_name]);

        if (GUI.Button(new Rect(347, y, 20, 16), "S")) {
          string path = $"Assets/Serialized Data/Variables/{context}/{names[contextual_name]}.asset";

          Int_MinMax_Variable variable = ScriptableObject.CreateInstance<Int_MinMax_Variable>();

          variable.name  = names[contextual_name];
          variable.Min   = property.Min          ;
          variable.Max   = property.Max          ;
          variable.Value = property.Value        ;

          AssetDatabase.CreateAsset(variable, path);
          AssetDatabase.SaveAssets()               ;
          AssetDatabase.Refresh()                  ;

          Int_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Int_MinMax_Variable>(path);

          property.UseLocal = false ;
          property.Shared   = loaded;

          states[contextual_name] = state.EDITING;
          names[contextual_name]  = ""           ;
        } else if (GUI.Button(new Rect(372, y, 20, 16), "C")) {
          states[contextual_name] = state.EDITING;
          names[contextual_name]  = ""           ;
        }
      }
    } else {
      property.Shared = EditorGUI.ObjectField(
        new Rect(135, y, 252, 16),
        property.Shared,
        typeof(Int_MinMax_Variable),
        false
      ) as Int_MinMax_Variable;
    }

    return property;
  }

  protected Float_MinMax_Reference Float_MinMax_Field(
    string context,
    string name,
    Float_MinMax_Reference input,
    int y
  ) {
    Float_MinMax_Reference MMF = input;

    string contextual_name = $"{context}{name}";
    
    EditorGUI.PrefixLabel(
      new Rect(15, y, 80, 16),
      new GUIContent(name)
    );

    if (GUI.Button(new Rect(110, y, 20, 16), MMF.UseLocal ? "L" : "S")) {
      GenericMenu menu = new GenericMenu();

      menu.AddItem(
         new GUIContent("Local Value"),
         MMF.UseLocal == true,
        (object result) => MMF.UseLocal = true,
         null
      );

      menu.AddItem(
         new GUIContent("Shared Value"),
         MMF.UseLocal == false,
        (object result) => {
          if (MMF != null)
            states[contextual_name] = state.EDITING;
          else
            states[contextual_name] = state.NAMING;

          MMF.UseLocal = false;
        },
        null
      );

      menu.ShowAsContext();
    }

    if (MMF.UseLocal) {
      if (states[contextual_name] == state.EDITING) {
        MMF.Min = EditorGUI.FloatField(
          new Rect(135, y, 25, 16),
          MMF.Min
        );

        MMF.Max = EditorGUI.FloatField(
          new Rect(165, y, 25, 16),
          MMF.Max
        );

        MMF.Value = EditorGUI.Slider(
          new Rect(195, y, 220, 16),
          MMF.Value,
          MMF.Min,
          MMF.Max
        );

        if (GUI.Button(new Rect(420, y, 20, 16), "N"))
          states[contextual_name] = state.NAMING;
      } else {
        names[contextual_name] = EditorGUI.TextField(new Rect(135, y, 207, 16), names[contextual_name]);

        if (GUI.Button(new Rect(347, y, 20, 16), "S")) {
          string path = $"Assets/Serialized Data/Variables/{context}/{names[contextual_name]}.asset";

          Float_MinMax_Variable variable = ScriptableObject.CreateInstance<Float_MinMax_Variable>();

          variable.name  = names[contextual_name];
          variable.Min   = MMF.Min               ;
          variable.Max   = MMF.Max               ;
          variable.Value = MMF.Value             ;

          AssetDatabase.CreateAsset(variable, path);
          AssetDatabase.SaveAssets()               ;
          AssetDatabase.Refresh()                  ;

          Float_MinMax_Variable loaded = AssetDatabase.LoadAssetAtPath<Float_MinMax_Variable>(path);

          MMF.UseLocal = false ;
          MMF.Shared   = loaded;

          states[contextual_name] = state.EDITING;
          names[contextual_name]  = ""           ;
        } else if (GUI.Button(new Rect(372, y, 20, 16), "C")) {
          states[contextual_name] = state.EDITING;
          names[contextual_name]  = ""           ;
        }
      }
    } else {
      MMF.Shared = EditorGUI.ObjectField(
        new Rect(135, y, 252, 16),
        MMF.Shared,
        typeof(Float_MinMax_Variable),
        false
      ) as Float_MinMax_Variable;
    }

    return MMF;
  }
}