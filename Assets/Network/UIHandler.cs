using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject enterIdPanel;
    public GameObject playerCharacter;

    public void PanelHandle(bool isActive)
    {
        if (enterIdPanel != null)
        {
            enterIdPanel.SetActive(isActive);
            playerCharacter.SetActive(!isActive);
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
