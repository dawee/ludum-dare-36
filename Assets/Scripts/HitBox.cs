using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

  public CharController charController;

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "bullet") charController.OnHitBullet();
    if (other.gameObject.tag == "cop") charController.OnHitByCop();
  }
}
