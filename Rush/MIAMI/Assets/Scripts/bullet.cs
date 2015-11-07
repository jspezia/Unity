using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	private Vector3		target;
	private Vector3		direction;
	public float		speed = 30f;


	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log(coll);
		Destroy(gameObject);
	}
	
	void Update () {
		if (transform.position == target) {
				target += direction;
		}
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
	}

	public	void Fire (Vector3 _target) {
		_target.z = 0f;
		target = _target;
		direction =  target - transform.position;
	}
}
