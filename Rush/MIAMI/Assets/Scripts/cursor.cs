using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour {

	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;

	void Start() {
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}
}
