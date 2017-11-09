using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour {
    /* 
     * TODO: Change to private and instantiate;
     *
     */

    // Use this for initialization
    [SerializeField]
    private GameObject exitMenu, mainMenu,settingsMenu;
    private void Awake()
    {
        if(exitMenu.activeInHierarchy) exitMenu.SetActive(false);
        if(settingsMenu.activeInHierarchy) settingsMenu.SetActive(false);
        if(!mainMenu.activeInHierarchy) mainMenu.SetActive(true);
    
    }

    public void LoadFirstLevel()
    {
        Debug.Log("Loading First level");
        
        SceneManager.LoadScene(1);
        /*
        SceneManager.LoadScene("SceneName");
        */
    }
    public void ShowLayout(string layout)
    {  
        if(exitMenu.name ==layout)
        {
            exitMenu.SetActive(true);
        }
        else if(mainMenu.name == layout)
        {
            mainMenu.SetActive(true);
        }
        else if(settingsMenu.name == layout)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            return;
        }
    }
    public void HideLayout(string layout)
    {
        if (exitMenu.name == layout)
        {
            exitMenu.SetActive(false);
        }
        else if (mainMenu.name == layout)
        {
            mainMenu.SetActive(false);
        }
        else if (settingsMenu.name == layout)
        {
            settingsMenu.SetActive(false);
        }
        else
        {
            return;
        }
    }
    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
