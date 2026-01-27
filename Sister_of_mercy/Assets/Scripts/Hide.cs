using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Camera mainCamera;    // Главная камера
    public Camera secondCamera;  // Вторая камера
    private bool isInTrigger = false;

    void Start()
    {
        // Убедитесь, что вторая камера выключена при старте
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }

    void Update()
    {
        // Переключение камер по нажатию E, если игрок в триггере
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }
    }

    // Вызывается при входе в коллайдер
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Убедитесь, что у игрока тег "Player"
        {
            isInTrigger = true;
        }
    }

    // Вызывается при выходе из коллайдера
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

}
