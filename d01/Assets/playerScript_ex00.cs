using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {

	public bool		focus;
	public float	maxSpeed = 3f;
	private Rigidbody2D rb;
	bool grounded = false;


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Player") {
			grounded = true;
		}
	}

	void Start() {
		focus = false;
		rb = (Rigidbody2D)GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (focus) {
			float move = Input.GetAxis("Horizontal");
			
			rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
			if (Input.GetKeyDown("space") && grounded == true) {
				Vector2 jumpVector = new Vector3(0, 5, 0);
				rb.AddForce(jumpVector, ForceMode2D.Impulse);
				grounded = false;
			}
		}
	}

}













