using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float delayForSound = 100f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void PlayGame()
    {
        while (delayForSound > 0)
        {
        
            delayForSound -= Time.deltaTime;
        }
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        while (delayForSound > 0)
        {
            delayForSound -= Time.deltaTime;
        }
        Application.Quit();
    }
}
