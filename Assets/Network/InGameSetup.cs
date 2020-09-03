using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSetup : MonoBehaviour
{
    public static InGameSetup inGS;

    public List<Transform> spawnPoints = new List<Transform>();

    private void OnEnable()
    {
        if (InGameSetup.inGS == null)
        {
            InGameSetup.inGS = this;
        }
    }
}
