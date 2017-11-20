using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField]
    private AudioClip playerJumpUp, playerJumpDown, playerDying, playerWeaponHit, playerWalking;
    // Use this for initialization
    private void Start()
    {
        PlayerWalking();
    }
    void PlayerWalking()
    {
        AudioSource.PlayClipAtPoint(playerWalking, gameObject.transform.position);
    }
    void PlayerJumpUp()
    {
        AudioSource.PlayClipAtPoint(playerJumpUp, gameObject.transform.position);
    }
    void PlayerJumpDown()
    {
        AudioSource.PlayClipAtPoint(playerJumpDown, gameObject.transform.position);
    }
    void PlayerDying()
    {
        AudioSource.PlayClipAtPoint(playerDying, gameObject.transform.position);
    }
    void PlayerHit()
    {
        AudioSource.PlayClipAtPoint(playerWeaponHit, gameObject.transform.position);
    }

}
