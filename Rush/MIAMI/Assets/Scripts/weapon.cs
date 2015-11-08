using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject		bullet_prefab;
	public GameObject		player;
	private GameObject		bullet;
	public float			cadence = 2.5f;
	private float			t0;
	private bool			fire = false;
	private Vector3			depart;

	void Start () {
		t0 = Time.time;
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			fire = true;
		}
		if (Input.GetMouseButtonUp(0)) {
			fire = false;
		}
		if (fire) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			if (Time.time - t0 > cadence) {
				Debug.Log("Rotation joueur " + player.transform.rotation.z + " / " + player.transform.rotation.w);
				depart = transform.position;
				bullet = (GameObject)GameObject.Instantiate(bullet_prefab, depart, Quaternion.identity);
				bullet.GetComponent<bullet>().Fire(mousePosition);
				t0 = Time.time;
			}
		}
	}
}
