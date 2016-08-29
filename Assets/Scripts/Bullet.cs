using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public RectTransform rectTransform;

  bool shooting = false;
  const int VELOCITY = 300;

  // Update is called once per frame
  void Update () {
    if (!shooting) return;

    Vector3 position = new Vector3(
      rectTransform.localPosition.x,
      rectTransform.localPosition.y,
      rectTransform.localPosition.z
    );

    position.y -= VELOCITY * Time.deltaTime;

    rectTransform.localPosition = position;
  }

  public void Shoot() {
    shooting = true;
    gameObject.SetActive(true);
  }
}
