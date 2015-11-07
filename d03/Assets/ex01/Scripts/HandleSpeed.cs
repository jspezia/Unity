using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandleSpeed : MonoBehaviour {

	public GameObject manager;
	gameManager script;

	// Use this for initialization
	void Start () {
		script = manager.GetComponent<gameManager>();
		pause();
	}

	// Update is called once per frame
	void Update () {

	}

	public void pause () {
		script.changeSpeed(0);
		GetComponent<Text>().text = "click play to start".ToUpper();
	}

	public void resume () {
		script.changeSpeed(1);
		GetComponent<Text>().text = "SPEED: 1X";
	}

	public void doubleSpeed () {
		script.changeSpeed(2);
		GetComponent<Text>().text = "SPEED: 2X";
	}

	public void superSpeed () {
		script.changeSpeed(4);
		GetComponent<Text>().text = "SPEED: 4X";
	}
}
