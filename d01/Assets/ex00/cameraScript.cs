using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public GameObject red, yellow, blue;
	GameObject player;
	playerScript_ex00 playerScript;
	Vector3[] initPos;

	// Use this for initialization
	void Start () {
		initPos = new Vector3[] {
			new Vector3(-4.21F, -0.36F, 0),
			new Vector3(-1.44F, 0.26F, 0),
			new Vector3(1.69F, 0.25F, 0)
		};
		resetPos();
		player = red;
		playerScript = player.GetComponent<playerScript_ex00>();
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
	}

	void changeFocus(GameObject target) {
		playerScript.focus = false;
		player = target;
		playerScript = player.GetComponent<playerScript_ex00>();
		playerScript.focus = true;
	}
	
	void resetPos() {
		red.transform.position = initPos[0];
		yellow.transform.position = initPos[1];
		blue.transform.position = initPos[2];
	}
}
