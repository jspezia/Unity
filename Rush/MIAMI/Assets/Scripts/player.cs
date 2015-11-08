using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "bullet_ennemy" || coll.gameObject.tag == "Ennemy") {
			Debug.Log("Dead Player");
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
