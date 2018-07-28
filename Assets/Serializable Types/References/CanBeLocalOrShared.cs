using System;

using UnityEngine;

[Serializable]
public class CanBeLocalOrShared<V> :
  Root_Reference
{
  public bool UseLocal = true;

  public V Shared;
}