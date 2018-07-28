using System;

using UnityEngine;

[CreateAssetMenu(
  fileName = "NEW Terrain Layer [Container Reference]",
  menuName = "MinTuts/Serializable Types/References/Terrain/Layer Container",
  order    =  2
)]
[Serializable]
public class TerrainLayer_Container_Reference :
  CanBeLocalOrShared<TerrainLayer_Container_Variable>,
  IHydratable
{
  public TerrainLayer_Container_Reference() { }

  public Int_MinMax_Reference ExtrudeOctaves {
    get { return UseLocalExtrudeMap ? extrudeOctaves : sharedExtrudeMap.Octaves; }
    set { extrudeOctaves = value; }
  }

  public Float_MinMax_Reference ExtrudeScale {
    get { return UseLocalExtrudeMap ? extrudeScale : sharedExtrudeMap.Scale; }
    set { extrudeScale = value; }
  }

  public Float_MinMax_Reference ExtrudePersistance {
    get { return UseLocalExtrudeMap ? extrudePersistance : sharedExtrudeMap.Persistance; }
    set { extrudePersistance = value; }
  }

  public Float_MinMax_Reference ExtrudeLacunarity {
    get { return UseLocalExtrudeMap ? extrudeLacunarity : sharedExtrudeMap.Lacunarity; }
    set { extrudeLacunarity = value; }
  }

  public Float_MinMax_Reference ExtrudeRoot {
    get { return UseLocalExtrudeMap ? extrudeRoot : sharedExtrudeMap.Root; }
    set { extrudeRoot = value; }
  }

  public Float_MinMax_Reference ExtrudeMagnitude {
    get { return UseLocalExtrudeMap ? extrudeMagnitude : sharedExtrudeMap.Magnitude; }
    set { extrudeMagnitude = value; }
  }

  public TerrainLayer_Reference SharedExtrudeMap {
    get { return sharedExtrudeMap; }
    set { sharedExtrudeMap = value; }
  }

  public bool IsHydrated {
    get { return isHydrated; }
    set { isHydrated = value; }
  }

  public bool UseLocalExtrudeMap = true;

  public void Hydrate() {
    if (IsHydrated == false) {
      name = "NEW Terrain Layer [Container Reference]";

      ExtrudeOctaves = ScriptableObject.CreateInstance<Int_MinMax_Reference>();
      ExtrudeOctaves.Hydrate()        ;
      ExtrudeOctaves.name = "Octaves" ;
      ExtrudeOctaves.IsHydrated = true;

      ExtrudeScale = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeScale.Hydrate()        ;
      ExtrudeScale.name = "Scale"   ;
      ExtrudeScale.IsHydrated = true;

      ExtrudePersistance = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudePersistance.Hydrate()           ;
      ExtrudePersistance.name = "Persistance";
      ExtrudePersistance.IsHydrated = true   ;

      ExtrudeLacunarity = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeLacunarity.Hydrate()          ;
      ExtrudeLacunarity.name = "Lacunarity";
      ExtrudeLacunarity.IsHydrated = true  ;

      ExtrudeRoot = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeRoot.Hydrate()        ;
      ExtrudeRoot.name = "Root"    ;
      ExtrudeRoot.IsHydrated = true;

      ExtrudeMagnitude = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeMagnitude.Hydrate()         ;
      ExtrudeMagnitude.name = "Magnitude";
      ExtrudeMagnitude.IsHydrated = true ;
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();
  
  [SerializeField] private TerrainLayer_Reference sharedExtrudeMap  ;
  [SerializeField] private Int_MinMax_Reference   extrudeOctaves    ;
  [SerializeField] private Float_MinMax_Reference extrudeScale      ;
  [SerializeField] private Float_MinMax_Reference extrudePersistance;
  [SerializeField] private Float_MinMax_Reference extrudeLacunarity ;
  [SerializeField] private Float_MinMax_Reference extrudeRoot       ;
  [SerializeField] private Float_MinMax_Reference extrudeMagnitude  ;

  [SerializeField] private bool isHydrated = false;
}