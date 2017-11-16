using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Gives player an amount of points when it's object is touched, use with "Pickup.cs" if you want the item to disappear afterwards
public class AddPoints : MonoBehaviour {

	[SerializeField] private float pointsToGive; //Give player this many points when this object is touched.

	void OnCollisionEnter2D(Collision2D other) {
		var pointsComponent = other.collider.gameObject.GetComponent<PointsComponent> ();
		if (pointsComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			pointsComponent.SendMessage("AddPoints", pointsToGive); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		var pointsComponent = other.gameObject.GetComponent<PointsComponent> ();
		if (pointsComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			pointsComponent.SendMessage("AddPoints", pointsToGive); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		
		}
	}
}
