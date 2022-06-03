using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        int currResIndx = 0; 
        List<string> resOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resOption = resolutions[i].width + " x " + resolutions[i].height + ", " + resolutions[i].refreshRate + "Hz";

            resOptions.Add(resOption);
            
            
            if(resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currResIndx = i;
            }
        }

        resDropdown.AddOptions(resOptions);
        resDropdown.value = currResIndx;
        resDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Application.targetFrameRate = resolution.refreshRate;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
