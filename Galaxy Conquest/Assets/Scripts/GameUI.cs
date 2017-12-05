using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour {
    [SerializeField]
	private Text healthText, shieldText, ammoText, pickupText, jetpackText;
	[SerializeField] private Image jetpackMeter;
    [SerializeField] private Sprite currentGun,rifle,pistol, shotgun,rocketLauncher;
    [SerializeField]
    private GameObject displayImg;
    [SerializeField]
    private GameObject player;
  
    void Update()
    {
        SetPickupText(player.GetComponent<PointsComponent>().Points.ToString());
        SetAmmoText(player.GetComponent<WeaponSwitcher>().CurrentAmmo.ToString());
        SetHealthText(player.GetComponent<HealthComponent>().Health.ToString());
        SetShieldText(player.GetComponent<HealthComponent>().Shield.ToString());
		//SetJetpackText(player.GetComponent<JetpackComponent>().JetpackGuage.ToString());
		SetJetpackMeter(player.GetComponent<JetpackComponent>().JetpackGuage, player.GetComponent<JetpackComponent>().JetpackGuageMax);
        SetCurrentGunImg(player.GetComponent<WeaponSwitcher>().CurrentWeapon);
    }
    void SetCurrentGunImg(string name)
    {
        if(name=="Rifle")
        {
            currentGun = rifle;
        }
        else if(name=="Pistol"){
            currentGun = pistol;
        }
        else if (name == "RocketLauncher")
        {
            currentGun = rocketLauncher;
        }
        else if (name == "Shotgun")
        {
            currentGun = shotgun;
        }
        else
        {
            Debug.Log("not found" + name);
        }
        displayImg.GetComponent<Image>().sprite = currentGun;

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
    void SetPickupText(string val)
    {
		pickupText.text = val;
    }
	void SetJetpackText(string val)
	{
		jetpackText.text = val.Substring(0,4);
	}
	void SetJetpackMeter(float current, float max)
	{
		jetpackMeter.fillAmount = current / max;
		if (current / max <= 0.3) {
			jetpackMeter.CrossFadeColor (Color.red, 0.3f, false, false);
		} else if (current / max <= 0.6) {
			jetpackMeter.CrossFadeColor (Color.yellow, 0.3f, false, false);
		} else if (current / max > 0.6) {
			jetpackMeter.CrossFadeColor (Color.green, 0.3f, false, false);
		}
	}
  
}
