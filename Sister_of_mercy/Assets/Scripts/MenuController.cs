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
    [SerializeField] private float timeToLimit = 15f;
    private float playTimer;
    private bool isPlaying = false;
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

        playTimer = 0f; // Сбрасываем таймер перед началом ролика
        isPlaying = true; // Только теперь запускаем отсчет
    }
    public void ExitGame()
    {
        // Эта строка сработает в скомпилированной игре (.exe)
        Application.Quit();

        // Эта строка нужна только для проверки в самом редакторе Unity
        // (так как в редакторе кнопка Quit сама по себе ничего не закроет)
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #endif

        Debug.Log("Игра закрыта");
    }

    private void Update()
    {
        if (isPlaying)
        {
            playTimer += Time.deltaTime;
            if (playTimer >= timeToLimit)
            {
                playTimer = 0f;
                Debug.Log("Пытаюсь загрузить сцену 1...");
                SceneManager.LoadScene(1);
            }
        }
    }
}