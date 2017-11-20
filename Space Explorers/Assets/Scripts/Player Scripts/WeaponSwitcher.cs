using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For debug only, still need to implement weapon pickup
public class WeaponSwitcher : MonoBehaviour {

	public Transform rifle; 
	public Transform shotgun;
	public Transform pistol;
	public Transform rocketLauncher;
	public Transform currentWeapon;
	[SerializeField] private KeyCode swapWeapon;
	[SerializeField] private KeyCode equipPistol;
	[SerializeField] private KeyCode equipRifle;
	[SerializeField] private KeyCode equipShotgun;
	[SerializeField] private KeyCode equipRocketLauncher;


	[SerializeField] private GameObject droppedRifle;
	[SerializeField] private GameObject droppedShotgun;
	[SerializeField] private GameObject droppedPistol;
	[SerializeField] private GameObject droppedRocketLauncher;

	private float timeSincePickup = 0;

	public KeyCode SwapWeapon {
		get { return swapWeapon; }
	}

	void Awake() {
		Debug.Log ("Switch to rifle with up arrow");
		Debug.Log("Switch to shotgun with down arrow");
		Debug.Log("Switch to pistol with left arrow");
		Debug.Log("Switch to rocket launcher with right arrow");

		rifle = transform.Find ("Rifle");
		shotgun = transform.Find ("Shotgun");
		pistol = transform.Find ("Pistol");
		rocketLauncher = transform.Find("RocketLauncher");

		pistol.gameObject.SetActive (false);
		shotgun.gameObject.SetActive (false);
		rifle.gameObject.SetActive (false);
		rocketLauncher.gameObject.SetActive (false);

		Debug.Log("Switching to rifle");

		currentWeapon = rifle;
		currentWeapon.gameObject.SetActive (true);
	}


	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (equipRifle)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to rifle");
			currentWeapon = rifle;
			currentWeapon.gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (equipShotgun)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to shotgun");
			currentWeapon = shotgun;
			currentWeapon.gameObject.SetActive (true);
		}

		if (Input.GetKeyDown (equipPistol)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to pistol");
			currentWeapon = pistol;
			currentWeapon.gameObject.SetActive (true);
		}

		if (Input.GetKeyDown (equipRocketLauncher)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to Rocket Launcher");
			currentWeapon = rocketLauncher;
			currentWeapon.gameObject.SetActive (true);
		}



		if (Input.GetKeyDown(swapWeapon) && currentWeapon != null && timeSincePickup > 1) {

			if (currentWeapon == transform.Find("Pistol")) {
				var droppedWeapon = Instantiate (droppedPistol, rifle.position, rifle.rotation);
			}
			else if (currentWeapon == transform.Find("Rifle")) {
				var droppedWeapon = Instantiate (droppedRifle, rifle.position, rifle.rotation);
			}
			else if (currentWeapon == transform.Find("Shotgun")) {
				var droppedWeapon = Instantiate (droppedShotgun, rifle.position, rifle.rotation);
			}
			else if (currentWeapon == transform.Find("RocketLauncher")) {
				var droppedWeapon = Instantiate (droppedRocketLauncher, rifle.position, rifle.rotation);
			}
			currentWeapon.gameObject.SetActive (false);
			Debug.Log ("Dropping weapon");
			currentWeapon = null;
		}

		timeSincePickup += Time.deltaTime;
	}


	public void PickupWeapon(string weaponType, int weaponAmmo) {

		if (currentWeapon != null) {
			var droppedWeapon = Instantiate (droppedRifle, transform.position, transform.rotation);
			currentWeapon.gameObject.SetActive (false);
			Debug.Log ("Dropping weapon and picking up a " + weaponType);
			currentWeapon = null;
		} 

		currentWeapon = transform.Find(weaponType);
		currentWeapon.gameObject.SetActive (true);
		timeSincePickup = 0;
	}
}
