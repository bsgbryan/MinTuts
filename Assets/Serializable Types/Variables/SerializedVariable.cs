using UnityEngine;
using UnityEditor;

using System;

[Serializable]
public class SerializedVariable<t> :
  ScriptableObject
{
  public t Value;
}