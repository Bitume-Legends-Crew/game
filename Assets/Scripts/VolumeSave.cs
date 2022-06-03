using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSave : MonoBehaviour
{
    // Start is called before the first frame update
    public static float volumeMusic { get; set; }
    public float volumeCars{ get; set; }
    
    //FIXME
    public static void SetVolumeMusic(float volume)
    {
        volumeMusic = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
