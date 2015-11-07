using UnityEngine;
using System.Collections;

public class movements : MonoBehaviour {
	public float	maxSpeed = 5f;
	private Rigidbody2D rb;
	private Animator anim;

	void Start() {
		rb = (Rigidbody2D)GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update() {
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		if (hori != 0 || vert != 0) {
			anim.SetBool("is_walking", true);
			rb.velocity = new Vector2(vert * maxSpeed, rb.velocity.y);
			rb.velocity = new Vector2(hori * maxSpeed, rb.velocity.x);
		} else {
			anim.SetBool("is_walking", false);
		}
		

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - mousePosition);
	}
}
