using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private KeyCode up;
    private KeyCode[] keys;
    [SerializeField] private float maxSpeed = 5.0f;     //Max movement speed
    [SerializeField] private float jumpForce = 250.0f;  //Max jump force
    [SerializeField] private LayerMask whatIsGround;    //Defines what layers are ground

    public Transform groundCheck;
    private bool isGrounded;            //Value determining if player is touching ground
    private bool facingRight = true;    //Value determining which direction player facing
    private float groundRadius = 0.2f;  
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    //Contains call for playermovement
	void FixedUpdate ()
    {
        //Sets the value for whether player is grounded or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        playerMovement();
    }

    //Update is called once per frame
    void Update ()
    {
        //Allows player to jump only when grounded
        if(isGrounded && Input.GetKeyDown(up))
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    //Function for player movement
    void playerMovement()
    {
        //Movement code to move left to right
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        //Check to see which direction player facing
        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }

        /*
        if (Input.GetKey(left))
        {
            rb.velocity = Vector2.left * speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(right))
        {
            rb.velocity = Vector2.right * speed;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(up) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown(down))
        {
            rb.velocity = Vector2.down * speed;
        }*/
    }

    //Function that changes direction player is facing
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
