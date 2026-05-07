using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitels : MonoBehaviour
{
    public void LoadSceneById(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
