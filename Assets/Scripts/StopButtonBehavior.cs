using UnityEngine;
using UniRx;

public class StopButtonBehavior : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    this.gameObject.SetActive(SummonState.summon.HasValue);

    SummonState.summon.Subscribe(maybe =>
    {
      this.gameObject.SetActive(maybe.HasValue);
    });
  }


  public void OnClick()
  {
    SummonState.Reset();
  }
}
