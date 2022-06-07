using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiScript : MonoBehaviour
{
    public static int passedCheckpoint;
    public BoxCollider[] Checkpoint;
    public bool finished = false;
    // public AudioSource timeAudio;
    // public GameObject Car;

    public GameObject TextWin;
    public GameObject TextLoose;
    public GameObject BackGroundWin;
    public GameObject BackGroundLoose;
    public GameObject ButtonRetry;
    public GameObject ButtonMenu;
    public GameObject ButtonBack;

    private void Start()
    {
        CountDown.CountDownTimer = 5;
        passedCheckpoint = 0;
        Destroy(MusicHandler.musicObj[0]);
        LastCheckpointMulti.PassedLastCheckpointPlayer = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        Start();
    }
    
    public void Win(PhotonView view)
    {
        // timeAudio.Play()
        finished = true;
        Debug.Log("WIN");
        Debug.Log(view.ToString());
        view.RPC("Loose()", RpcTarget.Others, "view");
        passedCheckpoint = 0;
        TextWin.SetActive(true);
        BackGroundWin.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
        LevelSystem.instance.AddExperience(true,2f);
    }

    [PunRPC]
    public void Loose(PhotonView view)
    {
       finished = true;
        // timeAudio.Play();
        passedCheckpoint = 0;
        TextLoose.SetActive(true);
        BackGroundLoose.SetActive(true);
        ButtonRetry.SetActive(true);
        ButtonMenu.SetActive(true);
        ButtonBack.SetActive(false);
        Time.timeScale = 0f;
        LevelSystem.instance.AddExperience(false, 2f);
    }

    
    private void Update()
    {
        if (finished)
            return;

        if (LastCheckpointMulti.PassedLastCheckpointPlayer &&  passedCheckpoint >= 5)
        {
            if (LastCheckpointMulti.pv.IsMine)
                    Win(LastCheckpointMulti.pv);
            else
            {
                Loose(LastCheckpointMulti.pv);
            }
        }
    }
}

