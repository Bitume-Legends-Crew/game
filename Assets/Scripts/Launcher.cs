using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void Awake()
    {
        Instance = this;
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

    public override void OnJoinedLobby()
    {
        // This function is called to call the lobby scene (the page of connection)
        // SceneManager.LoadScene("Lobby");
        MultiplayerMenuManager.Instance.OpenMenu("Background");
        MultiplayerMenuManager.Instance.OpenMenu("Main");
    }

    public void CreateRoom()
    {
        // Remove the if statement if you would create a room without name
        if (string.IsNullOrEmpty(createInput.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(createInput.text);
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(joinInput.text))
        {
            return;
        }

        PhotonNetwork.JoinRoom(joinInput.text);
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        // PhotonNetwork.LoadLevel("Scene1");
        MultiplayerMenuManager.Instance.OpenMenu("RoomMenu");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed : " + message;
        MultiplayerMenuManager.Instance.OpenMenu("ErrorMenu");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Joining Failed : " + message;
        MultiplayerMenuManager.Instance.OpenMenu("ErrorMenu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MultiplayerMenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MultiplayerMenuManager.Instance.OpenMenu("Main");
    }

    public void NicknameSubmit()
    {
        PhotonNetwork.NickName = playerNickname.text;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        foreach (var room in roomList)
        {
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(room);
        }
    }
}