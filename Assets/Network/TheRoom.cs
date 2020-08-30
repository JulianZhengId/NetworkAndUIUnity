using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRoom : MonoBehaviourPunCallbacks
{
    private List<TheRoom> _rooms = new List<TheRoom>();

    public RoomInfo RoomInfo { get; private set; }

           
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo room in roomList)
        {
            if (room.RemovedFromList)
            {
                int index = _rooms.FindIndex(x => x.RoomInfo.Name == room.Name);
                if (index != -1)
                {
                    _rooms.RemoveAt(index);
                }
            }
            else
            {
                Debug.Log("Max Players : " + room.MaxPlayers + ", " + room.Name);
                //_rooms.Add(room);
            }
        }
    }
}
