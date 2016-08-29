using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineTrigger : MonoBehaviour {

  public CopsLine copsLine;
  public BoxCollider2D threshold;

  public List<Cop> cops;

  bool triggered = false;

  void OnTriggerEnter2D(Collider2D other) {
    if (triggered || other != threshold) return;

    copsLine.Stop();

    foreach (Cop cop in cops) {
      cop.Shoot();
    }

    triggered = true;
  }

}
