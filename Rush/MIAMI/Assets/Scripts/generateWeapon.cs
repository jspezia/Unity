using UnityEngine;
using System.Collections;

public class generateWeapon : MonoBehaviour {

	public GameObject[]	weapons;

	public GameObject		weapon;
	private SpriteRenderer	sRenderer;
	[HideInInspector] public int		i = 0;

	// Use this for initialization
	void Start () {
		i = Random.Range (0, 4);
		weapon = weapons [i];
		sRenderer = weapon.GetComponent<SpriteRenderer> ();
		GetComponent<SpriteRenderer> ().sprite = sRenderer.sprite;
		GetComponent<BoxCollider2D> ().size = weapon.GetComponent<BoxCollider2D> ().size * 2;
	}
}
