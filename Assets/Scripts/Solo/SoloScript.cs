using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloScript : MonoBehaviour
{
    public static int passedCheckpoint;
    private float currentTime = 0f;
    public BoxCollider[] Checkpoint;
    public GameObject TextWin;
    public GameObject TextLoose;
    public GameObject BackGroundWin;
    public GameObject BackGroundLoose;
    public GameObject ButtonRetry;
    public GameObject ButtonMenu;
    public GameObject ButtonBack;
    
    
    private void Start()
    {
        CountDown.CountDownTimer = 3;
        passedCheckpoint = 0;
        Destroy(MusicHandler.musicObj[0]);
        LastCheckpoint.PassedLastCheckpointPlayer = false;
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Start();
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        Start();
    }
    
    public void BackMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        Start();
    }
    
    public void Win()
    {
        // timeAudio.Play();
        passedCheckpoint = 0;
        TextWin.SetActive(true);
        BackGroundWin.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Loose()
    {
        // timeAudio.Play();
        passedCheckpoint = 0;
        currentTime = 0;
        TextLoose.SetActive(true);
        BackGroundLoose.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        
        if (LastCheckpointIA.PassedLastCheckpointIA)
        {
            Loose();
            Time.timeScale = 0f;
        }
        
        if (passedCheckpoint >= Checkpoint.Length + 1 && LastCheckpoint.PassedLastCheckpointPlayer)
        {
            Win();
            Time.timeScale = 0f;
        }
    }
}
