using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;



    public void ShowMainMenu()
    {
        OptionsMenu.SetActive(false);
        if(MainMenu != null) MainMenu.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ShowOptions()
    {
        OptionsMenu.SetActive(true);
        if (MainMenu != null) MainMenu.SetActive(false);
    }

}
