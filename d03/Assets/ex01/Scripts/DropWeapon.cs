using UnityEngine;
using System.Collections;

public class DropWeapon : MonoBehaviour {

	[HideInInspector]public GameObject tower;

	void Start () {
		tower = null;
	}

	public void addTower (gameManager playerInfo, GameObject spawn) {
		if (!tower) {
			towerScript towerInfo = spawn.GetComponent<towerScript>();

			if (playerInfo.playerEnergy - towerInfo.energy >= 0) {
				tower = (GameObject)GameObject.Instantiate(spawn, transform.position, Quaternion.identity);
				playerInfo.playerEnergy -= towerInfo.energy;
			}
		}
	}
}
