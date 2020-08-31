using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    [SerializeField] private Canvas _inRoomCanvas;
    [SerializeField] private Canvas _mainMenuCanvas;
    
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
    }
}
