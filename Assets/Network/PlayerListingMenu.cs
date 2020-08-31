using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _inRoomCanvas;
    Vector3 _content;

    [SerializeField] PlayerListing _playerListing;

    private List<PlayerListing> _listOfPlayers = new List<PlayerListing>();

    private List<Vector3> _playerListPositions = new List<Vector3>();

    private void Awake()
    {
        _playerListPositions.Add(new Vector3(100, 150, 0));
        _playerListPositions.Add(new Vector3(100, 50, 0));
        _playerListPositions.Add(new Vector3(100, -50, 0));
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {
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
        PlayerListing playerInList = Instantiate(_playerListing, SetContentTransform(), Quaternion.identity);
        playerInList.transform.SetParent(_inRoomCanvas.transform, false);
        if (playerInList != null)
        {
            playerInList.SetPlayerInfo(newPlayer);
            _listOfPlayers.Add(playerInList);
        }
    }
 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Process Lefted Player");
        int index = _listOfPlayers.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listOfPlayers[index].gameObject);
            _listOfPlayers.RemoveAt(index);
            Debug.Log("Process Lefted Player Success");
        }
    }

    public override void OnLeftRoom()
    {

    }

    private Vector3 SetContentTransform()
    {
        if (_playerListPositions.Contains(new Vector3(100, 150, 0)))
        {
            _content = new Vector3(100, 150, 0);
            _playerListPositions.Remove(_content);
        }
        else if (_playerListPositions.Contains(new Vector3(100, 50, 0)))
        {
            _content = new Vector3(100, 50, 0);
            _playerListPositions.Remove(_content);
        }
        else if (_playerListPositions.Contains(new Vector3(100, -50, 0)))
        {
            _content = new Vector3(100, -50, 0);
            _playerListPositions.Remove(_content);
        }
        else
        {
            _content = new Vector3(0, 0, 0);
        }
        Debug.Log(_content);
        return _content;
    }
}
