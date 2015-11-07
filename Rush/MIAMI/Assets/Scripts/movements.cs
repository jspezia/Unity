using UnityEngine;
using System.Collections;

public class movements : MonoBehaviour {

	public float	maxSpeed = 3f;
	private Rigidbody2D rb;



	void Start() {
		rb = (Rigidbody2D)GetComponent<Rigidbody2D>();
	}

	void Update() {
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(vert * maxSpeed, rb.velocity.y);
		rb.velocity = new Vector2(hori * maxSpeed, rb.velocity.x);
	}
}
