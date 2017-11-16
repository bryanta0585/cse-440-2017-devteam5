using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	[SerializeField] private GameObject bulletClone;
	[SerializeField] private float initialSpeed = 100;
	// Use this for initialization
	void Start () {
		//bulletClone = (GameObject)Instantiate (bulletClone, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F)) {
			Shoot ();
		}
	}

	public void Shoot() {
		GameObject temp = (GameObject)Instantiate (bulletClone, transform.position, transform.rotation);
		Rigidbody2D rb = temp.GetComponent<Rigidbody2D> ();
		rb.AddForce (temp.transform.forward * initialSpeed);
		Debug.Log ("Transform.forward is: " + temp.transform.forward);
		temp.GetComponent<Destroy> ().DestroyTimer ();
	}
}
