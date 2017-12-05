using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBite : MonoBehaviour {

	void OnCollisionStay2D(Collision2D other) {

		if (other.gameObject.tag == "Player") {
			GetComponent<Animator> ().Play ("Enemy Bite");
		}

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<Animator> ().Play ("Enemy Bite");
		}
	}


}
