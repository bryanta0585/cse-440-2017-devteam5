using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    private KeyCode left, right, up, down;
    private KeyCode[] keys;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
      

        if (Input.GetKey(left))
        {
           rb.velocity = Vector2.left * speed;
        }
        if (Input.GetKeyDown(right))
        {
            rb.velocity = Vector2.right * speed;
        }
        if (Input.GetKeyDown(up))
        {
            rb.velocity = Vector2.up * speed;
        }
        if (Input.GetKeyDown(down))
        {
            rb.velocity = Vector2.down * speed;
        }


    }
}
