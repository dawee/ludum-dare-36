using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arrow : MonoBehaviour {

  const float VELOCITY = 100 / 0.6f;

  public RectTransform rectTransform;
  public RectTransform copWrapper;

  bool shooting = false;

  public int combo = 0;

  public bool isShooting {
    get {
      return shooting;
    }
  }

  public void Shoot() {
    shooting = true;
  }

  void Update() {
    if (! shooting) return; 

    Vector3 position = new Vector3(
      rectTransform.localPosition.x,
      rectTransform.localPosition.y,
      rectTransform.localPosition.z
    );

    position.y += Time.deltaTime * VELOCITY;

    rectTransform.localPosition = position;
  }

}
