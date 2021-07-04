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


    void Start()
    {

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
}
