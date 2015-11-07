using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	GameObject	target;
	SoldierScript soldierScript;

	// Use this for initialization
	void Start () {
		soldierScript = GetComponent<SoldierScript>();
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		foreach (var obj in objs) {
			if (obj.name == "HDV_Human") {
				target = obj;
				break;
			}
		};
		if (target) {
			soldierScript.targetEnemy = target;
			soldierScript.targetPosition = target.transform.position;
		}
	}

	// Update is called once per frame
	void Update () {
		if (soldierScript.targetEnemy) {
			var hitColliders = Physics2D.OverlapCircleAll(transform.position, 1);

			foreach (var hit in hitColliders) {
				if (hit.gameObject.name == "HumanSoldier(Clone)") {
					soldierScript.targetEnemy = hit.gameObject;
					soldierScript.targetPosition = hit.gameObject.transform.position;
				}
			}
		} else if (target) {
			soldierScript.targetEnemy = target;
			soldierScript.targetPosition = target.transform.position;
		}
		soldierScript.handleWalk();
	}

}
