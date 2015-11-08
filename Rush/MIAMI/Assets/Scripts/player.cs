using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public GameObject	attachToBody;
	public GameObject	weapon;
	private weapon	weapon2;
	private GameObject	bullet_prefab;
	private Collider2D	_colSelected;
	private generateWeapon	_weaponSelected = null;
	private weapons			_weapon;
	
	private Animator 	anim;
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "bullet_ennemy" || coll.gameObject.tag == "Ennemy") {
			Debug.Log("Dead Player");
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.E) && _weaponSelected == null) {
			_colSelected = Physics2D.OverlapPoint(transform.position);
			if (_colSelected && _colSelected.tag == "weapon") {

				_weaponSelected = _colSelected.gameObject.GetComponent<generateWeapon>();
				anim = _weaponSelected.GetComponent<Animator>();
				_weapon = _weaponSelected.weapon.GetComponent<weapons>();
				attachToBody.GetComponent<SpriteRenderer>().sprite = _weapon.attachToBody;
				weapon2 = weapon.GetComponent<weapon>();
				bullet_prefab = weapon.GetComponent<weapon>().bullet_prefab;
				bullet_prefab.GetComponent<SpriteRenderer>().sprite = weapon2.bullets[_weaponSelected.i];

				_weaponSelected.transform.localScale = Vector3.zero;
				
				anim.SetBool("isTake", true);
				anim.SetBool("isDrop", false);
				
			}
		}
		
		if (Input.GetMouseButtonDown (1) && _weaponSelected != null) {
			anim.SetBool("isTake", false);
			anim.SetBool("isDrop", true);
			_weaponSelected.transform.position = transform.position;
			attachToBody.GetComponent<SpriteRenderer>().sprite = null;

			_weaponSelected = null;
		}
	}

}
