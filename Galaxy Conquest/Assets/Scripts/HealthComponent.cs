using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This script is used to track the health of an object. It will despawn the object if their health reaches 0. Damage and healing should be added to objects via DamageScript and HealScript respectively.
public class HealthComponent : MonoBehaviour {

	[SerializeField] private GameObject dropOnDeath;
	[SerializeField] private float health = 10.0f;
	[SerializeField] private int pointsAddedOnDeath = 1;
	[SerializeField] private float knockbackDistance = 2f;
	[SerializeField] private float knockbackHeight = 2f;
	[SerializeField] private float shield;
    [SerializeField] private GameObject sound;
 
    public float Health {
		get { return health; }
	}

	public float Shield {
		get {return shield;}
	}
 

	//This function is used instead of Update() to conserve resources since the player's health should only change through AddDamage and AddHealth
	void CheckHealth() {
		//If health less than or equal to 0, despawns the player.
		if (health <= 0.0f) {

			if (dropOnDeath != null) {
				Instantiate (dropOnDeath, transform.position, transform.rotation);
			}

			GameObject.FindGameObjectWithTag ("Player").GetComponent<PointsComponent> ().AddPoints (pointsAddedOnDeath);
            if(tag=="Enemy")
            {
                Debug.Log("playing music");
                gameObject.GetComponent<EnemyAudio>().PlayHurt();
                

            }
            Debug.Log(gameObject.tag);
            if(tag =="Player")
            {
                GetComponent<AudioManager>().PlayerDying();
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
            }
            gameObject.SetActive(false);

            Debug.Log(gameObject.name + " is dead");
            Destroy(gameObject);

        }
	}
   

    

    //Causes damage to the player. NOTE: AddHealth can also deal damage by applying negative health but this function has been created in order to increase clarity
    void AddDamage(float damage) {


		if (GetComponent<MovementComponent> ().FacingRight) {
			GetComponent<Rigidbody2D> ().AddForce (-transform.right * knockbackDistance);
			//GetComponent<Rigidbody2D> ().AddForce (transform.right * knockbackDistance);
			//GetComponent<Rigidbody2D> ().AddForce (Vector2.up * knockbackHeight);
		} else {
			GetComponent<Rigidbody2D> ().AddForce (transform.right * knockbackDistance);
			//GetComponent<Rigidbody2D> ().AddForce (transform.right * knockbackDistance);
			//GetComponent<Rigidbody2D> ().AddForce (Vector2.up * knockbackHeight);
		}


		if (shield <= 0.0001) {
            if(gameObject.tag=="Enemy")
            {
               
                gameObject.GetComponent<EnemyAudio>().PlayHurt();
            }
			health -= damage;
			Debug.Log (damage + " damage has been taken, current health is " + health);
			CheckHealth ();
		} else {
			shield -= damage;
			Debug.Log (damage + " shield damage has been taken, current health is " + health + " current shield is " + shield);
			if (shield < 0.0001) {
				shield = 0;
			}
		}

	}

	void AddShield (float shieldAdded) {
		shield += shieldAdded;
		Debug.Log ("Shield increased to " + shield);
	}
}