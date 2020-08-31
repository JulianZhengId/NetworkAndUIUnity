using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Networking : MonoBehaviourPunCallbacks
{
    //private void roomInfo;
    public RoomInfo RoomInfo { get; private set; }
    [SerializeField] private Text _playerNameText;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
        print("Connecting To Server");
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected To Server as " + PhotonNetwork.LocalPlayer.NickName);
        _playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
        if (!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnect for reason " + cause.ToString());
    }
}
