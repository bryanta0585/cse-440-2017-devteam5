using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is used to manage unit movement. This script should be applied to anything that can move freely to simplify the posibility of mismatched speed values turning out wierd
public class MovementComponent : MonoBehaviour {

	[SerializeField] public KeyCode moveForward;
	[SerializeField] public KeyCode moveLeft;
	[SerializeField] public KeyCode moveRight;
	[SerializeField] public KeyCode moveBackward;
	[SerializeField] public KeyCode jump;
	[SerializeField] public KeyCode boost;
	private Rigidbody2D rb;
	[SerializeField] private float speed = 10;
	[SerializeField] private float originalSpeed;
	[SerializeField] private float jumpHeight = 100;
	[SerializeField] private float timeToDie = 10;
	[SerializeField] private int maxJumps = 2;
	[SerializeField] private float boostModifier = 2;
	[SerializeField] private float jumpModifier = 2;
	bool facingRight = true;
	[SerializeField] bool flipOnce = false; //Flips target to face other direction and prevents weird issues
	private int timesJumped;
    [SerializeField] private LayerMask whatIsGround;    //Defines what layers are ground
    private bool isGrounded;                            //Value determining if player is touching ground
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    [SerializeField]
    private GameObject sound;
	private Animator anim;
   
    //Use for loading stuff that takes awhile to load
    void Awake () {
		anim = GetComponent<Animator>();

        originalSpeed = speed; //Used to restore speed it it's value is changed
		rb = GetComponent<Rigidbody2D>(); //Used to give the unit movement

		timesJumped = 0;

		if (flipOnce) {
			Flip ();
			flipOnce = false;
		}
	}

	// Update is called once per frame
	void Update ()
    {
        Movement ();
	}

	public void Flip() {
		Vector3 temp = transform.localScale;
		temp.x = -1 * temp.x;
		transform.localScale = temp;
		facingRight = !facingRight;
	}

	IEnumerator DestroyUnit() {
		yield return new WaitForSeconds(timeToDie);
		Destroy (gameObject);
	}


	public float GetSpeed {
		get { return speed; }
		set { speed = value; }
	}

	public float JumpHeight {
		get { return jumpHeight; }
		set { jumpHeight= value; }
	}

	public bool FacingRight {
		get { return facingRight; }
	}

	void ChangeSpeed(int modifier) {
		speed += modifier;
	}

	void Jump() 
	{
		anim.SetBool ("isWalking", false);
			rb.AddForce (Vector3.up * jumpHeight);	
			timesJumped++;
            GetComponent<AudioManager>().PlayerJumpUp();
    }

	//This simple movement script causes the enemy to move towards the player if they are within $minDistance of each other
	void Movement() {

		if (tag == "Player") {


			if (Input.GetKey (moveForward) || Input.GetKey (moveBackward) || Input.GetKey (moveLeft) || Input.GetKey (moveRight)) {
				anim.SetBool ("isWalking", true);
			} else {
				anim.SetBool ("isWalking", false);
			}

			Vector3 tempVelocity;

            // Checks to see if player is grounded and sets bool value
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			
			if (isGrounded) {
				timesJumped = 0;
			} else {
				anim.SetBool ("isWalking", false);
			}

			//Handles player movement
			if (Input.GetKey (moveForward)) {
				tempVelocity = Vector3.forward * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;
				//rb.AddForce (Vector3.forward * speed * Time.deltaTime);
			}

			if (Input.GetKey (moveLeft)) {
				tempVelocity = Vector3.left * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;
				//rb.AddForce (Vector3.left * speed * Time.deltaTime);
			}

			if (Input.GetKey (moveRight)) {
				tempVelocity = Vector3.right * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;

				//rb.AddForce (Vector3.right * speed * Time.deltaTime);
			}

			if (Input.GetKey (moveBackward)) {
				tempVelocity = Vector3.back * speed;
				tempVelocity.y = rb.velocity.y;
				rb.velocity = tempVelocity;
				//rb.AddForce (Vector3.back * speed * Time.deltaTime);
			}


			if (Input.GetKeyDown (jump))
            {
				if(isGrounded)
				{
					Jump();
				}
				else if(!isGrounded && timesJumped < maxJumps)
				{
					Jump();
				}
			} 
		}
	}

	/*void OnCollisionEnter2D(Collision2D other) {
		timesJumped = 0;
	}*/
}