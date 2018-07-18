using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NoiseLayer))]
[CanEditMultipleObjects]
public class NoiseLayerPropertyDrawer : PropertyDrawer {

  private void OnEnable() {
    Debug.Log("Enabling");
  }
  
  public override void OnGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
  ) {
    EditorGUI.BeginProperty(position, label, property);

    var indent = EditorGUI.indentLevel;
    EditorGUI.indentLevel = 0;

    var first_row  = 0;
    var second_row = position.height;
    var third_row  = position.height * 2;

    var half_width = position.width * 0.5f;

    var left  = position.x;
    var right = left + half_width;

    var octaves_rect     = new Rect(left,  first_row,  half_width, position.height);
    var scale_rect       = new Rect(right, first_row,  half_width, position.height);
    var persistance_rect = new Rect(left,  second_row, half_width, position.height);
    var lacunarity_rect  = new Rect(right, second_row, half_width, position.height);
    var root_rect        = new Rect(left,  third_row,  half_width, position.height);
    var magnitude_rect   = new Rect(right, third_row,  half_width, position.height);

    EditorGUI.PropertyField(octaves_rect,     property.FindPropertyRelative("Octaves")    );
    EditorGUI.PropertyField(scale_rect,       property.FindPropertyRelative("Scale")      );
    EditorGUI.PropertyField(persistance_rect, property.FindPropertyRelative("Persistance"));
    EditorGUI.PropertyField(lacunarity_rect,  property.FindPropertyRelative("Lacunarity") );
    EditorGUI.PropertyField(root_rect,        property.FindPropertyRelative("Root")       );
    EditorGUI.PropertyField(magnitude_rect,   property.FindPropertyRelative("Magnitude")  );

    EditorGUI.indentLevel = indent;

    EditorGUI.EndProperty();
  }
}