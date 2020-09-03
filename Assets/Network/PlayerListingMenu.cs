using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform playerListingMenuObject;
    [SerializeField] private Canvas inRoomCanvas;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private GameObject enterIdPanel;
    [SerializeField] PlayerListing playerListing;
    [SerializeField] GameObject playerCharacter;

    public List<PlayerListing> GetPlayerLists { get { return _listOfPlayers; } }

    private List<PlayerListing> _listOfPlayers = new List<PlayerListing>();

    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listOfPlayers.Count; i++)
        {
            Destroy(_listOfPlayers[i].gameObject);
        }
        _listOfPlayers.Clear();
    }   

    public void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected) return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null) return;
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    private void AddPlayerListing(Player newPlayer)
    {
        PlayerListing playerInList = Instantiate(playerListing, playerListingMenuObject);
        if (playerInList != null)
        {
            playerInList.SetPlayerInfo(newPlayer);
            _listOfPlayers.Add(playerInList);
        }
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        enterIdPanel.gameObject.SetActive(false);
        inRoomCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
        playerCharacter.SetActive(true);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Someone Left");
        int index = _listOfPlayers.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Debug.Log(_listOfPlayers[index].gameObject.name);
            Destroy(_listOfPlayers[index].gameObject);
            _listOfPlayers.RemoveAt(index);
        } else
        {
            foreach(PlayerListing listOfPlayer in _listOfPlayers)
            {
                Debug.Log(listOfPlayer.Player);
            }
        }
        Debug.Log(otherPlayer);
    }
}
