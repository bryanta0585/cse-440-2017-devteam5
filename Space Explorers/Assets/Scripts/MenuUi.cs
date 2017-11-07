using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject exitMenu, mainMenu,settingsMenu;
    private void Awake()
    {
        
        exitMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void LoadFirstLevel()
    {
        Debug.Log("Loading First level");
        /*
        SceneManager.LoadScene(1);
        SceneManager.LoadScene("SceneName");
        */
    }
    public void SwitchLayout()
    {
        current.SetActive(false);
        newlayout.SetActive(true);
       
    }
    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
