using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsMenu : MonoBehaviourPunCallbacks
{
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        Debug.Log("Max Players : " + roomInfo.MaxPlayers + ", " + roomInfo.Name);
    }

}
