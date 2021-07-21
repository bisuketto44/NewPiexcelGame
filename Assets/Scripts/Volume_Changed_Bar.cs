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
        if (SaveData_UserSettings.Instance.isdata == true)
        {
            return;
        }

        if (this.gameObject.tag == "BGM")
        {
            slider.value = audioSource.volume * 10;
            return;
        }
        slider.value = audioSource.volume;
    }

    void Update()
    {
        if (this.gameObject.tag == "BGM" && this.gameObject.activeSelf == true)
        {
            audioSource.volume = (slider.value / 10);
        }
    }

    void OnEnable()
    {
        if (this.gameObject.tag == "BGM")
        {
            return;
        }
        slider.onValueChanged.AddListener((sliderValue) => audioSource.volume = sliderValue);

    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
        if (this.gameObject.tag == "BGM")
        {
            SaveData_UserSettings.Instance.BGMfloat = this.slider.value;

        }
        else
        {
            SaveData_UserSettings.Instance.SEfloat = this.slider.value;
        }

        SaveData_UserSettings.Instance.Save();
    }


}
