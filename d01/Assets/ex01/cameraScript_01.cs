using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cameraScript_01 : MonoBehaviour {

	public GameObject red, yellow, blue;
	public List<GameObject> blocs = new List<GameObject>();
	GameObject player;
	playerScript_ex01 playerScript;
	Vector3[] initPos;

	// Use this for initialization
	void Start () {
		initPos = new Vector3[] {
			new Vector3(-14.41F, -2.53F, 0),
			new Vector3(-13.38F, -1.92F, 0),
			new Vector3(-11.51F, -1.9F, 0)
		};
		resetPos();
		player = red;
		playerScript = player.GetComponent<playerScript_ex01>();
		playerScript.focus = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1")) {
			changeFocus(red);
		} else if (Input.GetKeyDown("2")) {
			changeFocus(yellow);
		} else if (Input.GetKeyDown("3")) {
			changeFocus(blue);
		} else if (Input.GetKeyDown("r")) {
			resetPos();
		}
		transform.position = player.transform.position + new Vector3 (0,0,-10);
		if (checkWin()) {
			Debug.Log("You won !");
		}
	}

	void changeFocus(GameObject target) {
		playerScript.focus = false;
		player = target;
		playerScript = player.GetComponent<playerScript_ex01>();
		playerScript.focus = true;
	}

	void resetPos() {
		red.transform.position = initPos[0];
		yellow.transform.position = initPos[1];
		blue.transform.position = initPos[2];
	}

	bool checkWin() {
		playerExitScript_ex01 script;

		foreach (GameObject bloc in blocs) {
			script = bloc.GetComponent<playerExitScript_ex01>();
			if (!script.inPlace) return false;
		}
		return true;
	}
}
