using System;

using UnityEngine;
using UnityEditor;

[CreateAssetMenu(
  fileName = "NEW Float [Min-Max Reference]",
  menuName = "MinTuts/Serializable Types/References/Min-Max/Float",
  order    =  3
)]
[Serializable] 
public class Float_MinMax_Reference :
  CanBeLocalOrShared<Float_MinMax_Variable>,
  IHydratable
{
  public Float_MinMax_Reference() { }

  public float Min {
    get { return UseLocal ? min : Shared.Min; }
    set { min = value; }
  }

  public float Max {
    get { return UseLocal ? max : Shared.Max; }
    set { max = value; }
  }

  public float Value {
    get { return UseLocal ? val : Shared.Value; }
    set { val = value; }
  }

  public bool IsHydrated { 
    get { return UseLocal ? isHydrated : Shared.IsHydrated; }
    set { isHydrated = value; }
  }

  public void Hydrate() {
    if (IsHydrated == false) {
      name = "NEW Float [Min-Max Reference]";

      min = 0f  ;
      max = 1f  ;
      val = 0.5f;
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();

  [SerializeField] private float min;
  [SerializeField] private float max;
  [SerializeField] private float val;

  [SerializeField] private bool isHydrated = false;
}