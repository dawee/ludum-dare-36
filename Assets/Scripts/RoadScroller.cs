using UnityEngine;
using System.Collections;

public class RoadScroller : MonoBehaviour {

  const int VELOCITY = 150;

  public RectTransform roadTransform;

  void Update() {
    Vector3 position = new Vector3(
      roadTransform.localPosition.x,
      roadTransform.localPosition.y,
      roadTransform.localPosition.z
    );

    position.y -= VELOCITY * Time.deltaTime;

    roadTransform.localPosition = position;
  }


}
