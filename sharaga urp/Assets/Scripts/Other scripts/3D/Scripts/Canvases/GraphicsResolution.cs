// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Linq;


// public class GraphicsResolution : MonoBehaviour
// {
//     public Dropdown resolutionDropdown;
//     public Dropdown qualityDropdown;
//     public Dropdown windowModeDropdown;

//     void Start()
//     {
//         // Заполняем список вариантами разрешений
//         List<string> resolutionOptions = new List<string>();
//         resolutionOptions.Add("3840x2160");
//         resolutionOptions.Add("2560x1440");
//         resolutionOptions.Add("1920x1080");
//         resolutionOptions.Add("1600x900");
//         resolutionOptions.Add("1366x768");
//         resolutionOptions.Add("1280x720");
//         resolutionDropdown.AddOptions(resolutionOptions);

//         // Заполняем список вариантами качества
//         qualityDropdown = GetComponent<Dropdown>();


//         // Заполняем список вариантами качества из настроек качества игры
//         List<string> qualityOptions = new List<string>(QualitySettings.names);
//         qualityDropdown.AddOptions(qualityOptions);

//         // Устанавливаем выбранный пункт для Dropdown на основе текущей настройки качества игры
//         qualityDropdown.value = QualitySettings.GetQualityLevel();

//         // Связываем Dropdown с функцией изменения разрешения
//         resolutionDropdown.onValueChanged.AddListener(delegate { ResolutionChanged(resolutionDropdown); });

//         // Связываем Dropdown с функцией изменения качества
//         qualityDropdown.onValueChanged.AddListener(delegate { QualityChanged(qualityDropdown); });
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     public void ResolutionChanged(Dropdown change)
//     {
//         // Получаем выбранное разрешение из Dropdown
//         string selectedResolution = change.options[change.value].text;

//         // Разделяем выбранное разрешение на ширину и высоту
//         string[] resolutionParts = selectedResolution.Split('x');
//         int width = int.Parse(resolutionParts[0]);
//         int height = int.Parse(resolutionParts[1]);

//         // Изменяем разрешение экрана
//         Screen.SetResolution(width, height, Screen.fullScreen);
//     }

//      void QualityChanged(Dropdown change)
//     {
//         // Получаем выбранную настройку качества из Dropdown
//         string selectedQuality = change.options[change.value].text;

//         // Устанавливаем выбранную настройку качества в игре
//         QualitySettings.SetQualityLevel(change.value);
//     }

// }


