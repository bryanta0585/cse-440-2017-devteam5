using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script should be attached to an object that would cause the player to respawn. Currently it simply reset's the player's position but it can be modified to reset the whole scene
public class RespawnPlayer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		//If the player has hit this trigger it will teleport them back to slightly above their initial starting point (0,0.5,0)
		if (other.gameObject == GameObject.FindWithTag("Player")) {

			Debug.Log("Player has fallen out of bounds");

			//other.gameObject.SendMessage("Active"); //This will reinitialize the player's health and other scripts;
			other.attachedRigidbody.velocity = Vector3.zero; //Kills velocity to prevent player accidentally falling off of platform again
			other.attachedRigidbody.position = Vector3.up; //Teleports player to (0,1,0);


		}
	}
}
