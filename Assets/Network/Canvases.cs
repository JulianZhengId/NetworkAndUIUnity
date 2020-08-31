using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvases : MonoBehaviour
{
    //Main Menu Canvas
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    public MainMenuCanvas MainMenuCanvas { get { return _mainMenuCanvas; } }

    //In Room Canvas
    [SerializeField] private InRoomCanvas _inRoomCanvas;
    public InRoomCanvas InRoomCanvas { get { return _inRoomCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        MainMenuCanvas.FirstInitialize(this);
        InRoomCanvas.FirstInitialize(this);
    }
}
