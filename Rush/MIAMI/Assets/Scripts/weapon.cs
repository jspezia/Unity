using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject		bullet_prefab;
	private GameObject		bullet;
	public float			cadence = 0.5f;
	private float			t0;


	void Start () {
		t0 = Time.time;
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			if (Time.time - t0 > cadence) {
				bullet = (GameObject)GameObject.Instantiate(bullet_prefab, transform.position, Quaternion.identity);
				bullet.GetComponent<bullet>().Fire(transform.position, mousePosition);
			}
		}
	}
}
