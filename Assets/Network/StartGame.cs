using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static StartGame roomController;
    public PhotonView PV;
    public int gameSceneIndex = 1;
    public int currentSceneIndex;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        if (StartGame.roomController == null)
        {
            StartGame.roomController = this;
        } else
        {
            if (StartGame.roomController != this)
            {
                Destroy(StartGame.roomController.gameObject);
                StartGame.roomController = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode loadSceneMode)
    {
        currentSceneIndex = scene.buildIndex;
        if (currentSceneIndex == gameSceneIndex)
        {
            Debug.Log("Scene Laoded");
            CreateAsset();
        }
        else
        {
            Debug.Log("Scene Not Loaded");
        }
    }

    private void CreateAsset()
    {
        GameObject ya = PhotonNetwork.Instantiate(Path.Combine("Photon Player"), transform.position, Quaternion.identity, 0);
        Debug.Log(ya.name);
    }

    public void ClickToStartGame()
    {
        StartTheGame();
    }

    private void StartTheGame()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;    
        PhotonNetwork.LoadLevel(gameSceneIndex);
    }

/*    public void DisconnectPlayer()
    {
        StartCoroutine(DisconnectAndLoadMainMenu());
    }

    IEnumerator DisconnectAndLoadMainMenu()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.InRoom) yield return null;
        SceneManager.LoadScene(0);
    }*/


}
