using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Used for easy sorting of list of NavPoints


//WARNING this script requires gameObjects tagged with "navPoint"
public class AIPatrol : MonoBehaviour {

	private bool facingRight = true;
	private bool canMove = true;

	public bool FacingRight {
		get {return facingRight;}
	}

	public bool CanMove {
		get {return canMove;}
		set { canMove = value;}
	}

	private float speed;
	[SerializeField] private int walkTime = 4;
	private float time;
	void Awake() {
		
		//Import speed variable from the object's MovementComponent
		var MovementComponent = gameObject.GetComponent<MovementComponent> ();
		speed = MovementComponent.GetSpeed;

		facingRight = MovementComponent.FacingRight;
	}

	// Update is called once per frame
	void Update () {


		if (canMove && walkTime != 0) {
			time += Time.deltaTime;

			if (facingRight) {
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else {
				transform.position += Vector3.left * speed * Time.deltaTime;
			}

			if (time > walkTime) {
				time = 0;
				gameObject.GetComponent<MovementComponent> ().Flip ();
				facingRight = !facingRight;
				//Debug.Log ("Facing right changed to " + facingRight);
			}
		}

	}
		
}

