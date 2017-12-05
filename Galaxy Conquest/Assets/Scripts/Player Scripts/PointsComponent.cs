using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach to player object so you can use "AddPoints.cs" to increase score
public class PointsComponent : MonoBehaviour {

	[SerializeField] private int points = 0;

	public float Points{
		get { return points; }
	}

	public void AddPoints(int pointsToAdd) {

		points += pointsToAdd;
		Debug.Log ("Points changed to: " + points);
	}
		
}
