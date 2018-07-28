using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainLayer_Reference), isFallback = true)]
[CanEditMultipleObjects]
public class TerrainLayer_Editor :
  Drawable_Editor<TerrainLayer_Reference, TerrainLayer_Variable>
{
  public TerrainLayer_Editor() : base() {
    states = new Dictionary<string, state>() {
      { "Octaves",     state.EDITING },
      { "Scale",       state.EDITING },
      { "Persistance", state.EDITING },
      { "Lacunarity",  state.EDITING },
      { "Root",        state.EDITING },
      { "Magnitude",   state.EDITING }
    };

    names = new Dictionary<string, string>() {
      { "Octaves",     "New Octaves"     },
      { "Scale",       "New Scale"       },
      { "Persistance", "New Persistance" },
      { "Lacunarity",  "New Lacunarity"  },
      { "Root",        "New Root"        },
      { "Magnitude",   "New Magnitude"   }
    };

    left = 5;
  }

  public override void OnInspectorGUI() {
    var property = target as TerrainLayer_Reference;
    
    int y = top; 

    if (AssetDatabase.IsNativeAsset(property)) {
      if (property.IsHydrated == false) {
        AssetDatabase.AddObjectToAsset(property.Octaves,     property);
        AssetDatabase.AddObjectToAsset(property.Scale,       property);
        AssetDatabase.AddObjectToAsset(property.Persistance, property);
        AssetDatabase.AddObjectToAsset(property.Lacunarity,  property);
        AssetDatabase.AddObjectToAsset(property.Root,        property);
        AssetDatabase.AddObjectToAsset(property.Magnitude,   property);

        property.IsHydrated = true;

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh()   ;
      }

        Int_MinMax_Field("", "Octaves",     property.Octaves,     left, y)          ;
      Float_MinMax_Field("", "Scale",       property.Scale,       left, y += height);
      Float_MinMax_Field("", "Persistance", property.Persistance, left, y += height);
      Float_MinMax_Field("", "Lacunarity",  property.Lacunarity,  left, y += height);
      Float_MinMax_Field("", "Root",        property.Root,        left, y += height);
      Float_MinMax_Field("", "Magnitude",   property.Magnitude,   left, y += height);
    }
  }
}