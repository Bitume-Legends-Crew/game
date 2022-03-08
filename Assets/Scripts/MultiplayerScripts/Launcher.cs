using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    public InputField createInput;
    public InputField joinInput;
    public Text errorText;
    public Text roomNameText;
    public InputField playerNickname;
    public Transform roomListContent;
    public Transform playerListContent;
    public GameObject roomListItemPrefab;
    public GameObject playerListItemPrefab;
    public GameObject startGameButton;
    public GameObject noStartGameButton;

    private bool _submited = false;

    private void Awake()
    {
        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        // This function connect the game at the server
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("eu");
    }

    public override void OnConnectedToMaster()
    {
        // This function is called when the game is connected
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected !!");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}",
            cause);
    }

    public override void OnJoinedLobby()
    {
        // This function is called to call the lobby scene (the page of connection)
        MultiplayerMenuManager.Instance.OpenMenu("Background");
        MultiplayerMenuManager.Instance.OpenMenu("Main");
    }

    public void CreateRoom()
    {
        // Remove the if statement if you would create a room without name
        if (string.IsNullOrEmpty(createInput.text))
        {
            Debug.LogWarning("Must assign a name to create room");
            return;
        }

        PhotonNetwork.CreateRoom(createInput.text.ToUpper());
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(joinInput.text))
        {
            return;
        }

        PhotonNetwork.JoinRoom(joinInput.text.ToUpper());
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        // ToUpper ??
        PhotonNetwork.JoinRoom(info.Name);
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        MultiplayerMenuManager.Instance.OpenMenu("RoomMenu");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>()
                .SetUp(player);
        }

        if (!_submited)
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000).ToString("0000");
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        noStartGameButton.SetActive(!PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed :\n" + message;
        MultiplayerMenuManager.Instance.OpenMenu("ErrorMenu");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Joining Failed :\n" + message;
        MultiplayerMenuManager.Instance.OpenMenu("ErrorMenu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    // public override void OnLeftRoom()
    // {
    //     MultiplayerMenuManager.Instance.OpenMenu("Main");
    // }

    public void NicknameSubmit()
    {
        PhotonNetwork.NickName = playerNickname.text.ToUpper();
        _submited = true;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        foreach (var room in roomList)
        {
            if (room.RemovedFromList)
            {
                continue;
            }

            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(room);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("New Player on room : {0}", newPlayer.NickName);
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
        int i = 0;
        foreach (var pl in PhotonNetwork.PlayerList)
        {
            pl.ActorNumber = i;
        }
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Scene1");
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        noStartGameButton.SetActive(!PhotonNetwork.IsMasterClient);
    }
}