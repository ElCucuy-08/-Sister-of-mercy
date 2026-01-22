using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Обязательно добавьте это пространство имен для работы с UI

public class MenuController : MonoBehaviour
{
    public GameObject MainMenuSetting;
    public GameObject MainMenuCredits;
    public GameObject MainMenuPlay;
    public GameObject MainMenu;
    public GameObject Background;
    float playTimer = 0f;
    bool isPlaying = false;
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

    public void PlayButton()
    {
        Background.SetActive(false);
        MainMenuPlay.SetActive(true);
        isPlaying = true;
    }
    private void Update()
    {
        if (isPlaying) 
        {
            playTimer += Time.deltaTime;
            if(playTimer >= 15f)
            {
                playTimer = 0f;
                SceneManager.LoadScene(1);

            }
        }
    }
}