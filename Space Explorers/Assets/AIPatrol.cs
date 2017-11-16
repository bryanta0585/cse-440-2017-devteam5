using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Used for easy sorting of list of NavPoints


//WARNING this script requires gameObjects tagged with "navPoint"
public class AIWalkingScript : MonoBehaviour {


	private float speed;
	[SerializeField] private int walkTime = 4;
	private float time;

	void Awake() {
		
		//Import speed variable from the object's MovementComponent
		var MovementComponent = gameObject.GetComponent<MovementComponent> ();
		speed = MovementComponent.GetSpeed;

	}

	// Update is called once per frame
	void Update () {



		time += Time.deltaTime;

		if (time > walkTime) {
			time = 0;
		}
	}
		
}

