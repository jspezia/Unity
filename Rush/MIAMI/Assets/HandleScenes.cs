using UnityEngine;
using System.Collections;

public class HandleScenes : MonoBehaviour {
	public int levelToLoad;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Application.LoadLevel(levelToLoad);
	}
}
