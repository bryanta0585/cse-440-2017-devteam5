using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackComponent : MonoBehaviour {

	[SerializeField] private float boostModifier;
	[SerializeField] private float jumpModifier;
	private KeyCode boost;
	private KeyCode moveLeft, moveRight, jump;
	private Rigidbody2D rb;
	private MovementComponent movementComponent;
	private ParticleSystem particles;
	private bool initialStop = true;
	private float jetpackGuage = 0;
	[SerializeField] private float jetpackGuageMax = 5;
	private bool boosting = false;

	public float JetpackGuage {
		get {return jetpackGuage; }
	}

	public float JetpackGuageMax {
		get {return jetpackGuageMax; }
	}

	// Use this for initialization
	void Awake() {
		movementComponent = GetComponent<MovementComponent> ();
		boost = movementComponent.boost;
		moveLeft = movementComponent.moveLeft;
		moveRight = movementComponent.moveRight;
		jump = movementComponent.jump;
		rb = GetComponent<Rigidbody2D> ();
		particles = transform.Find ("Jetpack Particles").GetComponent<ParticleSystem> (); 
		particles.enableEmission = false;
		var temp = particles.emission.enabled;
		temp = false;
	}
	// Update is called once per frame
	void Update () {

		if (!Input.GetKey (boost)) {
			jetpackGuage += Time.deltaTime;
		}

		if (jetpackGuage > jetpackGuageMax) {
			jetpackGuage = jetpackGuageMax;
		}
		if (jetpackGuage < 0) {
			jetpackGuage = 0;
		}

		if (initialStop) {
			particles.enableEmission = false;
			initialStop = false;
		}

		if (Input.GetKeyDown (boost)) {
			
			if (jetpackGuage > 0) {
				jetpackGuage -= Time.deltaTime;
				movementComponent.GetSpeed *= boostModifier;
				movementComponent.JumpHeight *= jumpModifier;
				var temp = particles.emission.enabled;
				temp = true;
				Debug.Log ("Starting particles");
				//particles.Play ();
				particles.enableEmission = true;
				boosting = true;
			}
			}
			
		if (Input.GetKey (boost)) {
			if (jetpackGuage > 0) {
				jetpackGuage -= Time.deltaTime;
				if (!Input.GetKey (moveLeft) && !Input.GetKey (moveRight) && !Input.GetKey (jump)) {
					rb.velocity = Vector3.zero;
				}

			} else {
				if (boosting) {
					movementComponent.GetSpeed /= boostModifier;
					movementComponent.JumpHeight /= jumpModifier;
					boosting = false;
				}
				particles.enableEmission = false;
			}

		}
		if (Input.GetKeyUp (boost)) {

			if (boosting) {
				movementComponent.GetSpeed /= boostModifier;
				movementComponent.JumpHeight /= jumpModifier;
				boosting = false;
			}

			particles.enableEmission = false;
			//Debug.Log ("Stopping particles");
			//particles.Pause ();
		}


	}
}
