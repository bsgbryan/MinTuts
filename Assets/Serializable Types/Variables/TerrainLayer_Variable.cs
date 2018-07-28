using System;

using UnityEngine;

[CreateAssetMenu(
  fileName = "NEW Terrain Layer [Variable]",
  menuName = "MinTuts/Serializable Types/Variables/Terrain/Layer",
  order    =  6
)]
[Serializable]
public class TerrainLayer_Variable :
  ScriptableObject,
  IHydratable
{
  public Int_MinMax_Reference   Octaves;
  public Float_MinMax_Reference Scale  ;

  public Float_MinMax_Reference Persistance;
  public Float_MinMax_Reference Lacunarity ;

  public Float_MinMax_Reference Root     ;
  public Float_MinMax_Reference Magnitude;

  public bool IsHydrated {
    get { return is_hydrated; }
    set { is_hydrated = value; }
  }

  public void Hydrate() {
    if (IsHydrated == false) {
      Octaves = ScriptableObject.CreateInstance<Int_MinMax_Reference>();
      Octaves.name = "Octaves";
      Octaves.Hydrate();

      Scale = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Scale.name = "Scale";
      Scale.Hydrate();

      Persistance = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Persistance.name = "Persistance";
      Persistance.Hydrate();

      Lacunarity = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Lacunarity.name = "Lacunarity";
      Lacunarity.Hydrate();

      Root = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Root.name = "Root";
      Root.Hydrate();

      Magnitude = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Magnitude.name = "Magnitude";
      Magnitude.Hydrate();
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();

  [SerializeField] private bool is_hydrated = false;
}