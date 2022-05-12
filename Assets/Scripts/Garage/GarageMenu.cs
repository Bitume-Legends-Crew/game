using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
            Back();
    }
}
