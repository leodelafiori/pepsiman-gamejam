using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour {

    public static bool Game_paused = false;
    public GameObject pause_menu_UI;
    public GameObject score_menu_UI;


    private void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update() {

  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Game_paused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }

    }

        public void Resume()
        {
        pause_menu_UI.SetActive(false);
        score_menu_UI.SetActive(true);
        Time.timeScale = 1f;
        Game_paused = false;
        }

        void Pause()
        {
        pause_menu_UI.SetActive(true);
        score_menu_UI.SetActive(false);
        Time.timeScale = 0f;
        Game_paused = true;

        }

        public void QuitGame()
    {
        Application.Quit();
    }

	
}
