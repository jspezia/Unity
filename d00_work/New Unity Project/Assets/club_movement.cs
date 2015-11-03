using UnityEngine;
using System.Collections;

public class club_movement : MonoBehaviour {

	public GameObject	ball;
	private Ball		ball_script;
	public bool			move;
	public bool			kick;
	int					ball_move;
	float				init_y;
	int					score;
	// Use this for initialization
	void Start () {

		move = false;
		kick = false;
		ball_move = 0;
		score = -15;
		init_y = transform.position.y;
		ball_script = ball.GetComponent<Ball>();
		Debug.Log("Your current score is: " + score);
	}
	
	// Update is called once per frame
	void Update () {
		if (ball_move == 0) {
			if (Input.GetKeyDown("space") && kick == false) {
				move = true;
			}
			if (Input.GetKeyUp("space") && kick == false) {
				move = false;
				kick = true;
				score += 5;
				Debug.Log("Your current score is: " + score);
			}
			if (move == true) {
				transform.Translate(0.0F, -0.02F, 0.0F);
			}
			if (move == false && transform.position.y < init_y) {
				transform.Translate(0.0F, 0.1F, 0.0F);
			}
			if (transform.position.y >= init_y) {
				kick = false;
			}
		}
		ball_move = ball_script.movement;
		if (ball_move == 2) {
			init_y = ball_script.transform.position.y + 0.12F;
			transform.position = new Vector3(-0.25F, init_y, 0);
			ball_script.movement = 0;
		}
		if (transform.position.y > 2.3F && transform.position.y < 2.75F) {
			ball_script.Kill();
			if (score <= 0) {
				Debug.Log("You win!");
				Debug.Log("Your final score is: " + score);
			}
			else {
				Debug.Log("Looser...");
				Debug.Log("Your pathetic final score is: " + score);
			}
			Destroy(this);
		}
	}
}
