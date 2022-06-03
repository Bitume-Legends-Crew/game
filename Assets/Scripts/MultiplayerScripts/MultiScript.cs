using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiScript : MonoBehaviour
{
    public static int passedCheckpoint;
    public BoxCollider[] Checkpoint;
    // public AudioSource timeAudio;
    // public GameObject Car;

    public GameObject TextWin;
    public GameObject TextLoose;
    public GameObject BackGroundWin;
    public GameObject BackGroundLoose;
    public GameObject ButtonRetry;
    public GameObject ButtonMenu;
    public GameObject ButtonBack;

    public GameObject[] player;
    
    private void Start()
    {
        
        player = GameObject.FindGameObjectsWithTag("Vehicle");
        if (PhotonNetwork.CurrentRoom.Players.Count == player.Length)
        {
            CountDown.CountDownTimer = 5;
            passedCheckpoint = 0;
            Destroy(MusicHandler.musicObj[0]);
            LastCheckpoint.PassedLastCheckpointPlayer = false;
            LastCheckpoint.PassedLastCheckpointPlayer = false;
        }
        
    }

    public void Menu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
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
        LevelSystem.instance.AddExperience(true,2f);
        
        //XP EARNING
    }

    public void Loose()
    {
        // timeAudio.Play();
        passedCheckpoint = 0;
        TextLoose.SetActive(true);
        BackGroundLoose.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
        LevelSystem.instance.AddExperience(false,2f);
        
        //XP EARNING
    }

    

    private void Update()
    {
        if (PhotonNetwork.CurrentRoom.Players.Count != player.Length) // If not every players have join the game
        {
            Start();
        }
        
        if (CountDown.CountDownTimer == 0)
        {
            Debug.Log(passedCheckpoint);

            if (LastCheckpoint.PassedLastCheckpointPlayer && passedCheckpoint == Checkpoint.Length)
            {
                Win();
            }

        }
    }
}
