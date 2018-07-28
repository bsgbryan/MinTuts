using UnityEditor;
using UnityEngine;

public class Drawable_PropertyDrawer<R, V> :
  Base_PropertyDrawer<R>
  where R : CanBeLocalOrShared<V>
{
  protected void DrawLocalSharedButtons(string name, R property, Rect position) {
    if (GUI.Button(new Rect(110, position.y, 20, 16), property.UseLocal ? "L" : "S")) {
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
}