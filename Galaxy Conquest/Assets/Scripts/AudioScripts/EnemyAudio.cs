using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {
    [SerializeField] private AudioClip scream, hurt;
    [SerializeField]
    private AudioClip[] clips;
	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound");
            GetComponent<AudioSource>().PlayOneShot(scream);
        }

    }
    public void  PlayScream()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {

        }
        else
        {
            
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound");
            GetComponent<AudioSource>().PlayOneShot(scream);
        }
        
    }
    public void PlayHurt()
    {
        if(GetComponent<AudioSource>().isPlaying)
        {

        }
        else
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound")/3;
            GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0,clips.Length-1)]);
        }
    }
      
   
}
