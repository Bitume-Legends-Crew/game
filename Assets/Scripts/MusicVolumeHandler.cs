using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MusicVolumeHandler : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    // Start is called before the first frame update
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("MusicVolume", SaveManager.instance.volumeMusic);
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 40);
        VolumeSave.SetVolumeMusic(Mathf.Log10(musicSlider.value) * 40);
    }
}
