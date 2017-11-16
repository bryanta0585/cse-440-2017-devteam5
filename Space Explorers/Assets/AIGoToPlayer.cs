using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The object this is attached to will move directly towards the player when they are closer than minDistance. It doesn't follow physics (floats through air), so it's best used on flying enemies
public class AIGoToPlayer : MonoBehaviour {

	private GameObject player;
	private float speed;
	private Rigidbody2D rb;
	[SerializeField] private float minDistance = 15;

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

			Debug.Log ("Player in range");
			Vector3 velocity = (player.transform.position - transform.position) * speed * Time.deltaTime;
			rb.velocity = velocity;
		}
	}
}

