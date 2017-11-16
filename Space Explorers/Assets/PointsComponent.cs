using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach to player object so you can use "AddPoints.cs" to increase score
public class PointsComponent : MonoBehaviour {

	[SerializeField] private float points = 10.0f;

	public float GetPoints{
		get { return points; }
	}

	void AddPoints(float pointsToAdd) {

		points += pointsToAdd;
		Debug.Log ("Points changed to: " + points);
	}
		
}
