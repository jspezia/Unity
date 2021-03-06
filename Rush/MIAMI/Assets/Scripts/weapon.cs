﻿using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject		bullet_prefab;
	public GameObject		player;
	public float			cadence = 2.5f;
	public Sprite[]			bullets;


	private GameObject		bullet;
	private float			t0;
	private bool			fire = false;
	private Vector3			depart;

	Vector3 dir;
	float 	angle;

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
		if (player.GetComponent<player>()._weaponSelected != null && fire) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			if (Time.time - t0 > cadence) {
				depart = transform.position;
				bullet = (GameObject)GameObject.Instantiate(bullet_prefab, depart, Quaternion.identity);

				dir = transform.position - mousePosition;
				angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				bullet.transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);

				bullet.GetComponent<bullet>().Fire(mousePosition);
				t0 = Time.time;
			}
		}
	}
}
