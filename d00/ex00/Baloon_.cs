using UnityEngine;
using System.Collections;

public class Baloon_ : MonoBehaviour {

	public string		Text;
	int 				LevelAir = 1;
	int					maxBreath = 10;
	int					breath = 10;
	float				t0 = 0.0F;
	// Update is called once per frame
	void Update()
	{
		transform.localScale *= 0.99F * LevelAir;
		
		if (Time.time - t0 > 1)
		{
			breath = maxBreath;
			Debug.Log("Recup breath!");
		}
		if (Input.GetKeyDown("space") && breath > 0)
		{
			t0 = Time.time;
			transform.localScale *= 1.2F;
			breath -= 1;
			if (breath == 0)
			Debug.Log("No more breath!");				
		}

		if (transform.localScale.x > 10.0F || transform.localScale.x < 0.1F)
		{
			transform.localScale *= 0;
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
			GameObject.Destroy(this);
		}

	}
}
