using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
  
  
    [SerializeField]
    private AudioClip playerJumpUp, playerJumpDown, playerDying, playerWeaponHit, playerWalking;
    [SerializeField]
    private AudioSource src;
 
    // Use this for initialization
    public void Pause()
    {
        src.Pause();
    }
    public void UnPause()
    {
        src.UnPause();
    }
    private void Update()
    {
            src.volume = PlayerPrefs.GetFloat("Music", .5f);
        
    }
    public void PlayerJumpUp()
    {
         src.PlayOneShot(playerJumpUp, PlayerPrefs.GetFloat("Sound", .5f));
    }
     void PlayerJumpDown()
    {
        src.PlayOneShot(playerJumpDown, PlayerPrefs.GetFloat("Sound", .5f));
    }
    public void PlayerDying()
    {
        src.PlayOneShot(playerDying, PlayerPrefs.GetFloat("Sound", .5f));
    }
    void PlayerHit()
    {
        src.PlayOneShot(playerJumpUp, PlayerPrefs.GetFloat("Sound", .5f));
    }
   
}
