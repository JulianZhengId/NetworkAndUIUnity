using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField] Text playerInRoomText;
    private Player player;

    public Player Player
    {
        get
        {
            return player;
        }
    }

    public void SetPlayerInfo(Player player)
    {
        this.player = player;
        playerInRoomText.text = this.player.NickName;
    }
}
