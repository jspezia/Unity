using UnityEngine;
using System.Collections;

public class rotationEnnemy : MonoBehaviour {

	public float		speedrotation = 40f;

	private float		t0;
	// Use this for initialization
	void Start () {
		t0 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < t0 + 2f) {
			transform.Rotate (Vector3.forward * Time.deltaTime * speedrotation);
		}
		else if (Time.time >= t0 + 2f) {
			transform.Rotate (Vector3.forward * Time.deltaTime * -speedrotation);
		}
		if (Time.time > t0 + 4f) {
			t0 = Time.time;
		}
	}
}
