using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    private Canvases _canvases;

    public void FirstInitialize(Canvases canvases)
    {
        _canvases = canvases;
    }

    public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }

    public void HideCanvas()
    {
        gameObject.SetActive(false);
    }
}
