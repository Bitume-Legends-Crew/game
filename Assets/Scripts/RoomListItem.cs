using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    public Text text;

    private RoomInfo info;
    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
        // Add the infos.player count / max players
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
