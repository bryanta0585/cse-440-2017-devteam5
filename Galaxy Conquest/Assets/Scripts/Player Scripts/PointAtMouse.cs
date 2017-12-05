using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The object this is attached to will point at the players cursor.
//Object only rotates if it's added in FlipPlayer.cs!
public class PointAtMouse : MonoBehaviour {

	private Vector3 mousePosition;
	private float angle;
	private Vector3 objectPosition;
	private bool facingRight;

	void Awake() {

		var MovementComponent = gameObject.GetComponent<MovementComponent> ();
		facingRight = MovementComponent.FacingRight;
	}

	public bool FacingRight {
		get { return facingRight; }
	}

	// Update is called once per frame
	public void Point(float foundAngle) {
		 
		angle = foundAngle;

		Vector3 temp = Vector3.zero;
		temp.z = angle;
		transform.rotation = Quaternion.Euler (temp);

			//Debug.Log (angle);
			if (angle > 0f && angle < 70f || angle < 0f && angle > -70f) {
				if (!facingRight) {
					gameObject.GetComponent<SpriteRenderer> ().flipY = false;
					gameObject.GetComponent<MovementComponent> ().Flip ();
					facingRight = !facingRight;
					transform.Find("Arm Only").gameObject.GetComponent<SpriteRenderer> ().flipY = false;
				}
			}

			if (angle > 100f && angle < 170f || angle < -100f && angle > -170f) {
				if (facingRight) {
					gameObject.GetComponent<SpriteRenderer> ().flipY = true;
					gameObject.GetComponent<MovementComponent> ().Flip ();
					facingRight = !facingRight;
				transform.Find("Arm Only").gameObject.GetComponent<SpriteRenderer> ().flipY = true;
				}
			}
		}
}
