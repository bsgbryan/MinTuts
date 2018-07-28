using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainLayer_Container_Reference), isFallback = true)]
[CanEditMultipleObjects]
public class TerrainLayer_Container_Editor :
  Drawable_Editor<TerrainLayer_Container_Reference, TerrainLayer_Container_Variable>
{
  private enum sculpt { EXTRUDE, CARVE  };

  private bool show_extrude_properties = true;

  private UnityEngine.Object[] asset;

  public TerrainLayer_Container_Editor() : base() {
    states = new Dictionary<string, state>() {
      { "ExtrudeOctaves",     state.EDITING },
      { "ExtrudeScale",       state.EDITING },
      { "ExtrudePersistance", state.EDITING },
      { "ExtrudeLacunarity",  state.EDITING },
      { "ExtrudeRoot",        state.EDITING },
      { "ExtrudeMagnitude",   state.EDITING }
    };

    names = new Dictionary<string, string>() {
      { "ExtrudeOctaves",     "New Extrude Octaves"     },
      { "ExtrudeScale",       "New Extrude Scale"       },
      { "ExtrudePersistance", "New Extrude Persistance" },
      { "ExtrudeLacunarity",  "New Extrude Lacunarity"  },
      { "ExtrudeRoot",        "New Extrude Root"        },
      { "ExtrudeMagnitude",   "New Extrude Magnitude"   }
    };

    left = 15;
  }

  public override void OnInspectorGUI() {
    var property = target as TerrainLayer_Container_Reference;

    var y = top;

    show_extrude_properties =  EditorGUI.Foldout(
      new Rect(left, y, 200, 16),
      show_extrude_properties,
      "Extrude"
    );

    if (property.UseLocalExtrudeMap && show_extrude_properties) {
      if (AssetDatabase.IsNativeAsset(property)) {
        if (property.IsHydrated == false) {
          AssetDatabase.AddObjectToAsset(property.ExtrudeOctaves,     property);
          AssetDatabase.AddObjectToAsset(property.ExtrudeScale,       property);
          AssetDatabase.AddObjectToAsset(property.ExtrudePersistance, property);
          AssetDatabase.AddObjectToAsset(property.ExtrudeLacunarity,  property);
          AssetDatabase.AddObjectToAsset(property.ExtrudeRoot,        property);
          AssetDatabase.AddObjectToAsset(property.ExtrudeMagnitude,   property);

          property.IsHydrated = true;

          AssetDatabase.SaveAssets();
          AssetDatabase.Refresh()   ;
        }

          Int_MinMax_Field("Extrude", "Octaves",     property.ExtrudeOctaves,     left, y += height);
        Float_MinMax_Field("Extrude", "Scale",       property.ExtrudeScale,       left, y += height);
        Float_MinMax_Field("Extrude", "Persistance", property.ExtrudePersistance, left, y += height);
        Float_MinMax_Field("Extrude", "Lacunarity",  property.ExtrudeLacunarity,  left, y += height);
        Float_MinMax_Field("Extrude", "Root",        property.ExtrudeRoot,        left, y += height);
        Float_MinMax_Field("Extrude", "Magnitude",   property.ExtrudeMagnitude,   left, y += height);
      }
    }
  }
}