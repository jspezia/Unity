using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	public GameObject	doorImg;
	public int			dirMoveX;
	public int			dirMoveY;

	private	Vector2	_positionStart;

	void Start () {
		_positionStart = transform.position;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if ((other.tag == "Player" || other.tag == "Ennemy") && !other.isTrigger) {
			doorImg.transform.position = new Vector2(transform.position.x + (dirMoveX * 2), transform.position.y + (dirMoveY * 2));
		}
	}
	
	// void OnTriggerStay2D(Collider2D other) {
	// 	if (other.tag == "Player" || (other.tag == "Ennemy" && !other.isTrigger)) {
	// 		doorImg.transform.position = new Vector2(transform.position.x + (dirMoveX * 2), transform.position.y + (dirMoveY * 2));
	// 	}
	// }

	void OnTriggerExit2D(Collider2D other) {
		if ((other.tag == "Player" || other.tag == "Ennemy") && !other.isTrigger) {
			doorImg.transform.position = _positionStart;
		}
	}
}
