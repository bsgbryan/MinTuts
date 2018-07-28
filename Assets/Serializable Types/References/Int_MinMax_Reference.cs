using System;

using UnityEngine;
using UnityEditor;

[CreateAssetMenu(
  fileName = "NEW Int [Min-Max Reference]",
  menuName = "MinTuts/Serializable Types/References/Min-Max/Int",
  order    =  4
)]
[Serializable]
public class Int_MinMax_Reference :
  CanBeLocalOrShared<Int_MinMax_Variable>,
  IHydratable
{
  public Int_MinMax_Reference() { }

  public int Min {
    get { return UseLocal ? min : Shared.Min; }
    set { min = value; }
  }

  public int Max {
    get { return UseLocal ? max : Shared.Max; }
    set { max = value; }
  }

  public int Value {
    get { return UseLocal ? val : Shared.Value; }
    set { val = value; }
  }

  public bool IsHydrated {
    get { return UseLocal ? isHydrated : Shared.IsHydrated; }
    set { isHydrated = value; }
  }

  public void Hydrate() {
    if (IsHydrated == false) {
      this.name = "NEW Int [Min-Max Reference]";
      
      min =  0;
      max = 10;
      val =  5;
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();

  [SerializeField] private int min;
  [SerializeField] private int max;
  [SerializeField] private int val;

  [SerializeField] private bool isHydrated = false;
}