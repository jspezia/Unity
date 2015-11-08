using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {
	
	public GameObject	player;
	public GameObject	bullet_prefab;
	public float		cadence = 1f;
	public AudioClip	death;

	public	bool		_attackingPlayer;
	private Vector3		_newPosition;
	private float		_speed;
	private Animator	_anim;
	private GameObject	bullet;
	private	float		t0;

	Vector3 dir;
	float 	angle;

	// Use this for initialization
	void Start () {
		_attackingPlayer = false;
		_speed = 5f;
		_anim = GetComponent<Animator> ();
		t0 = 0f;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			_attackingPlayer = true;
			_anim.SetBool ("is_walking", true);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "bullet_player") {
			Debug.Log("Aaaarghh !");
			AudioSource.PlayClipAtPoint(death, Vector3.up);
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if (_attackingPlayer == true) {
			if (t0 == 0f) {
				t0 = Time.time;
			}
			_newPosition = player.transform.position;
			dir = _newPosition - transform.position;
			angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed * Time.deltaTime);

			if (Time.time - t0 > cadence) {
				bullet = (GameObject)GameObject.Instantiate(bullet_prefab, transform.position, Quaternion.identity);
				bullet.GetComponent<bullet>().Fire(player.transform.position);
				t0 = Time.time;
			}
		}
	}
}
