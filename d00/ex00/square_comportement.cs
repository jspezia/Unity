using UnityEngine;
using System.Collections;

public class square_comportement : MonoBehaviour {
	public string	key;
	float			speed;
	float 			t0;
		
	void Start() {
		speed = Random.Range(0.1F, 0.3F);
		t0 = Time.time;
	}
	void Update () {
		transform.Translate(0.0F, -speed, 0.0F); 
		if (transform.localPosition.y < -5.0F) {
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(key)) {
			Debug.Log("Precision: " + (5 + transform.localPosition.y));
			GameObject.Destroy(gameObject);
		}
	}
}
