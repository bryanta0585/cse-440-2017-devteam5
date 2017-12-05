using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	private bool facingRight = true;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private KeyCode shoot;
	//[SerializeField] private Transform firePoint;
	[SerializeField] private float bulletSpeed = 50;
	[SerializeField] private int bulletDamage = 2;
	[SerializeField] private int numberOfBullets = 1;
	private bool canShoot = true;
	[SerializeField] private float timeBetweenShots;
	private float timeAfterShot;
	[SerializeField] private float bulletSpread = 0.01f;
	[SerializeField] private float maxBulletTime = 1f;
	private Transform firePoint;
	[SerializeField] private int ammo = 100;
    
	void Awake() {
		firePoint = transform.Find ("Fire Point");
	}
		

	public int Ammo {
		get {return ammo;}
		set {ammo = value;}
	}

	// Update is called once per frame
	void Update () {

		timeAfterShot += Time.deltaTime;

		if (timeAfterShot > timeBetweenShots) {
			canShoot = true;
		}

		if (Input.GetKey(shoot)) {

			if(ammo<=0)
			{ 
				gameObject.GetComponent<GunAudio>().PlayAmmo();
			}

			if (canShoot && ammo > 0) {
				Shoot ();
				canShoot = false;
				ammo--;
				timeAfterShot = 0;
			}
            
		}
			
	}

	void Shoot() {

		float tempSpread = bulletSpread;

		Quaternion modifiedRotation = transform.rotation;

		float rotationModifier = tempSpread / numberOfBullets;
		modifiedRotation.z -= rotationModifier * (numberOfBullets / 2);

		for (int i = 0; i < numberOfBullets; i++) {


			//Debug.Log (modifiedRotation.z);
			var bullet = (GameObject)Instantiate (
				bulletPrefab,
				firePoint.position,
				modifiedRotation);
            gameObject.GetComponent<GunAudio>().PlaySingle();
			var bulletBehavior = bullet.GetComponent<BulletBehavior> ();

			if (bulletBehavior) {
				bulletBehavior.FacingRight = GetComponent<PointAtMouse>().FacingRight;
				bulletBehavior.Speed = bulletSpeed;
				bulletBehavior.Damage = bulletDamage;
				bulletBehavior.BulletTime = maxBulletTime;
				bulletBehavior.PlayerBullet = true;

			} else {
				var rocketBehavior = bullet.GetComponent<RocketBehavior> ();

				rocketBehavior.FacingRight = GetComponent<PointAtMouse>().FacingRight;
				rocketBehavior.Speed = bulletSpeed;
				rocketBehavior.Damage = bulletDamage;
			}


			Destroy(bullet, maxBulletTime);

			tempSpread = tempSpread / 2;
			modifiedRotation.z += rotationModifier;
		}
	}
}
