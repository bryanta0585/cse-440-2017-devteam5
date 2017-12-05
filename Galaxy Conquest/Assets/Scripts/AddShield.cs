using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShield : MonoBehaviour {
	
	[SerializeField] private float shield = 1.0f; //Defines the amount of shield gained when an object collides with this one

	void OnCollisionEnter2D(Collision2D other) {
		var healthComponent = other.collider.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			healthComponent.SendMessage("AddShield", shield); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		var healthComponent = other.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			healthComponent.SendMessage("AddShield", shield); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}
	}


}
