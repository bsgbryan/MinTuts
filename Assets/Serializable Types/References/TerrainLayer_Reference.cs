using System;

using UnityEngine;

[CreateAssetMenu(
  fileName = "NEW Terrain Layer [Reference]",
  menuName = "MinTuts/Serializable Types/References/Terrain/Layer",
  order    =  1
)]
[Serializable]
public class TerrainLayer_Reference :
  CanBeLocalOrShared<TerrainLayer_Variable>,
  IHydratable
{
  public TerrainLayer_Reference() { }

  public Int_MinMax_Reference Octaves {
    get { return UseLocal ? octaves : Shared.Octaves; }
    set { octaves = value; }
  }

  public Float_MinMax_Reference Scale {
    get { return UseLocal ? scale : Shared.Scale; }
    set { scale = value; }
  }

  public Float_MinMax_Reference Persistance {
    get { return UseLocal ? persistance : Shared.Persistance; }
    set { persistance = value; }
  }

  public Float_MinMax_Reference Lacunarity {
    get { return UseLocal ? lacunarity : Shared.Lacunarity; }
    set { lacunarity = value; }
  }

  public Float_MinMax_Reference Root {
    get { return UseLocal ? root : Shared.Root; }
    set { root = value; }
  }

  public Float_MinMax_Reference Magnitude {
    get { return UseLocal ? magnitude : Shared.Magnitude; }
    set { magnitude = value; }
  }

  public bool IsHydrated {
    get { return isHydrated; }
    set { isHydrated = value; }
  }

  public void Hydrate() {
    if (IsHydrated == false) {
      name = "NEW Terrain Layer [Reference]";

      Octaves = ScriptableObject.CreateInstance<Int_MinMax_Reference>()  ;
      Octaves.Hydrate()         ;
      Octaves.name = "Octaves" ;
      Octaves.IsHydrated = true;

      Scale = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Scale.Hydrate()        ;
      Scale.name = "Scale"   ;
      Scale.IsHydrated = true;

      Persistance = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Persistance.Hydrate()           ;
      Persistance.name = "Persistance";
      Persistance.IsHydrated = true   ;

      Lacunarity = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Lacunarity.Hydrate()          ;
      Lacunarity.name = "Lacunarity";
      Lacunarity.IsHydrated = true  ;

      Root = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Root.Hydrate()        ;
      Root.name = "Root"    ;
      Root.IsHydrated = true;

      Magnitude = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      Magnitude.Hydrate()         ;
      Magnitude.name = "Magnitude";
      Magnitude.IsHydrated = true ;
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();

  [SerializeField] private Int_MinMax_Reference   octaves    ;
  [SerializeField] private Float_MinMax_Reference scale      ;
  [SerializeField] private Float_MinMax_Reference persistance;
  [SerializeField] private Float_MinMax_Reference lacunarity ;
  [SerializeField] private Float_MinMax_Reference root       ;
  [SerializeField] private Float_MinMax_Reference magnitude  ;

  [SerializeField] private bool isHydrated = false;
}