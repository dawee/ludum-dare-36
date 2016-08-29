using UnityEngine;
using System.Collections;

public class CopsLine : MonoBehaviour {

  public RectTransform rectTransform;
  const int VELOCITY = 50;

  bool stopped = false;

	// Update is called once per frame
	void Update () {
    if (stopped) return;

    Vector3 position = new Vector3(
      rectTransform.localPosition.x,
      rectTransform.localPosition.y,
      rectTransform.localPosition.z
    );

    position.y -= VELOCITY * Time.deltaTime;

    rectTransform.localPosition = position;
	}

  public void Stop() {
    stopped = true;
  }
}
