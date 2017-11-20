using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestruct : MonoBehaviour {

	private bool started = false;


	// Update is called once per frame
	void Update () {
		if (transform.GetComponent<ParticleSystem>().particleCount == 0 && started) {
			Destroy(gameObject);
		}
		if (transform.GetComponent<ParticleSystem> ().particleCount > 1) {
			started = true;
		}
	}
}
