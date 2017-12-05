using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    [SerializeField]
    private Button settings,play,quit,credits,rtn,quitYes,quitNo,rtn2,rtn3,rtn4,load;
    [SerializeField]
    private Slider musicSlider, soundSlider;
    [SerializeField]
    private GameObject settingsPanel, currentPanel,mainPanel, quitPanel,playPanel,creditsPanel;
    [SerializeField]
    private Button world1, world2;
    private int worldselected;
    [SerializeField]
    private Text loadText;

    // Use this for initialization
    void Start () {
        worldselected = 1;
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        quitPanel.SetActive(false);
        playPanel.SetActive(false);
        creditsPanel.SetActive(false);
        soundSlider.value = PlayerPrefs.GetFloat("Sound", .5f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", .5f);
        currentPanel = mainPanel;
        rtn4.onClick.AddListener(delegate { Show(mainPanel); });
        settings.onClick.AddListener(delegate { Show(settingsPanel); });
        rtn.onClick.AddListener(delegate { Show(mainPanel); });
        rtn2.onClick.AddListener(delegate { Show(mainPanel); });
        rtn3.onClick.AddListener(delegate { Show(mainPanel); });
        
        musicSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        soundSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        quitNo.onClick.AddListener(delegate { Show(mainPanel); });
        quitYes.onClick.AddListener(delegate { Quit(); });
        quit.onClick.AddListener(delegate { Show(quitPanel); });
        play.onClick.AddListener(delegate { Show(playPanel); });
        credits.onClick.AddListener(delegate { Show(creditsPanel); });
        world1.onClick.AddListener(delegate { SelectWorld(1); });
        world2.onClick.AddListener(delegate { SelectWorld(2); });
        load.onClick.AddListener(delegate { Play(); });
        
    }

    void Show(GameObject panelShow)
    {
      
        currentPanel.SetActive(false);
        panelShow.SetActive(true);
        currentPanel = panelShow;
        soundSlider.value = PlayerPrefs.GetFloat("Sound", .5f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", .5f);

    }
    void ChangeVolume()
    {
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
       
    }
    void Quit()
    {
        Application.Quit();
    }
    void Play()
    {
       
        SceneManager.LoadScene(worldselected);
    }
    void SelectWorld(int world)
    {
        worldselected = world;
        loadText.text = "Play World " + worldselected;
    }
   



}
