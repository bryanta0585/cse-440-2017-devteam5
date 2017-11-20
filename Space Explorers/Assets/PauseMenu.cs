using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Button resumeBTN;
	// Use this for initialization
	void Start () {
        resumeBTN.onClick.AddListener(Pause);
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
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
       
    }
}
