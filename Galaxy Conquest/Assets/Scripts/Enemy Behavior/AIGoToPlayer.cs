using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The object this is attached to will move directly towards the player when they are closer than minDistance. It doesn't follow physics (floats through air), so it's best used on flying enemies
public class AIGoToPlayer : MonoBehaviour {

	private GameObject player;
	private float speed;
	private Rigidbody2D rb;
	[SerializeField] private float minDistance = 15;
	[SerializeField] private float maxSpeed = 100;

	void Awake() {
		player = GameObject.FindWithTag ("Player");
		rb = GetComponent<Rigidbody2D>(); //Used to give the unit movement
		var MovementComponent = gameObject.GetComponent<MovementComponent> ();
		speed = MovementComponent.GetSpeed;
	}
		

	// Update is called once per frame
	void Update () {
		//Handles enemy movement
		Vector3 playerPosition = player.transform.position;

		if ((transform.position - playerPosition).magnitude < minDistance) { 



			//Debug.Log ("Player in range");
			Vector2 velocity = Vector2.zero;


			if (player.transform.position.x - transform.position.x < 0) {
				//GetComponent<MovementComponent> ().Flip ();
				//GetComponent<MovementComponent> ().Flip ();
				velocity = Vector2.left * speed * Time.deltaTime;
				GetComponent<SpriteRenderer> ().flipX = false;
			} else {
				//aGetComponent<MovementComponent> ().Flip ();
				velocity = Vector2.right * speed * Time.deltaTime;
				GetComponent<SpriteRenderer> ().flipX = true;
			}


			//velocity = -transform.right * speed * Time.deltaTime;



			//rb.velocity = velocity;
			if (Mathf.Abs (rb.velocity.x) < maxSpeed) {
				rb.AddForce (velocity);
			}

		}
	}
}

