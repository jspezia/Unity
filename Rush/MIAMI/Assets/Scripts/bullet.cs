using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	private Vector3		target;
	public float		speed = 30f;
	bool				fired;
	// private Rigidbody2D rb;

	void Start () {
		fired = false;
		// rb = (Rigidbody2D)GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if (fired) {
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		}
	}

public	void Fire (Vector3 _position, Vector3 _target) {
		fired = true;
		target = _target;
		transform.position = _position;
	}
}
