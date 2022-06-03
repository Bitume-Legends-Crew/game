using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject[] musicObj;
    public void Awake()
    {
        musicObj = GameObject.FindGameObjectsWithTag("MusicMenu");
        if (musicObj.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
