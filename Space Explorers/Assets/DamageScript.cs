using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When attached to an object, if it collides with an object that has a HealthComponentScript it will deal an amount of damage
public class DamageScript : MonoBehaviour {

	[SerializeField] private float damage = 1.0f; //Defines the amount of health lost when an object with a HealthComponentScript collides with an object with a HealScript

	void OnCollisionEnter(Collision other) {
		var healthComponent = other.collider.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}

	}

	void OnTriggerEnter(Collider other) {
		var healthComponent = other.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}
	}

}
