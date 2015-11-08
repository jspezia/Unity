using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public GameObject		ch1;
	public GameObject		ch2;
	public GameObject		Ennemy;
	public float			_speed = 1f;

	private Vector3			check1;
	private Vector3			check2;
	private Vector3			_newPosition;
	private Animator	_anim;
	// Use this for initialization
	void Start () {
		check1 = ch1.transform.position;
		check2 = ch2.transform.position;
		_newPosition = check1;
		_anim = GetComponent<Animator> ();
		_anim.SetBool ("is_walking", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Ennemy.GetComponent<Ennemy>()._attackingPlayer == false) {
			if (transform.position == check1) {
				_newPosition = check2;
			}
			if (transform.position == check2) {
				_newPosition = check1;
			}
			var dir = _newPosition - transform.position;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed * Time.deltaTime);
		}
	}
}
