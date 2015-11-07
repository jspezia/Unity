using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public GameObject PauseUI;

	void Start() {
	}

	void Update() {
	}

	public void Start_Game
	() {
		Application.LoadLevel(1);
	}

	public void Exit() {
		Application.Quit();
	}
}
