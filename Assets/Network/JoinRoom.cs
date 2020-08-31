using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _roomNameText;
    [SerializeField] private Text _roomID;
    [SerializeField] private Canvas _inRoomCanvas;
    [SerializeField] private Canvas _mainMenuCanvas;
    public override void OnJoinedRoom()
    {
        _inRoomCanvas.gameObject.SetActive(true);
        _mainMenuCanvas.gameObject.SetActive(false);
        _roomID.text = "Room" + _roomNameText.text;
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom("Room " + _roomNameText.text);
    }
}
