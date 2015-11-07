using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragWeapon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public GameObject manager;
	public GameObject spawnTower;
	gameManager playerInfo;
	Vector3 startPosition;
	RaycastHit2D hit;

	void Start () {
		itemBeingDragged = null;
		playerInfo = manager.GetComponent<gameManager>();
	}

	public void OnBeginDrag (PointerEventData enventData) {
		if (playerInfo.playerEnergy - spawnTower.GetComponent<towerScript>().energy >= 0) {
			itemBeingDragged = gameObject;
			startPosition = transform.position;
		}
	}

	public void OnDrag (PointerEventData enventData) {
		if (itemBeingDragged) {
			transform.position = Input.mousePosition;
		}
	}

	public void OnEndDrag (PointerEventData enventData) {
		if (itemBeingDragged) {
			itemBeingDragged = null;
			if (transform.parent.transform.position != startPosition) {
				hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit && hit.collider.gameObject.tag == "empty") {
					DropWeapon script = hit.collider.gameObject.GetComponent<DropWeapon>();

					script.addTower(playerInfo, spawnTower);
				}
				transform.position = startPosition;
			}
		}
	}
}
