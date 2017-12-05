using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Destroy object after time specified in timeToDie
public class Destroy : MonoBehaviour {

	[SerializeField] private int timeToDie;

	public void DestroyTimer() {
		Destroy (gameObject, timeToDie);
	}
}
