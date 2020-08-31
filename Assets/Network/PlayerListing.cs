using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField] Text playerInRoomText;
    private Player _player;

    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        _player = player;
        playerInRoomText.text = _player.NickName;
    }
}
