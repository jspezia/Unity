using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public GameObject	attachToBody;
	private Collider2D	_colSelected;
	private generateWeapon	_weaponSelected = null;
	private weapons			_weapon;
	
	private Animator 	anim;

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

				_weaponSelected.transform.localScale = Vector3.zero;
				
				anim.SetBool("isTake", true);
				
			}
		}
		
		if (Input.GetMouseButtonDown (1) && attachToBody != null) {
			anim.SetBool("isTake", false);
			_weaponSelected.transform.localScale = Vector3.one;
			_weaponSelected.transform.position = transform.position;
			attachToBody.GetComponent<SpriteRenderer>().sprite = null;
			_weaponSelected = null;
		}
	}

}
