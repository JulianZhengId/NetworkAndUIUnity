using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView myPhotonView;
    public GameObject myCharacter;

    private void Awake()
    {
        myPhotonView = GetComponent<PhotonView>();
        int spawnIndex = Random.Range(0, InGameSetup.inGS.spawnPoints.Count);
        InGameSetup gameSetup = InGameSetup.inGS;
        if (myPhotonView.IsMine)
        {
            myCharacter = PhotonNetwork.Instantiate(Path.Combine("Player Avatar"), gameSetup.spawnPoints[spawnIndex].position, gameSetup.spawnPoints[spawnIndex].rotation, 0);
            gameSetup.spawnPoints.RemoveAt(spawnIndex);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
