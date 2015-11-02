using UnityEngine;
using System.Collections;

public class Spanners : MonoBehaviour {

	public GameObject		A, S, D;
	public Vector3			A_vec, S_vec, D_vec;
	private	float			resp;
	private float 			t0;
	void Start () {
		t0 = Time.time;
	}
	
	void Update () {
		resp = Random.Range(0.0F, 3.0F);
		if (Time.time - Random.Range(1.0F, 3.0F) > t0) {
			t0 = Time.time;
			if (resp < 1)
				GameObject.Instantiate(A, A_vec, Quaternion.identity);
			else if (resp < 2)
				GameObject.Instantiate(S, S_vec, Quaternion.identity);
			else
				GameObject.Instantiate(D, D_vec, Quaternion.identity);
		}	
	}
}
