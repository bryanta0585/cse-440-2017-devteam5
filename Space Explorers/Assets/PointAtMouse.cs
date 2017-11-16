using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The object this is attached to will point at the players cursor.
public class PointAtMouse : MonoBehaviour {

	private Vector3 mousePosition;
	private float angle;
	private Vector3 objectPosition;
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;

		//Get pixels of current object position
		objectPosition = Camera.main.WorldToScreenPoint (transform.position);

		mousePosition.x = mousePosition.x - objectPosition.x;
		mousePosition.y = mousePosition.y - objectPosition.y;
		angle = Mathf.Atan2 (mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

		Vector3 temp = Vector3.zero;
		temp.z = angle;
		transform.rotation = Quaternion.Euler (temp);

	}
}
