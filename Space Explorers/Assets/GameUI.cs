using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour {
    [SerializeField]
    private Text healthText, shieldText, ammoText;
    [SerializeField]
    private Image currentGun;
    void SetCurrentGunImg(Image ng)
    {
        currentGun = ng;
    }
    void SetHealthText(string val)
    {
        healthText.text = val;
    }
    void SetShieldText(string val)
    {
        shieldText.text = val;
    }
    void SetAmmoText(string val)
    {
        ammoText.text = val;
    }
}
