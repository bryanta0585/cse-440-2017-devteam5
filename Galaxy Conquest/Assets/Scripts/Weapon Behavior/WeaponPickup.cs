using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	[SerializeField] private string weaponType;
	[SerializeField] private int currentAmmo;
    

	public int CurrentAmmo {
		get { return currentAmmo; }
		set { currentAmmo = value; }
	}

	public string WeaponType {
		get { return weaponType;}
	}
	void Awake() {
		Transform player = GameObject.FindWithTag ("Player").transform;
		Collider2D weaponCollider = GetComponent<Collider2D> ();
		Physics2D.IgnoreCollision (weaponCollider, player.GetComponent<Collider2D>());
	}

	void Update() {
		if (currentAmmo <= 0) {
			Destroy (gameObject, 2);
		}
	}
	void OnCollisionStay2D (Collision2D other) {

		if (other.gameObject.tag == "Player") {
            //display hud

			var weaponSwitcher = other.collider.gameObject.GetComponent<WeaponSwitcher> ();

			if (Input.GetKeyDown(other.gameObject.GetComponent<WeaponSwitcher>().SwapWeapon)) {
				Debug.Log ("Picking up a " + weaponType);
				weaponSwitcher.PickupWeapon(weaponType, currentAmmo);
				Destroy(gameObject);
			}
		}

	}

	void OnTriggerStay2D(Collider2D other) {
		
		if (other.gameObject.tag == "Player") {
			
			var weaponSwitcher = other.gameObject.GetComponent<WeaponSwitcher> ();

			if (Input.GetKeyDown(other.gameObject.GetComponent<WeaponSwitcher>().SwapWeapon)) {
				Debug.Log ("Picking up a " + weaponType);
				weaponSwitcher.PickupWeapon(weaponType, currentAmmo);
				Destroy(gameObject);
			}
		}

	}
}
