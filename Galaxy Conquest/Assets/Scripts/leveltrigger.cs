using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveltrigger : MonoBehaviour {
    bool levelcompleted;
	// Use this for initialization
	void Start () {
        levelcompleted = false;

    }
	

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            levelcompleted = true;
        }
    }
}
