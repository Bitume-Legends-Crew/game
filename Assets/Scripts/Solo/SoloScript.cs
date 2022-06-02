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

    public GameObject Easy_AI;
    public GameObject Medium_AI;
    public GameObject Hard_AI;
    
    
    
    private void Start()
    {
        Destroy(MusicHandler.musicObj[0]);
        Time.timeScale = 1f;
        AI_Activation();
        CountDown.CountDownTimer = 3;
        passedCheckpoint = 0;
        LastCheckpoint.PassedLastCheckpointPlayer = false;
        LastCheckpointIA.PassedLastCheckpointIA = false;
        
        // For Win
        TextWin.SetActive(false);
        BackGroundWin.SetActive(false);
        ButtonRetry.SetActive(false);
        ButtonMenu.SetActive(false);
        
        // For Loose
        TextLoose.SetActive(false);
        BackGroundLoose.SetActive(false);
        ButtonMenu.SetActive(false);
        ButtonRetry.SetActive(false);
        ButtonBack.SetActive(false);
        
    }

    public void AI_Activation()
    {
        if (SoloMenu.Difficulty == 1)
        {
            Easy_AI.SetActive(true);
            Medium_AI.SetActive(false);
            Hard_AI.SetActive(false);
        }
        
        if (SoloMenu.Difficulty == 2)
        {
            Easy_AI.SetActive(false);
            Medium_AI.SetActive(true);
            Hard_AI.SetActive(false);
        }
        
        if (SoloMenu.Difficulty == 3)
        {
            Easy_AI.SetActive(false);
            Medium_AI.SetActive(false);
            Hard_AI.SetActive(true);
        }
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
        switch (SoloMenu.Difficulty)
        {
            case 1:
                LevelSystem.instance.AddExperience(true,1f);
                break;
            case 2:
                LevelSystem.instance.AddExperience(true,1.5f);
                break;
            case 3:
                LevelSystem.instance.AddExperience(true,2f);
                break;
        }
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
        switch (SoloMenu.Difficulty)
        {
            case 1:
                LevelSystem.instance.AddExperience(false,1f);
                break;
            case 2:
                LevelSystem.instance.AddExperience(false,1.5f);
                break;
            case 3:
                LevelSystem.instance.AddExperience(false,2f);
                break;
        }
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
