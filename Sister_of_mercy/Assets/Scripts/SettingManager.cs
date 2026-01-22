using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;           // Необходимо, если вы используете TextMeshProUGUI

public class SettingsManager : MonoBehaviour
{
    // Ссылки на UI элементы, которые нужно перетащить в Инспекторе
    public Slider sensitivitySlider;
    public TextMeshProUGUI sensitivityValueText; // Или public Text sensitivityValueText;

    // Ключ, по которому мы будем сохранять значение в PlayerPrefs
    private const string SensitivityKey = "MouseSensitivity";
    // Значение по умолчанию, если оно еще не сохранено
    private const float DefaultSensitivity = 100f;

    void Start()
    {
        // Загружаем сохраненное значение при старте меню
        LoadSensitivity();

        // Добавляем слушатель к ползунку: когда значение меняется, вызываем метод SaveSensitivityOnChange
        sensitivitySlider.onValueChanged.AddListener(SaveSensitivityOnChange);
    }

    private void LoadSensitivity()
    {
        // Получаем значение из PlayerPrefs. Если ключа нет, используем DefaultSensitivity
        float savedSensitivity = PlayerPrefs.GetFloat(SensitivityKey, DefaultSensitivity);

        // Устанавливаем ползунок в сохраненное положение
        sensitivitySlider.value = savedSensitivity;

        // Обновляем текст отображения
        UpdateSensitivityText(savedSensitivity);
    }

    // Этот метод вызывается UI Slider'ом автоматически при изменении значения
    public void SaveSensitivityOnChange(float newValue)
    {
        // Сохраняем новое значение в PlayerPrefs
        PlayerPrefs.SetFloat(SensitivityKey, newValue);
        // Принудительно сохраняем данные на диск
        PlayerPrefs.Save();

        // Обновляем текст отображения
        UpdateSensitivityText(newValue);
    }

    private void UpdateSensitivityText(float value)
    {
        if (sensitivityValueText != null)
        {
            // Округляем значение для красивого отображения (например, 100.5)
            sensitivityValueText.text = value.ToString("F1");
        }
    }
}