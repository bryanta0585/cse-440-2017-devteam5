using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudio : MonoBehaviour {
    [SerializeField]private AudioClip single, multiple, ammo;
    public void PlaySingle()
    {
        
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound", .5f);
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(single);
    }
    public void PlayMultiple()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound", .5f);
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(multiple);
    }
    public void PlayAmmo()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound", .5f);
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(ammo);

    }
  

}
