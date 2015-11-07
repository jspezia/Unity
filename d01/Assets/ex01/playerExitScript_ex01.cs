using UnityEngine;
using System.Collections;

public class playerExitScript_ex01 : MonoBehaviour {

	public GameObject player;
	public bool inPlace;

	// Use this for initialization
	void Start () {
		inPlace = false;
	}

	// Update is called once per frame
	void Update () {
		if (System.Math.Abs(transform.position.x - player.transform.position.x) < 0.2F
			&& System.Math.Abs(transform.position.y - player.transform.position.y) < 0.2F) {
			inPlace = truen;
		} else {
			inPlace = false;
		}
	}
}
