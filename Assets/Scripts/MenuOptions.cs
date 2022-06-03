using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }

    public GameObject panelOptions;
    public AudioMixer audioMixer;
    private Resolution[] _resolutions;
    public Dropdown resolutionDropdown;
    private float musicVolume;
    private float carsVolume;
    public Slider sliderMusic;
    public Slider sliderFX;

    private void Start()
    {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < _resolutions.Length; i++)
        {
            options.Add(_resolutions[i].width + "x" + _resolutions[i].height);

            if (_resolutions[i].width == Screen.currentResolution.width 
                && _resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        sliderMusic.value = SaveManager.instance.volumeMusic;
        sliderFX.value = SaveManager.instance.volumeCars;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu();
    }

    public void BackToMenu()
    {
        panelOptions.SetActive(false);
    }

    public void SetVolumeMusic()
    {
        //audioMixer.SetFloat("MusicVolume", volume);
        SaveManager.instance.volumeMusic = Mathf.Log10(sliderMusic.value) * 40;
    }
    public void SetVolumeCars()
    {
        //audioMixer.SetFloat("MusicVolume", volume);
        SaveManager.instance.volumeMusic = Mathf.Log10(sliderFX.value) * 40;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
