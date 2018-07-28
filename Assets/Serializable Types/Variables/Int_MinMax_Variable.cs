using System;

using UnityEngine;
using UnityEditor;

[CreateAssetMenu(
  fileName = "NEW Int (Min-Max) [Variable]",
  menuName = "MinTuts/Serializable Types/Variables/Min-Max/Int",
  order    =  9
)]
[Serializable]
public class Int_MinMax_Variable :
  ScriptableObject,
  IHydratable
{
  public Int_MinMax_Variable() { }

  public int Min  ;
  public int Max  ;
  public int Value;

  public bool IsHydrated {
    get { return is_hydrated; }
    set { is_hydrated = value; }
  }

  public void Hydrate() {
    if (IsHydrated == false) {
      Min   =  0;
      Max   = 10;
      Value =  5;
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();

  [SerializeField] private bool is_hydrated = false;
}