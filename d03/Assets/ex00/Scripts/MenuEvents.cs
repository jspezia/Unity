﻿using UnityEngine;
using System.Collections;

public class MenuEvents : MonoBehaviour {

	public void startGame() {
		Application.LoadLevel(1);
	}

	public void exitGame() {
		Application.Quit();
	}
}
