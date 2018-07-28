using System;

using UnityEngine;

[CreateAssetMenu(
  fileName = "NEW Terrain Layer {Container} [Variable]",
  menuName = "MinTuts/Serializable Types/Variables/Terrain/Container",
  order    =  7
)]
[Serializable]
public class TerrainLayer_Container_Variable :
  ScriptableObject,
  IHydratable
{
  public TerrainLayer_Variable ExtrudeMap;

  public Int_MinMax_Reference   ExtrudeOctaves;
  public Float_MinMax_Reference ExtrudeScale  ;

  public Float_MinMax_Reference ExtrudePersistance;
  public Float_MinMax_Reference ExtrudeLacunarity ;

  public Float_MinMax_Reference ExtrudeRoot;
  public Float_MinMax_Reference ExtrudeMagnitude;

  public bool IsHydrated {
    get { return is_hydrated; }
    set { is_hydrated = value; }
  }

  public void Hydrate() {
    if(IsHydrated == false) {
      ExtrudeMap = ScriptableObject.CreateInstance<TerrainLayer_Variable>();
      ExtrudeMap.Hydrate();
      ExtrudeMap.IsHydrated = true;

      ExtrudeOctaves = ScriptableObject.CreateInstance<Int_MinMax_Reference>()  ;
      ExtrudeOctaves.Hydrate();
      ExtrudeOctaves.IsHydrated = true;

      ExtrudeScale = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeScale.Hydrate();
      ExtrudeScale.IsHydrated = true;

      ExtrudePersistance = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudePersistance.Hydrate();
      ExtrudePersistance.IsHydrated = true;

      ExtrudeLacunarity = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeLacunarity.Hydrate();
      ExtrudeLacunarity.IsHydrated = true;

      ExtrudeRoot = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeRoot.Hydrate();
      ExtrudeRoot.IsHydrated = true;

      ExtrudeMagnitude = ScriptableObject.CreateInstance<Float_MinMax_Reference>();
      ExtrudeMagnitude.Hydrate();
      ExtrudeMagnitude.IsHydrated = true;
    }
  }

  private void Awake()    => Hydrate();
  private void OnEnable() => Hydrate();

  [SerializeField] private bool is_hydrated = false;
}