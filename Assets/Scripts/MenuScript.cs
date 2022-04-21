using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject garage;
    
    public void Timer()
    {
        SceneManager.LoadScene("Timer");
    }
    
    public void Multiplayer()
    {
        SceneManager.LoadScene("Lobby");
    }
    
    public void Soloplayer()
    {
        SceneManager.LoadScene("Solo");
    }
    
    public void Garage()
    {
        SceneManager.LoadScene("Garage");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void BugReport()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdtMqQPdZ3fohHimmtKlI6b1E8ZpBkLsoX8qXae7XPpkvpLcQ/viewform?usp=pp_url");
    }
}