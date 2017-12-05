using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour {

	private Vector3 mousePosition;
	private float angle;
	private Vector3 objectPosition;
	private bool facingRight;

	// Update is called once per frame
	void Update () {

		mousePosition = Input.mousePosition;

		//Get pixels of current object position
		objectPosition = Camera.main.WorldToScreenPoint (transform.position);

		mousePosition.x = mousePosition.x - objectPosition.x;
		mousePosition.y = mousePosition.y - objectPosition.y;
		angle = Mathf.Atan2 (mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

		//Debug.Log (angle);
		if (angle > 0f && angle < 70f || angle < 0f && angle > -70f) {
			if (facingRight) {
				gameObject.GetComponent<MovementComponent> ().Flip ();
				facingRight = !facingRight;

			}
		}

		if (angle > 100f && angle < 170f || angle < -100f && angle > -170f) {
			if (!facingRight) {
				gameObject.GetComponent<MovementComponent> ().Flip ();
				facingRight = !facingRight;

			}
		}

		transform.Find ("Rifle").GetComponent<PointAtMouse> ().Point (angle);
		transform.Find ("Shotgun").GetComponent<PointAtMouse> ().Point (angle);
		transform.Find ("Pistol").GetComponent<PointAtMouse> ().Point (angle);
		transform.Find ("RocketLauncher").GetComponent<PointAtMouse> ().Point (angle);
		transform.Find ("Arm").GetComponent<PointAtMouse> ().Point (angle);

	}
}
