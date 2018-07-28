using UnityEngine;
using UnityEditor;

using System;

[CreateAssetMenu(
  fileName = "NEW Bool [Variable]",
  menuName = "MinTuts/Serializable Types/Variables/Bool",
  order    =  10
)]
[Serializable]
public class Bool_Variable : SerializedVariable<bool> {
  public Bool_Variable() { }
}