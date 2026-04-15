using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Метод для вызова через код или UI Button
    public void LoadSceneById(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
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
