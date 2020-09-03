using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private string roomName;
    [SerializeField] private Text roomId;
    [SerializeField] private Canvas inRoomCanvas;
    [SerializeField] private Canvas mainMenuCanvas;
    public Text joinRoomText;
    float timer;

    public void ClickToCreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        int roomNumber = Random.Range(1, 10000000);
        roomName = "Room " + roomNumber;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        if (roomId != null)
        {
            roomId.text = roomName;
            inRoomCanvas.gameObject.SetActive(true);
            mainMenuCanvas.gameObject.SetActive(false);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        joinRoomText.text = "Room Not Found. Try Again";
        StartCoroutine(ChangeTextBack());
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        ClickToCreateRoom();
    }

    IEnumerator ChangeTextBack()
    {
        yield return new WaitForSeconds(2);
        joinRoomText.text = "Let The Input Empty To Join Randomly";
    }
}
