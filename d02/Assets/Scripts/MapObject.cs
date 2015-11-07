using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour {

	public int			hp;
	public string		type;
	public GameObject	townHall;
	TownHallScript script;

	// Use this for initialization
	void Start () {
		if (type != "hall") {
			script = townHall.GetComponent<TownHallScript>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			if (type == "house") {
				townHall.GetComponent<TownHallScript>().spawn_time += 2.5f;
			}
			if (type == "soldier")
				script.soldiers.Remove(gameObject);
			if (type == "hall") {
				Time.timeScale = 0;
			}
			Destroy(gameObject);
		}
	}
}
