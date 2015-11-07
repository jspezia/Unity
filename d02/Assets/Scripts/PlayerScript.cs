using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public bool selected;
	SoldierScript soldierScript;
	TownHallScript townScript;
	RaycastHit2D hit;

	// Use this for initialization
	void Start () {
		selected = false;
		soldierScript = GetComponent<SoldierScript>();
		townScript = GetComponent<MapObject>().townHall.GetComponent<TownHallScript>();
	}

	// Update is called once per frame
	void Update () {

		if (selected) {
			if (Input.GetMouseButtonDown(0)) {
				hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit) {
					soldierScript.handleTag(hit.collider.gameObject);
				} else {
					soldierScript.setPassive();
				}
				if (!Input.GetKey(KeyCode.LeftControl)) {
					soldierScript.handleActions();
				}
			} else if (Input.GetMouseButtonDown(1)) {
				selected = false;
				soldierScript.order_sound = 0;
			}
		}
		soldierScript.handleWalk();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			if (!Input.GetKey(KeyCode.LeftControl)) {
				townScript.handleSelect(gameObject);
			}
			soldierScript.select_sound[0].Play();
			selected = true;
		}
	}
}
