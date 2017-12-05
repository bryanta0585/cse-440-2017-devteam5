using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Button resumeBTN,mainMenuBtn;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject sound;
    [SerializeField]
    private Slider SoundSlider,MusicSlider;

    // Use this for initialization
    void Start () {
        pauseMenu.SetActive(false);
        resumeBTN.onClick.AddListener(Pause);
        mainMenuBtn.onClick.AddListener(ShowMain);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}
    void Pause()
    {
        if(!pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0;
            player.SetActive(false);
            pauseMenu.SetActive(true);
            sound.GetComponent<AudioManager>().Pause();
            SoundSlider.value = PlayerPrefs.GetFloat("Sound", .5f);
            SoundSlider.onValueChanged.AddListener(delegate { ChangeSound(); });
            MusicSlider.value = PlayerPrefs.GetFloat("Music", .5f);
            MusicSlider.onValueChanged.AddListener(delegate { ChangeSound(); });
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            player.SetActive(true);
            sound.GetComponent<AudioManager>().UnPause();
        }
       
    }
    void ChangeSound()
    {
      
        PlayerPrefs.SetFloat("Sound", SoundSlider.value);
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
        sound.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music", .5f);
    }
    void ShowMain()
    {

        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        player.SetActive(true);
        sound.GetComponent<AudioManager>().UnPause();
        SceneManager.LoadScene(0);
    }
}
