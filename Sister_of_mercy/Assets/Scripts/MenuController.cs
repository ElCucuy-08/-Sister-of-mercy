using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Обязательно добавьте это пространство имен для работы с UI

public class MenuController : MonoBehaviour
{
    public GameObject MainMenuSetting;
    public GameObject MainMenuCredits;
    public GameObject MainMenu;

    public void SettingsON()
    {
        MainMenu.SetActive(false);
        MainMenuSetting.SetActive(true);
    }
    public void SettingsOFF()
    {
        MainMenu.SetActive(true);
        MainMenuSetting.SetActive(false);
    }
    public void CreditsON()
    {
        MainMenu.SetActive(false);
        MainMenuCredits.SetActive(true);
    }
    public void CreditsOFF()
    {
        MainMenu.SetActive(true);
        MainMenuCredits.SetActive(false);
    }
}