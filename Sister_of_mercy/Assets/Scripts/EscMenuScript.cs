using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Ссылка на объект панели меню в Canvas
    public GameObject menuPanel;

    // Флаг для отслеживания состояния игры
    private bool isPaused = false;

    void Update()
    {
        // Проверяем нажатие клавиши Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Метод для закрытия меню и продолжения игры
    public void Resume()
    {
        menuPanel.SetActive(false);     // Скрываем панель меню
        Time.timeScale = 1f;            // Запускаем игровое время
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked; // Скрываем курсор (опционально)
        Cursor.visible = false;
    }

    // Метод для открытия меню и приостановки игры
    void Pause()
    {
        menuPanel.SetActive(true);      // Показываем панель меню
        Time.timeScale = 0f;            // Замораживаем игровое время
        isPaused = true;

        Cursor.lockState = CursorLockMode.None; // Освобождаем курсор
        Cursor.visible = true;                  // Делаем курсор видимым
    }
}
