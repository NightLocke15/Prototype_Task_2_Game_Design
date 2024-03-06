using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject MainMenu;

    public void PlayGame()
    {
        MainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        MainMenu.SetActive(true);
    }
}
