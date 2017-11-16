using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class simply defines an animation and the disappearance of a pickup, pickup effects are specified in another script
public class Pickup : MonoBehaviour {

	//Only runs in the last frame within each second
	void LateUpdate() {
		gameObject.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); //Causes pickup object to slowly rotate

	}


	//When player collides with the pickup it will despawn
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.gameObject == GameObject.FindWithTag("Player")) {
			Destroy(gameObject);
			Debug.Log("Player collected a pickup");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == GameObject.FindWithTag("Player")) {
			Destroy(gameObject);
			Debug.Log("Player collected a pickup");
		}
	}
}
		

