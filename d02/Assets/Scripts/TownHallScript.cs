using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TownHallScript : MonoBehaviour {

	public GameObject	s_prefab;
	public float		spawn_time = 10f;
	public float 		spawn_radius = 0.5f;
	public Vector3		spawn_coord;
	private float		t0;
	public List<GameObject> soldiers;
	GameObject spawn;


	void Start () {
		t0 = Time.time;
		soldiers = new List<GameObject>();
		Vector2 centerRdvPerso = new Vector2(transform.position.x - transform.position.x / 2, transform.position.y);
		spawn = (GameObject)GameObject.Instantiate(s_prefab, centerRdvPerso + Random.insideUnitCircle * spawn_radius, Quaternion.identity);
		soldiers.Add(spawn);
	}

	void Update () {
		if (Time.time - t0 > spawn_time) {
			Vector2 centerRdvPerso = new Vector2(transform.position.x - transform.position.x / 2, transform.position.y);
			spawn = (GameObject)GameObject.Instantiate(s_prefab, centerRdvPerso + Random.insideUnitCircle * spawn_radius, Quaternion.identity);
			soldiers.Add(spawn);

			t0 = Time.time;
		}
	}

	public void handleSelect(GameObject selected) {
		PlayerScript script;

		foreach (GameObject soldier in soldiers) {
				if (soldier != selected) {
					script = soldier.GetComponent<PlayerScript>();
					script.selected = false;
				}
		}
	}

	public void handleDefense () {
		foreach (GameObject soldier in soldiers) {
				SoldierScript script = soldier.GetComponent<SoldierScript>();

				script.targetEnemy = gameObject;
				script.targetPosition = transform.position;
		}
	}

}
