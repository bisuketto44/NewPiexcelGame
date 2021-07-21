using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeep : MonoBehaviour
{
    private float InGamePassedTime;
    private float oldTime;

    private int _hour = 0;
    private int _minute = 0;

    [SerializeField]
    private Text TimeText;

    [SerializeField]
    private Slider SE;
    [SerializeField]
    private Slider BGM;

    [SerializeField]
    private AudioSource audioSourceSE;

    [SerializeField]
    private AudioSource audioSourceBGM;

    void Start()
    {
        SaveData_UserSettings.Instance.Reload();
        if (SaveData_UserSettings.Instance.isdata == true)
        {
            InGamePassedTime = SaveData_UserSettings.Instance.InGamePassedTime;
            oldTime = SaveData_UserSettings.Instance.oldTime;
            _minute = SaveData_UserSettings.Instance.minute;
            _hour = SaveData_UserSettings.Instance.hour;

            //音量の再設定
            SE.value = SaveData_UserSettings.Instance.SEfloat;
            BGM.value = SaveData_UserSettings.Instance.BGMfloat;
            audioSourceSE.volume = SaveData_UserSettings.Instance.SEfloat;
            audioSourceBGM.volume = (SaveData_UserSettings.Instance.BGMfloat / 10);
        }


    }

    void Update()
    {
        InGamePassedTime += Time.deltaTime;

        if (InGamePassedTime != oldTime)
        {

            TimeText.text = _hour.ToString() + " : " + _minute.ToString("00") + " : " + ((int)InGamePassedTime).ToString("00");

            if (InGamePassedTime >= 60f)
            {
                InGamePassedTime -= 60f;
                //分に追加
                _minute++;
            }
        }

        //60分を超えたらリセット
        if (_minute >= 60)
        {
            _minute = 0;
            _hour++;
        }

    }

    void OnApplicationQuit()
    {
        SaveData_UserSettings.Instance.minute = _minute;
        SaveData_UserSettings.Instance.hour = _hour;
        SaveData_UserSettings.Instance.oldTime = oldTime;
        SaveData_UserSettings.Instance.InGamePassedTime = InGamePassedTime;
        SaveData_UserSettings.Instance.isdata = true;
        SaveData_UserSettings.Instance.Save();
    }
}
