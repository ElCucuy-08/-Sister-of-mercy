using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticTriggerScreamer : MonoBehaviour
{
    [Header("Настройки преследования")]
    public Transform player;         // Объект игрока
    public float detectionRange = 10f; // Дистанция, с которой он заметит игрока
    public float flySpeed = 15f;      // Скорость полета

    [Header("Настройки скримера")]
    public Image screamImage;        // Картинка UI
    public AudioSource screamSound;  // Звук
    public float fadeSpeed = 0.8f;   // Скорость исчезновения (чем меньше, тем медленнее)

    private bool isFlying = false;
    private bool isTriggered = false;

    void Update()
    {
        if (isTriggered) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // 1. Проверяем, увидел ли объект игрока
        if (distance <= detectionRange && !isFlying)
        {
            isFlying = true;
        }

        // 2. Если увидел — летим прямо на него
        if (isFlying)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, flySpeed * Time.deltaTime);
            transform.LookAt(player); // Всегда поворачивается лицом к игроку при полете
        }
    }

    // 3. Срабатывает при столкновении с игроком
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            StartCoroutine(ShowScreamer());
        }
    }

    IEnumerator ShowScreamer()
    {
        isTriggered = true;
        isFlying = false;

        // Включаем картинку и звук
        screamImage.gameObject.SetActive(true);
        SetAlpha(1f);
        if (screamSound) screamSound.Play();

        // Небольшая пауза, когда картинка на пике яркости
        yield return new WaitForSeconds(0.5f);

        // Плавное затухание
        float currentAlpha = 1f;
        while (currentAlpha > 0)
        {
            currentAlpha -= Time.deltaTime * fadeSpeed;
            SetAlpha(currentAlpha);
            yield return null;
        }

        screamImage.gameObject.SetActive(false);
        Destroy(gameObject); // Удаляем монстра после испуга
    }

    void SetAlpha(float a)
    {
        Color c = screamImage.color;
        c.a = a;
        screamImage.color = c;
    }
}