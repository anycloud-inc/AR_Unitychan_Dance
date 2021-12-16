using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UniRx;

[RequireComponent(typeof(ARPlaneManager))]
public class PlanesController : MonoBehaviour
{
  ARPlaneManager manager;
  void Awake()
  {
    manager = GetComponent<ARPlaneManager>();

    SummonState.summon.Subscribe(maybe =>
    {
      this.SetPlanesActive(!maybe.HasValue);
    });
  }

  void SetPlanesActive(bool value)
  {
    manager.enabled = value;
    foreach (var plane in manager.trackables)
      plane.gameObject.SetActive(value);
  }

}
