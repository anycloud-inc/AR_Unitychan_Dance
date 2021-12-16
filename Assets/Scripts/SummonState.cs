using UniRx;
using UnityEngine;

public delegate void Destroyer(GameObject x);


public struct Summon
{
  public GameObject obj;
  public Destroyer destoyer;

  public void Destroy()
  {
    destoyer(obj);
  }
}

public static class SummonState
{
  public static ReactiveProperty<Summon?> summon = new ReactiveProperty<Summon?>();

  public static void Reset()
  {
    if (!summon.HasValue) return;
    summon.Value.Value.Destroy();
    // summon.Value
    summon.Value = null;
  }
}