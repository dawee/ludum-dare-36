using UnityEngine;
using System.Collections;

public class ArrowHitBox : MonoBehaviour {

  public Cop cop;

  bool triggered = false;

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "arrow") {
      Arrow arrow = other.gameObject.GetComponent<Arrow>();

      if (!triggered && arrow.isShooting) {
        cop.rectTransform.SetParent(arrow.copWrapper);
        cop.rectTransform.localScale = new Vector3(1, 1, 1);
        cop.rectTransform.localPosition = new Vector3(0, 50 - (15 * arrow.combo), 0);
        cop.animator.SetBool("scared", true);
        cop.bullet.gameObject.SetActive(false);
        CharController.instance.OnCopHit(arrow.combo);
        triggered = true;

        arrow.combo++;
      }
    }
  }

}
