using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip musicClip; // Перетащите сюда вашу музыку в инспекторе
    private AudioSource audioSource;

    void Start()
    {
        // Добавляем компонент AudioSource программно, если его нет
        audioSource = gameObject.AddComponent<AudioSource>();

        // Настраиваем источник
        audioSource.clip = musicClip;
        audioSource.loop = true;  // Вот эта строка включает зацикливание
        audioSource.playOnAwake = true; // Начинать играть сразу

        // Запускаем воспроизведение
        audioSource.Play();
    }
}
