using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform playerListingMenuObject;
    [SerializeField] private Canvas inRoomCanvas;
    [SerializeField] private Canvas mainMeniCanvas;
    [SerializeField] private Text roomNameText;
    [SerializeField] private Text roomId;

    public override void OnJoinedRoom()
    {
        Debug.Log("JoinRoom");
        inRoomCanvas.gameObject.SetActive(true);
        mainMeniCanvas.gameObject.SetActive(false);
        if (roomNameText.text == "")
        {
            roomId.text = PhotonNetwork.CurrentRoom.Name;
        }
        else
        {
            roomId.text = "Room " + roomNameText.text;
        }   
    }

    public void OnClickJoinRoom()
    {
        if (roomNameText.text != "")
        {
            PhotonNetwork.JoinRoom("Room " + roomNameText.text);
        }
        else  
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");
        playerListingMenuObject.DestroyChildren();
    }
}
