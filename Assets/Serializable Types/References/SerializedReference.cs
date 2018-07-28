using UnityEngine;

public abstract class SerializedReference<t, T> :
  ScriptableObject
  where T : SerializedVariable<t>
{
  public bool UseLocal = true;
  public t    Local          ;
  public T    Shared         ;

  public t Value {
    get { return UseLocal ? Local : Shared.Value; }
  }
}