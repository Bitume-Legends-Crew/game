using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicVolumeHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mixer;
    /*
    private void Start()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 40);
    }*/

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("MusicVolume", SaveManager.instance.volumeMusic );
        SaveManager.instance.Save();
    }
}
