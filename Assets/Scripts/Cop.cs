using UnityEngine;
using System.Collections;

public class Cop : MonoBehaviour {

  public Animator animator;
  public Bullet bullet;
  public RectTransform bulletArea;
  public RectTransform shotArrowsArea;
  public RectTransform rectTransform;

  public void Shoot() {
    animator.SetBool("shoot", true);
    bullet.Shoot();
  }
}
