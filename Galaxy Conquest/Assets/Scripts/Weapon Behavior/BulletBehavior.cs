using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	private float speed;
	private int damage;
	private bool facingRight;
	private float bulletTime;
	private Transform bulletImpact;
	private Vector2 hitPoint;
	private Collider2D hitCollider;
	private bool foundRayHit = false;
	private bool playerBullet;

	void Awake() {
		bulletImpact = transform.Find ("BulletImpact");
	}

	public bool FacingRight {
		get {return facingRight;}
		set {facingRight = value;}
	}

	public bool PlayerBullet{
		set {playerBullet = value;}
	}

	public float Speed {
		get {return speed;}
		set {speed = value;}
	}

	public int Damage {
		get {return damage;}
		set {damage = value;}
	}
	public float BulletTime {
		get {return bulletTime;}
		set {bulletTime = value;}
	}


	void Update (){

		if (!foundRayHit) {
			FindRayHit ();
			foundRayHit = true;
		}
			

		if (hitPoint != null && hitPoint != Vector2.zero) {
			if (transform.position.x == hitPoint.x && transform.position.y == hitPoint.y) {
				HitSomething (hitCollider);
			}
				
			if (facingRight) {

				//Debug.Log (hitTransform.position);
				if ((transform.position.x == hitPoint.x && transform.position.y == hitPoint.y) || (transform.position + (Vector3.right * Time.deltaTime * speed)).x > hitPoint.x) {

					if (hitCollider == null) {
						if (hitCollider.gameObject.tag != "Player") {
							transform.position = hitPoint;
							//Debug.Log ("right raycast hit " + hitPoint);
							HitSomething (hitCollider);
						}
					}else {
						hitPoint = Vector2.zero;
					}



				} else {
					FindRayHit ();
					transform.Translate (Vector3.right * Time.deltaTime * speed);
				}

			} else {
				
				if ((transform.position.x == hitPoint.x && transform.position.y == hitPoint.y)  || (transform.position + (Vector3.left * Time.deltaTime * speed)).x < hitPoint.x ) {

					if (hitCollider == null || hitCollider.gameObject == null) {
						bulletImpact.GetComponent<ParticleSystem> ().Play();
						bulletImpact.gameObject.transform.parent = null;
						Destroy (gameObject);
					}

					else if (hitCollider.gameObject.tag != "Player") {
						transform.position = hitPoint;
						//Debug.Log ("left raycast hit " + hitPoint);
						HitSomething (hitCollider);
					} else {
						hitPoint = Vector2.zero;
					}
						
				} else {
					FindRayHit ();
					transform.Translate(Vector3.right * Time.deltaTime * speed);
				}
			}

		} else {
				transform.Translate(Vector3.right * Time.deltaTime * speed);
		}

	}

	void OnCollision2D(Collision2D other) {
		//Debug.Log ("bullet hit collider");
		HitSomething (other.collider);

	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("bullet hit trigger");
		//Debug.Log(other.gameObject.name);
		HitSomething (other);


	}

	void FindRayHit() {
		RaycastHit2D hit;

		if (facingRight) {
			hit = Physics2D.Raycast (transform.position + Vector3.right, transform.right, bulletTime * speed);
			//Debug.DrawRay (transform.position + Vector3.right, transform.right , Color.blue, 20);
		} else {
			hit = Physics2D.Raycast (transform.position + Vector3.left, transform.right, bulletTime * speed);
			//Debug.DrawRay (transform.position + Vector3.left, transform.right, Color.green, 20);
		}
		if (hit) {
			hitPoint = hit.point;
			hitCollider = hit.collider;
		}
	}

	void HitSomething(Collider2D other) {
		if (other != null) {

			//Debug.Log ("Bullet facing right = " + facingRight);

			//Player can't be hit by their own bullets
			if (playerBullet && other.gameObject.name == "Player") {
				return;
			}

			if ( other.gameObject.name != "Bullet(Clone)" ) {

				//Debug.Log ("Bullet hit " + other.gameObject.name);

				var healthComponent = other.gameObject.GetComponent<HealthComponent> ();
				if (healthComponent != null) { //Only trigger damage if the object possesses a HealthComponent
					healthComponent.SendMessage("AddDamage", damage); //Attempts to call the AddDamage function of HealthComponentScript, has no effect if none is present.
				}
				bulletImpact.GetComponent<ParticleSystem> ().Play();
				bulletImpact.gameObject.transform.parent = null;
				Destroy (gameObject);
			};
		}

	}
}