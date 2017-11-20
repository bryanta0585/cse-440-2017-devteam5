using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is used to manage unit movement. This script should be applied to anything that can move freely to simplify the posibility of mismatched speed values turning out wierd
public class MovementComponent : MonoBehaviour {

	[SerializeField] private KeyCode moveForward;
	[SerializeField] private KeyCode moveLeft;
	[SerializeField] private KeyCode moveRight;
	[SerializeField] private KeyCode moveBackward;
	[SerializeField] private KeyCode jump;
	[SerializeField] private KeyCode boost;
	private Rigidbody2D rb;
	[SerializeField] private float speed = 10;
	[SerializeField] private float originalSpeed;
	[SerializeField] private float jumpHeight = 100;
	[SerializeField] private float timeToDie = 10;
	[SerializeField] private int maxJumps = 2;
	[SerializeField] private float boostModifier = 2;
	bool facingRight = true;
	private int timesJumped;

	//Use for loading stuff that takes awhile to load
	void Awake () {
		originalSpeed = speed; //Used to restore speed it it's value is changed
		rb = GetComponent<Rigidbody2D>(); //Used to give the unit movement

		timesJumped = 0;
	}

	// Update is called once per frame
	void Update () {
		Movement ();


	}

	public void Flip() {
		Vector3 temp = transform.localScale;
		temp.x = -1 * temp.x;
		transform.localScale = temp;
		facingRight = !facingRight;
	}

	IEnumerator DestroyUnit() {
		yield return new WaitForSeconds(timeToDie);
		Destroy (gameObject);
	}


	public float GetSpeed {
		get { return speed; }
	}

	public bool FacingRight {
		get { return facingRight; }
	}

	void ChangeSpeed(int modifier) {
		speed += modifier;
	}

	void Jump() {
		if (timesJumped < maxJumps) { 
			rb.AddForce (Vector3.up * jumpHeight);	
			timesJumped++;
		}
	}

	//This simple movement script causes the enemy to move towards the player if they are within $minDistance of each other
	void Movement() {

		if (tag == "Player") {

			Vector3 tempVelocity;

			//Handles player movement
			if (Input.GetKey (moveForward)) {
                
				tempVelocity = Vector3.forward * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;
				//rb.AddForce (Vector3.forward * speed * Time.deltaTime);
			}

			if (Input.GetKey (moveLeft)) {
				tempVelocity = Vector3.left * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;
				//rb.AddForce (Vector3.left * speed * Time.deltaTime);
			}

			if (Input.GetKey (moveRight)) {
				tempVelocity = Vector3.right * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;

				//rb.AddForce (Vector3.right * speed * Time.deltaTime);
			}

			if (Input.GetKey (moveBackward)) {
				tempVelocity = Vector3.back * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;
				//rb.AddForce (Vector3.back * speed * Time.deltaTime);
			}


			if (Input.GetKeyDown (jump)) {
				Jump ();
			} 

			if (Input.GetKeyDown (boost)) {
				speed = speed * boostModifier;
			}
			if (Input.GetKey (boost)) {
				if (!Input.GetKey(moveLeft) && !Input.GetKey(moveRight) && !Input.GetKey(jump)) {
					rb.velocity = Vector3.zero;
				}
			}
			if (Input.GetKeyUp (boost)) {
				speed = speed / boostModifier;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		timesJumped = 0;
	}
}