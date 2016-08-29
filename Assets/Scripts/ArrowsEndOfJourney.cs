using UnityEngine;
using System.Collections;

public class ArrowsEndOfJourney : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "arrow") {
      Arrow arrow = other.gameObject.GetComponent<Arrow>();

      Destroy(arrow.gameObject);
    }
  }
}
