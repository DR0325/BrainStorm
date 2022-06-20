using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    //Audio

    public AudioMixer audioMixer;
    public Slider masterVolSlider;
    public Slider SFXVolSlider;
    public Slider musicVolSlider;

    //Resolution
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

        LoadValues();
        if(PlayerPrefs.GetString("FirstTime") == null || PlayerPrefs.GetString("FirstTime") != "No")
        {
            masterVolSlider.value = 1;
            SFXVolSlider.value = 1;
            musicVolSlider.value = 1;
        }
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Application.targetFrameRate = resolution.refreshRate;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SaveVolumeSettings()
    {
        float volumeVal = masterVolSlider.value;
        float sfxVal = SFXVolSlider.value;
        float musicVal = musicVolSlider.value;

        PlayerPrefs.SetFloat("VolumeValue", volumeVal);
        PlayerPrefs.SetFloat("SFXValue", sfxVal);
        PlayerPrefs.SetFloat("MusicValue", musicVal);
        PlayerPrefs.SetString("FirstTime", "No");

        LoadValues();
    }

    private void LoadValues()
    {
        float volumeVal = PlayerPrefs.GetFloat("VolumeValue");
        float sfxVal = PlayerPrefs.GetFloat("SFXValue");
        float musicVal = PlayerPrefs.GetFloat("MusicValue");

        masterVolSlider.value = volumeVal;
        audioMixer.SetFloat("Master", Mathf.Log10(volumeVal) * 20);

        SFXVolSlider.value = sfxVal;
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxVal) * 20);

        musicVolSlider.value = musicVal;
        audioMixer.SetFloat("Music", Mathf.Log10(musicVal) * 20);
    }
}
