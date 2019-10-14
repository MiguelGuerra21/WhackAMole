using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool juegoPausado;

    public GameObject pauseMenuUI;

    public AudioSource soundFx;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        soundFx.Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void Resume()
    {
        soundFx.UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }


    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(GameScenes.GameScene.ToString());
    }


    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(GameScenes.MainMenu.ToString());
    }

    
}
