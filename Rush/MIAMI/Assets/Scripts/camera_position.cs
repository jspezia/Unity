using UnityEngine;
using System.Collections;

public class camera_position : MonoBehaviour {

	public GameObject player;

	movements playerScript;

	void Start () {
		playerScript = player.GetComponent<movements>();
	}

	void Update() {
		transform.position = player.transform.position + new Vector3 (0,0,-10);
	}
}
