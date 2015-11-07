using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateValue : MonoBehaviour {

	public GameObject manager;
	public string field;
	gameManager script;

	// Use this for initialization
	void Start () {
		script = manager.GetComponent<gameManager>();
	}

	// Update is called once per frame
	void Update () {
		int	val = 0;

		switch (field) {
			case "health":
				val = script.playerHp;
				break;
			case "energy":
				val = script.playerEnergy;
				break;
			default:
				break;
		}
		GetComponent<Text>().text = val.ToString();
	}
}
