using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public GameObject PauseUI_2;

	private bool paused = false;
	private bool paused_2 = false;

	void Start() {

		PauseUI.SetActive(false);
		PauseUI_2.SetActive(false);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!paused_2) {
				paused = !paused;
			}
			else {
				Continue();
			}
		}
		if (!paused_2) {
			if (paused && !paused_2) {
				PauseUI.SetActive(true);
				Time.timeScale = 0;
			}
			else if (!paused && !paused_2) {
				PauseUI.SetActive(false);
				Time.timeScale = 1;
			}
		}
		if (paused_2) {
			PauseUI_2.SetActive(true);
			Time.timeScale = 0;
		}
	}

	public void Resume() {
		paused = false;
	}

	public void Exit() {
		paused_2 = true;
	}

	public void Continue() {
		Debug.Log("Continue");
		paused = false;
		paused_2 = false;
		PauseUI.SetActive(false);
		PauseUI_2.SetActive(false);
	}

	public void Really_exit() {
		Application.LoadLevel(0);
	}
}
