using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	  Screen.SetResolution(400, 600, false);
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyUp(KeyCode.Return)) {
      SceneManager.LoadScene("GameScene");
    }
	}
}
