using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {

	public bool		focus;
	public float	maxSpeed = 3f;
	public float	jumpForce = 1;
	public bool grounded = false;
	private Rigidbody2D rb;


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Player") {
			grounded = true;
		}
	}

	// void OnCollisionExit2D(Collision2D coll) {
	// 	grounded = false;
	// }

	void Start() {
		focus = false;
		rb = (Rigidbody2D)GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (focus) {
			rb.isKinematic = false;
			float move = Input.GetAxis("Horizontal");
			
			rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
			if (Input.GetKeyDown("space") && grounded == true) {
				Vector3 jumpVector = new Vector3(0, 5, 0);
				rb.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
				grounded = false;
			}
		}
		else {
			if (grounded){
				rb.isKinematic = true;
			}
		}
	}

}













