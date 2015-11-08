using UnityEngine;
using System.Collections;

public class generateCharacter : MonoBehaviour {
	
	public GameObject	head;
	public Sprite[]		heads;
	public GameObject	body;
	public Sprite[]		bodies;
	
	private SpriteRenderer	sRenderer;

	// Use this for initialization
	void Start () {
		sRenderer = head.GetComponent<SpriteRenderer> ();
		sRenderer.sprite = heads[Random.Range (0, 14)];
		sRenderer = body.GetComponent<SpriteRenderer> ();
		sRenderer.sprite = bodies[Random.Range (0, 3)];
	}
}
