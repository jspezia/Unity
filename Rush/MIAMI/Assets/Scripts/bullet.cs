using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	private Vector3		target;
	private Vector3		direction;
	public float		speed = 30f;
	private bool		fired;

	void Awake () {
		Debug.Log("Start");
		fired = true;
	}
	
	void Update () {
		if (fired) {
			if (transform.position == target) {
					target += direction;
			}
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		}
	}

public	void Fire (Vector3 _position, Vector3 _target) {

	Debug.Log("Fire a bullet.");
	fired = true;
	_target.z = 0f;
	target = _target;
	_position.z = 0f;
	transform.position = _position;
	direction =  target - transform.position;
	}
}
