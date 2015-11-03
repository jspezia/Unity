using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public int				movement;
	public GameObject		club;
	private club_movement	club_script;
	int						up;
	float					power;

	// Use this for initialization
	void Start () {
		movement = 0;
		up = 1;
		club_script = club.GetComponent<club_movement>();
	}

	public void Kill () {
		GameObject.Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		if (club_script.move == true) {
			if (power < 2.0F) {
				power += 0.03F;
			}
		}
		else if (club_script.kick == false && power > 0) {
			movement = 1;
			if (transform.position.y > 3.70F || transform.position.y < -3.70F) {
				up *= -1;
			}
			while (transform.position.y > 3.70F || transform.position.y < -3.70F) {
				transform.Translate(0.0F, Mathf.Clamp(power / 2, 0.02F, 0.5F) * up, 0.0F);
			}
			transform.Translate(0.0F, Mathf.Clamp(power / 2, 0.02F, 0.5F) * up, 0.0F);
			power -= 0.01F;
			if (power <= 0) {
				up = 1;
				movement = 2;
			}
		}
	}
}