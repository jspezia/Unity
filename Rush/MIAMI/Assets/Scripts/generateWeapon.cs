using UnityEngine;
using System.Collections;

public class generateWeapon : MonoBehaviour {

	public GameObject[]	weapons;

	public GameObject		weapon;
	private SpriteRenderer	sRenderer;

	// Use this for initialization
	void Start () {
		weapon = weapons [Random.Range (0, 4)];
		sRenderer = weapon.GetComponent<SpriteRenderer> ();
		GetComponent<SpriteRenderer> ().sprite = sRenderer.sprite;
		GetComponent<BoxCollider2D> ().size = weapon.GetComponent<BoxCollider2D> ().size;
	}
}
