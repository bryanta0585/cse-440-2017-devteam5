using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [SerializeField]
    private GameObject target;
    private Vector3 offset;
    // Use this for initialization
    private void Awake()
    {
        offset = new Vector3(0, 0, -20);
    }
    void Start () {
        gameObject.transform.position = target.transform.position + offset;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = target.transform.position + offset;
    }

}
