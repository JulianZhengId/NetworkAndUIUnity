using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _roomName;

    [SerializeField] private Text _roomID;

    [SerializeField] private Canvas _inRoomCanvas;
    [SerializeField] private Canvas _mainMenuCanvas;

    public void ClickToCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;
        int roomNumber = Random.Range(1, 10000000);
        _roomName = "Room " + roomNumber;
        PhotonNetwork.JoinOrCreateRoom(_roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        if (_roomID != null)
        {
            _roomID.text = _roomName;
            _inRoomCanvas.gameObject.SetActive(true);
            _mainMenuCanvas.gameObject.SetActive(false);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Fail to Create Room");
    }
}
