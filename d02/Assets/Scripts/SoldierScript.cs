using UnityEngine;
using System.Collections;

public class SoldierScript : MonoBehaviour {

	public Vector3 targetPosition;
	public AudioSource[] select_sound;
	public int		order_sound;
	private Animator anim;
	private float		t0;
	public GameObject targetEnemy;


	public enum SoldierMode {
		PASSIVE,
		AGGRESSIVE,
		DEFENSIVE
	};

	public SoldierMode mode;

	// Use this for initialization
	void Start () {
		order_sound = 0;
		select_sound = GetComponents<AudioSource>();
		anim = GetComponent<Animator>();
		targetPosition = transform.position;
		targetEnemy = null;
		t0 = Time.time;
	}

	void Update () {

	}

	public void handleTag (GameObject target) {
		if (target.tag != this.tag) {
			if (gameObject != target) {
					mode = SoldierMode.AGGRESSIVE;
					targetEnemy = target;
			}
		}
		else {
			setPassive();
		}
	}

	public void setPassive() {
		mode = SoldierMode.PASSIVE;
		targetEnemy = null;
	}

	public void handleActions() {
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = transform.position.z;
		if (order_sound == 1) {
			select_sound[1].Play();
		}
		if (order_sound == 0) {
			order_sound = 1;
		}
	}

	public void handleWalk() {
		if (GetComponent<EnemyScript>()) {
			mode = SoldierMode.AGGRESSIVE;
		}
		if (targetEnemy && mode == SoldierMode.AGGRESSIVE && Vector3.Distance(transform.position, targetEnemy.transform.position) < 0.2F) {
			anim.SetBool("attacking", true);
			if (Time.time > t0 + 1f) {
				if (targetEnemy.name == "HDV_Ork") {
					if (name == "OrcSoldier(Clone)") {
						targetEnemy = null;
						return;
					}
					targetEnemy.GetComponent<TownHallScript>().handleDefense();
				}
				targetEnemy.GetComponent<MapObject>().hp -= 1;
				t0 = Time.time;
			}
		} else {
			Vector3 currentTarget = (targetEnemy && mode == SoldierMode.AGGRESSIVE) ? targetEnemy.transform.position : targetPosition;

			if (transform.position != currentTarget) {
				anim.SetBool("attacking",false);
				anim.SetBool("walking", true);
				transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - currentTarget);
			}
			else {
        anim.SetBool("walking",false);
			}
		}
	}

	public void setDenfensive () {
		targetPosition = GetComponent<MapObject>().townHall.transform.position;
	}
}
