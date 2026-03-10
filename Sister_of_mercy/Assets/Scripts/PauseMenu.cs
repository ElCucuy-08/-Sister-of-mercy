using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool isPaused = false;

    void Update()
    {
        // Проверяем нажатие Esc или кнопки Escape на Android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Back(int indexscene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(indexscene);
    }
}
