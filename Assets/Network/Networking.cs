using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Networking : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text playerNameText;
    [SerializeField] private string _nickName = "Player";

    void Start()
    {
        PhotonNetwork.GameVersion = "0.0.0";
        SetPlayerName();
        PhotonNetwork.ConnectUsingSettings();
    }

    private void SetPlayerName()
    {
        int value = Random.Range(1000, 9999);
        PhotonNetwork.NickName = _nickName + value.ToString();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
        if (!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ReconnectAndRejoin();
    }
}
