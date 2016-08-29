using UnityEngine;
using System.Collections;

public class CopShootingTrigger : MonoBehaviour {


  public BoxCollider2D threshold;
  public Cop cop;

  void OnTriggerEnter2D(Collider2D other) {
    if (other == threshold) cop.Shoot();
  }
}
