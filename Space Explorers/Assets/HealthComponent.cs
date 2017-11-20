using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is used to track the health of an object. It will despawn the object if their health reaches 0. Damage and healing should be added to objects via DamageScript and HealScript respectively.
public class HealthComponent : MonoBehaviour {

	[SerializeField] private GameObject dropOnDeath;
	[SerializeField] private float health = 10.0f;

	//This function is used instead of Update() to conserve resources since the player's health should only change through AddDamage and AddHealth
	void CheckHealth() {
		//If health less than or equal to 0, despawns the player.
		if (health <= 0.0f) {

			if (dropOnDeath != null) {
				Instantiate (dropOnDeath, transform.position, transform.rotation);
			}

			gameObject.SetActive (false);
			Debug.Log (gameObject.name + " is dead");
			Destroy (gameObject);
		}
	}

	//Causes damage to the player. NOTE: AddHealth can also deal damage by applying negative health but this function has been created in order to increase clarity
	void AddDamage(float damage) {
		health -= damage;
		Debug.Log (damage + " damage has been taken, current health is " + health);
		CheckHealth ();
	}

	//Heals the player. NOTE: AddDamage can also heal by applying negative damage but this function has been created in order to increase clarity
	void AddHealth(float addedHealth) {
		health += addedHealth;
		Debug.Log (addedHealth + " health has been gained, current health is " + health);
		CheckHealth ();
	}

}