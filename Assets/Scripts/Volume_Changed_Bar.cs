using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Changed_Bar : MonoBehaviour
{
    [Tooltip("音量調節のバー")]
    [SerializeField]
    Slider slider;

    [Tooltip("オーディオソース")]
    [SerializeField]
    AudioSource audioSource;

    void Awake()
    {
        slider.value = audioSource.volume;
    }

    void OnEnable()
    {
        slider.onValueChanged.AddListener((sliderValue) => audioSource.volume = sliderValue);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }


}
