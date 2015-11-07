using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject		bullets;
	void Start () {
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			bullets.GetComponent<bullet>().Fire(transform.position, mousePosition);
		}
	}
}
