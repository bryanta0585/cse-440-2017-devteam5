using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour {
	
	private float speed;
	private int damage;
	private bool facingRight = true;
	private Rigidbody2D rb;
	private Transform rocketParticles;
	private Transform rocketImpact;
	private bool damageApplied = false;
	void Awake() {
		
		rocketParticles = transform.Find ("RocketParticles");
		rocketImpact = transform.Find ("RocketImpact");

		GetComponent<CircleCollider2D> ().enabled = false;
	}


	public bool FacingRight {
		get {return facingRight;}
		set {facingRight = value;}
	}

	public float Speed {
		get {return speed;}
		set {speed = value;}
	}

	public int Damage {
		get {return damage;}
		set {damage = value;}
	}

	void Update (){
		
			transform.Translate(Vector3.right * Time.deltaTime * speed);
	

		if (damageApplied) {
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D other) {

		HitSomething (other.collider);

	}

	void OnTriggerStay2D(Collider2D other) {

		var healthComponent = other.gameObject.GetComponent<HealthComponent> ();
		if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
			healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
		}
		damageApplied = true;
	}

	void HitSomething(Collider2D other) {
		
		if (other.gameObject.name!= "Bullet(Clone)") {

			if (!damageApplied) {
				var healthComponent = other.gameObject.GetComponent<HealthComponent> ();
				if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
					healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
				}
				rocketImpact.GetComponent<ParticleSystem> ().Play();
				rocketImpact.gameObject.transform.parent = null;
				rocketParticles.gameObject.transform.parent = null;
				GetComponent<CircleCollider2D> ().enabled = true;
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			}
		};
	}
}
