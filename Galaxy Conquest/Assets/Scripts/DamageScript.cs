using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When attached to an object, if it collides with an object that has a HealthComponentScript it will deal an amount of damage
public class DamageScript : MonoBehaviour {

	[SerializeField] private float damage = 1.0f; //Defines the amount of health lost when an object with a HealthComponentScript collides with an object with a HealScript
	[SerializeField] private float knockback = 1.0f;
	[SerializeField] private float damageTimer = 0;
	private float timeSinceDamage;


	void Update () {
		timeSinceDamage += Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other) {
		var healthComponent = other.collider.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null && (timeSinceDamage >= damageTimer)) { //Only trigger damage if the object possesses a HealthComponent

			if (gameObject.tag == "Enemy" && other.gameObject.tag == "Enemy") {
				return;
			}
			timeSinceDamage = 0;
			healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
			//healthComponent.SendMessage("AddKnockback", transform.right * 1000 * -1); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		var healthComponent = other.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null && (timeSinceDamage >= damageTimer)) { //Only trigger damage if the object possesses a HealthComponent

			if (gameObject.tag == "Enemy" && other.gameObject.tag == "Enemy") {
				return;
			}

			healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
			timeSinceDamage = 0;
			//healthComponent.SendMessage("AddKnockback", transform.right * 1000 * -1); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}
	}

}
