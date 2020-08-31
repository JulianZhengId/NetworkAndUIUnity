using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject _enterIdPanel;

    public void PanelHandle(bool isActive)
    {
        if (_enterIdPanel != null)
        {
            _enterIdPanel.SetActive(isActive);
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
