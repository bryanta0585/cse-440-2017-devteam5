using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour {

	public Texture damageFlash;
	[SerializeField] bool wasHit;
	[SerializeField] float counter = 0.1f;

	public void Hit() {
		wasHit = true;
	}

	void Update ()
	{
		if(wasHit == true)
		{
			counter-=Time.deltaTime;
			if(counter<=0)
			{
				Clear ();
			}
		}

	}

	void Clear ()
	{
		wasHit = false;
		counter = 0.2f;
	}

	void OnGUI ()
	{
		if(wasHit == true)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), damageFlash);
		}
	}
}
