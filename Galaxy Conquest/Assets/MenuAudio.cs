using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour {
    [SerializeField] private AudioSource MenuMusic;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        MenuMusic.volume = PlayerPrefs.GetFloat("Music", .5f);
    }
}
