using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //public static LevelSelect instance;
    public GameObject diffMenu;
    public GameObject loadingScreen;

    private void Awake()
    {
        

        
    }

    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void DifficultySettings()
    {
        diffMenu.SetActive(true);
    }
    
}
