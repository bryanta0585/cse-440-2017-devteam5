using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For debug only, still need to implement weapon pickup
public class WeaponSwitcher : MonoBehaviour {

	public Transform rifle; 
	public Transform shotgun;
	public Transform pistol;
	public Transform rocketLauncher;
	public Transform arm;
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
	private  int currentAmmo;

	public KeyCode SwapWeapon {
		get { return swapWeapon; }
	}

	public int CurrentAmmo {
		get {return currentAmmo;}
	}
    public string CurrentWeapon
    {
        get { return currentWeapon.name; }
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
		arm = transform.Find("Arm");

		pistol.gameObject.SetActive (false);
		shotgun.gameObject.SetActive (false);
		rifle.gameObject.SetActive (false);
		rocketLauncher.gameObject.SetActive (false);
		arm.gameObject.SetActive (false);

		//Debug.Log("Switching to rifle");

		currentWeapon = rifle;
		currentWeapon.gameObject.SetActive (true);
	}


	// Update is called once per frame
	void Update () {

		if (currentWeapon == null) {
			currentAmmo = 0;
		} else {
			currentAmmo = currentWeapon.GetComponent<GunScript> ().Ammo;
		}


		if (Input.GetKeyDown (equipRifle)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to rifle");
			currentWeapon = rifle;
			currentWeapon.gameObject.SetActive (true);
			currentWeapon.GetComponent<GunScript> ().Ammo = 100;
		}
		if (Input.GetKeyDown (equipShotgun)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to shotgun");
			currentWeapon = shotgun;
			currentWeapon.gameObject.SetActive (true);
			currentWeapon.GetComponent<GunScript> ().Ammo = 100;
		}

		if (Input.GetKeyDown (equipPistol)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to pistol");
			currentWeapon = pistol;
			currentWeapon.gameObject.SetActive (true);
			currentWeapon.GetComponent<GunScript> ().Ammo = 100;
		}

		if (Input.GetKeyDown (equipRocketLauncher)) {
			if (currentWeapon != null) {
				currentWeapon.gameObject.SetActive (false);
			}
			Debug.Log ("Switching to Rocket Launcher");
			currentWeapon = rocketLauncher;
			currentWeapon.gameObject.SetActive (true);
			currentWeapon.GetComponent<GunScript> ().Ammo = 100;
		}



		if (Input.GetKeyDown(swapWeapon) && currentWeapon != arm && timeSincePickup > 1) {

			if (currentWeapon == transform.Find("Pistol")) {
				var droppedWeapon = Instantiate (droppedPistol, rifle.position, rifle.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
			else if (currentWeapon == transform.Find("Rifle")) {
				var droppedWeapon = Instantiate (droppedRifle, rifle.position, rifle.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
			else if (currentWeapon == transform.Find("Shotgun")) {
				var droppedWeapon = Instantiate (droppedShotgun, rifle.position, rifle.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
			else if (currentWeapon == transform.Find("RocketLauncher")) {
				var droppedWeapon = Instantiate (droppedRocketLauncher, rifle.position, rifle.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
				
			currentWeapon.gameObject.SetActive (false);
			Debug.Log ("Dropping weapon");
			arm.gameObject.SetActive (true);
			currentWeapon = arm;
		}

		timeSincePickup += Time.deltaTime;
	}


	public void PickupWeapon(string weaponType, int weaponAmmo) {

		if (currentWeapon != arm) {

			if (currentWeapon == pistol) {
				var droppedWeapon = Instantiate (droppedPistol, transform.position, transform.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
			else if (currentWeapon == rifle) {
				var droppedWeapon = Instantiate (droppedRifle, transform.position, transform.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
			else if (currentWeapon == shotgun) {
				var droppedWeapon = Instantiate (droppedShotgun, transform.position, transform.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}
			else if (currentWeapon == rocketLauncher) {
				var droppedWeapon = Instantiate (droppedRocketLauncher, transform.position,transform.rotation);
				droppedWeapon.GetComponent<WeaponPickup>().CurrentAmmo = currentAmmo;
			}



			//var droppedWeapon = Instantiate (droppedRifle, transform.position, transform.rotation);
			currentWeapon.gameObject.SetActive (false);
			Debug.Log ("Dropping weapon and picking up a " + weaponType);
			currentWeapon = arm;
			currentWeapon.gameObject.SetActive (true);

		} 
		currentWeapon.gameObject.SetActive (false);
		currentWeapon = transform.Find(weaponType);
		currentWeapon.GetComponent<GunScript>().Ammo = weaponAmmo;
		currentWeapon.gameObject.SetActive (true);
		timeSincePickup = 0;
	}
}
