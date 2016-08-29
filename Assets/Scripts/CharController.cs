using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharController : MonoBehaviour {

  const float VELOCITY = 600;

  public static CharController instance;

  public RectTransform charTransform;
  public Animator ropeAnimator;
  public Arrow arrow;
  public RectTransform shotArrowsArea;
  public GameObject arrowPrefab;
  public RectTransform arrowWrapper;
  public RectTransform lifeBar;
  public Animator animator;
  public Text scoreText;
  public Text overScoreText;
  public GameObject gameOver;
  public AudioSource music;
  public Animator comboAnimator;


  float lastComboTime = 0f;
  bool showingDamage = false;
  float lastDamageTime = 0f;
  bool canShoot = true;
  bool armed = true;
  bool upPressed = false;
  bool rightPressed = false;
  bool downPressed = false;
  bool leftPressed = false;
  float lastShootTime = 0;
  float life = 1.0f;
  int score = 0;

  void Awake() {
    instance = this;
  }

  void Start() {
    music.Play();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.UpArrow)) upPressed = true;
    if (Input.GetKeyDown(KeyCode.RightArrow)) rightPressed = true;
    if (Input.GetKeyDown(KeyCode.DownArrow)) downPressed = true;
    if (Input.GetKeyDown(KeyCode.LeftArrow)) leftPressed = true;
    if (Input.GetKeyUp(KeyCode.UpArrow)) upPressed = false;
    if (Input.GetKeyUp(KeyCode.RightArrow)) rightPressed = false;
    if (Input.GetKeyUp(KeyCode.DownArrow)) downPressed = false;
    if (Input.GetKeyUp(KeyCode.LeftArrow)) leftPressed = false;

    if (canShoot && Input.GetKeyDown(KeyCode.Space)) Shoot();

    Vector3 position = new Vector3(
      charTransform.localPosition.x,
      charTransform.localPosition.y,
      charTransform.localPosition.z
    );

    if (rightPressed) {
      position.x += Time.deltaTime * VELOCITY;
    } else if (leftPressed) {
      position.x -= Time.deltaTime * VELOCITY; 
    }

    if (position.x < -250 || position.x > 250) position.x = charTransform.localPosition.x;

    if (upPressed) {
      position.y += Time.deltaTime * VELOCITY;
    } else if (downPressed) {
      position.y -= Time.deltaTime * VELOCITY; 
    }

    if (position.y < -300 || position.y > 150) position.y = charTransform.localPosition.y;

    if (!canShoot && !armed && Time.time - lastShootTime > 1.6f) Rearm();
    if (!canShoot && armed && Time.time - lastShootTime > 2.0f) canShoot = true;

    if (showingDamage && Time.time - lastDamageTime > 0.2f) {
      showingDamage = false;
      animator.SetBool("hit", false);
    }

    charTransform.localPosition = position;
  }

  void Rearm() {
    GameObject arrowObject = (GameObject) Instantiate(arrowPrefab);
    arrow = arrowObject.GetComponent<Arrow>();
    arrow.rectTransform.SetParent(arrowWrapper);
    arrow.rectTransform.localScale = new Vector3(1, 1, 1);
    arrow.rectTransform.localPosition = new Vector3(0, 0, 0);

    armed = true;
  }

  void Shoot() {
    ropeAnimator.SetTrigger("shoot");
    lastShootTime = Time.time;
    arrow.rectTransform.SetParent(shotArrowsArea);
    arrow.Shoot();
    canShoot = false;
    armed = false;
  }

  public void OnHitBullet() {
    OnGetHit(0.4f);
  }

  public void OnHitByCop() {
    OnGetHit(0.1f);
  }

  void OnGetHit(float hit) {
    if (showingDamage) return;
    life -= hit;
    if (life < 0) life = 0; 
    lifeBar.localScale = new Vector3(life, 1, 1);
    animator.SetBool("hit", true);
    showingDamage = true;
    lastDamageTime = Time.time;
    if (life == 0) {
      music.Stop();
      gameOver.SetActive(true);
    }
  }
  
  public void OnCopHit(int combo) {
    if (life <= 0) return;


    if (combo < 3) {
      score += 15 + combo * 30;
    } else {
      score += 15 + combo * 60;      
    }

    scoreText.text = score.ToString();
    overScoreText.text = score.ToString();

    if (combo >= 3 && (lastComboTime == 0 || Time.time - lastComboTime > 2f)) {
      comboAnimator.SetTrigger("combo");
      lastComboTime = Time.time;
    }
  }

}
