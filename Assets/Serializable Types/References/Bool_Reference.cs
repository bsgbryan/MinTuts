using UnityEngine;

using System;

[CreateAssetMenu(
  fileName = "NEW Bool [Reference]",
  menuName = "MinTuts/Serializable Types/References/Bool",
  order    = 5
)]
[Serializable]
public class Bool_Reference : SerializedReference<bool, Bool_Variable> {
  public Bool_Reference() { }
}