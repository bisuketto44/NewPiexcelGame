using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Number : MonoBehaviour
{
    private Live_Attribute_Window _closedJunle; // Genre inactivate
    private Live_Attribute_Window _closedStayle; //Style inactivate
    private Live_Attribute_Window _closedTime;
    private Live_Attribute_Window _closedMotivation;

    private Text _JunleText; // JunleText of main display(Below are similar roles)
    private Text _styleText;
    private Text _timeText;
    private Text _motivationText;

    //if junlebtn is pushed , this method is activate
    public void JunleBtnActivate()
    {
        _closedJunle = GameObject.Find("Junle_Mask").GetComponent<Live_Attribute_Window>();
        _JunleText = GameObject.Find("JunleText").GetComponent<Text>();

        //各ボタンにこのスクリプトを付与(ボタンの子オブジェのテキスト内容を取り出し、メイン画面に付与)
        Text t1 = transform.GetChild(0).gameObject.GetComponent<Text>();
        _JunleText.text = t1.text;

        //Inactivate JunleMask
        if (_closedJunle != null)
        {
            _closedJunle.InActivateWindow();
        }

    }

    public void StyleBtnActivate()
    {
        _closedStayle = GameObject.Find("Style_Mask").GetComponent<Live_Attribute_Window>();
        _styleText = GameObject.Find("StyleText").GetComponent<Text>();

        Text t2 = transform.GetChild(0).gameObject.GetComponent<Text>();
        _styleText.text = t2.text;

        if (_closedStayle != null)
        {
            _closedStayle.InActivateWindow();
        }

    }

    public void TimeBtnActivate()
    {
        _closedTime = GameObject.Find("Time_Mask").GetComponent<Live_Attribute_Window>();
        _timeText = GameObject.Find("TimeText").GetComponent<Text>();

        Text t3 = transform.GetChild(0).gameObject.GetComponent<Text>();
        _timeText.text = t3.text;

        if (_closedTime != null)
        {
            _closedTime.InActivateWindow();
        }


    }

    public void MotivationBtnActivate()
    {
        _closedMotivation = GameObject.Find("Motivation_Mask").GetComponent<Live_Attribute_Window>();
        _motivationText = GameObject.Find("MotivationText").GetComponent<Text>();

        Text t4 = transform.GetChild(0).gameObject.GetComponent<Text>();
        _motivationText.text = t4.text;

        if(_closedMotivation != null)
        {
            _closedMotivation.InActivateWindow();
        }

    }
}
