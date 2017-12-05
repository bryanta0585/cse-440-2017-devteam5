using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour {

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
	private bool attackPlayer;
	private float playerAngle;


	[SerializeField] private float attackRange = 15;
	private GameObject player;
	private float speed;
	private Rigidbody2D rb;
	//[SerializeField] private float minDistance = 15;


	void Awake() {
		firePoint = transform.Find ("Fire Point");
		player = GameObject.FindWithTag ("Player");
		rb = GetComponent<Rigidbody2D>(); //Used to give the unit movement
	}


	// Update is called once per frame
	void Update () {
		//GetComponent<Animator>().SetBool ("Attack", true);
		attackPlayer = false;
		transform.parent.GetComponent<AIPatrol> ().CanMove = true;

		Vector2 direction =player.transform.position - transform.position;
		RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, direction);
		//Debug.DrawRay (firePoint.transform.position, direction, Color.red, 2);
		if (hit.transform == player.transform) {
			attackPlayer = true;
			transform.parent.GetComponent<AIPatrol> ().CanMove = false;
			transform.rotation = hit.transform.rotation;

			Vector2 temp = Vector2.zero;

			temp.x = player.transform.position.x - firePoint.transform.position.x;
			temp.y = player.transform.position.y - firePoint.transform.position.y;
			playerAngle = Mathf.Atan2 (temp.y, temp.x) * Mathf.Rad2Deg;




			//Debug.Log ("can see " + hit.transform.name);
		}


		timeAfterShot += Time.deltaTime;

		if (timeAfterShot > timeBetweenShots) {
			canShoot = true;
			//Debug.Log ("Enemy can fire");
		}

		if (attackPlayer) {
			if (canShoot) {
				timeAfterShot = 0;
				Shoot ();
				canShoot = false;
			}
		}

	}

	void Shoot() {
		transform.parent.GetComponent<Animator> ().Play ("Enemy Blink");
		//Debug.Log ("Attacking player");

		float tempSpread = bulletSpread;

		Quaternion modifiedRotation = transform.rotation;

		if (!transform.parent.GetComponent<AIPatrol> ().FacingRight) {
			modifiedRotation.z += 180;
		}

		modifiedRotation.z -= playerAngle;

		if (transform.parent.GetComponent<AIPatrol> ().FacingRight) {
			modifiedRotation.z += playerAngle;
		}

		//Debug.Log ("Player angle = " + playerAngle);


		float rotationModifier = tempSpread / numberOfBullets;
		modifiedRotation.z -= rotationModifier * (numberOfBullets / 2);

		for (int i = 0; i < numberOfBullets; i++) {


			//Debug.Log (modifiedRotation.z);
			var bullet = (GameObject)Instantiate (
				bulletPrefab,
				firePoint.position,
				modifiedRotation);

			var bulletBehavior = bullet.GetComponent<BulletBehavior> ();

			if (bulletBehavior) {
				bulletBehavior.FacingRight = transform.parent.GetComponent<AIPatrol> ().FacingRight;
				bulletBehavior.Speed = bulletSpeed;
				bulletBehavior.Damage = bulletDamage;
				bulletBehavior.BulletTime = maxBulletTime;
			} else {
				var rocketBehavior = bullet.GetComponent<RocketBehavior> ();

				rocketBehavior.FacingRight = transform.parent.GetComponent<AIPatrol> ().FacingRight;
				rocketBehavior.Speed = bulletSpeed;
				rocketBehavior.Damage = bulletDamage;
			}


			Destroy(bullet, maxBulletTime);

			tempSpread = tempSpread / 2;
			modifiedRotation.z += rotationModifier;
		} 
	}

}