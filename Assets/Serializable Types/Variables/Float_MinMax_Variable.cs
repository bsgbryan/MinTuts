using System;

using UnityEngine;
using UnityEditor;

[CreateAssetMenu(
  fileName = "NEW Float (Min-Max) [Variable]",
  menuName = "MinTuts/Serializable Types/Variables/Min-Max/Float",
  order    =  8
)]
[Serializable]
public class Float_MinMax_Variable :
  ScriptableObject,
  IHydratable
{
  public Float_MinMax_Variable() { }

  public float Min  ;
  public float Max  ;
  public float Value;

  public bool IsHydrated {
    get { return is_hydrated; }
    set { is_hydrated = value; }
  }

  public void Hydrate() {
    if (IsHydrated == false) {
      Min   = 0f  ;
      Max   = 1f  ;
      Value = 0.5f;
    }
  }

  private void Awake()    => Hydrate(); 
  private void OnEnable() => Hydrate();

  [SerializeField] private bool is_hydrated = false;
}