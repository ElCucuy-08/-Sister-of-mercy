using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Метод для вызова через код или UI Button
    public void LoadSceneById(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void QuitGame()
    {
        

        // Закрывает приложение (работает в скомпилированной игре)
        Application.Quit();

        // Останавливает режим воспроизведения (работает только в редакторе Unity)
       
    }
    // Пример: загрузка следующей сцены по порядку
    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Проверка, чтобы не выйти за пределы списка сцен
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
    }
}
