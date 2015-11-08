using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	//public GameObject PauseUI;

	void Start() {
	}

	void Update() {
	}

	public void Start_Game()
	{
		Application.LoadLevel(1);
	}

	public void	Restart_Level()
	{
		Application.LoadLevel (1); //load current level
	}

	public void MainMenu()
	{
		Application.LoadLevel (1); //load Main menu scene
	}

	public void Exit() {
		Application.Quit();
	}
}
