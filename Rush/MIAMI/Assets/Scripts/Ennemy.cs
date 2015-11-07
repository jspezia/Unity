using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {
	
	public GameObject	player;
	public	GameObject	legs;

	private bool		_attackingPlayer;
	private Vector3		_newPosition;
	private float		_speed;
	private Animator	_anim;

	// Use this for initialization
	void Start () {
		_attackingPlayer = false;
		_speed = 5f;
		_anim = legs.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			_attackingPlayer = true;
			_anim.SetBool ("walking", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_attackingPlayer == true) {
			
			_newPosition = player.transform.position;
			var dir = _newPosition - transform.position;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed * Time.deltaTime);
		}
	}
}
