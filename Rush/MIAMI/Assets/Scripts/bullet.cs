using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	private Vector3		target;
	private Vector3		depart;
	private Vector3		direction;
	public float		speed = 30f;

	void Awake ()
	{
		// transform.position = new Vector3(transform.position.x + transform.rotation.w, transform.position.y + transform.rotation.z, 0f);
		// Debug.Log("Ma position : ( " + transform.position.x + " / " + transform.position.y);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// Debug.Log("Collision enter: " + coll.gameObject.tag);
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
		direction.z = 0f;
	}
}
