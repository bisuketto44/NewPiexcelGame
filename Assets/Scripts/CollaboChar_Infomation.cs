using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//コラボキャラクターの基礎情報Class
[System.Serializable]
public class CollaboChar_Infomation
{
    public string CharcterName;
    public int CharcterNumber;
    public string CharcterExplanation;
    public string CharcterRaretity;
    public Image CharcterImage;
    public int RequiredRegistrants;

    /// <summary>
    /// コラボキャラの基礎情報を追加するClass
    /// </summary>
    /// <param name="CharcterNameC">コラボキャラの名前</param>
    /// <param name="CharcterNumberC">コラボキャラの番号。イメージ生成などで使用</param>
    /// <param name="CharcterExplanationC">コラボキャラの説明</param>
    /// <param name="CharcterRaretityC">コラボキャラのレアリティ</param>
    public CollaboChar_Infomation(string CharcterNameC, int CharcterNumberC, string CharcterExplanationC, string CharcterRaretityC, int requiredregistrants)
    {
        CharcterName = CharcterNameC;
        CharcterNumber = CharcterNumberC;
        CharcterExplanation = CharcterExplanationC;
        CharcterRaretity = CharcterRaretityC;
        CharcterImage = Resources.Load<Image>("CharIcon_Collabo" + CharcterNumber.ToString());
        RequiredRegistrants = requiredregistrants;

    }

}
