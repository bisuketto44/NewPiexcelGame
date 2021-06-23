using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JunleLv_Judge : MonoBehaviour
{
    [Tooltip("各スライダーの経験値スクリプト")]
    [SerializeField]
    public LvUp_EXP[] EachSlider;

    [Tooltip("そのジャンルが配信に使用されたかを判定する")]
    [SerializeField]
    Live_Data_Information Live_Data;

    [Tooltip("最終的に配信に訪れた人数")]
    [SerializeField]
    Viewer_Count ViwerResult;

    [Tooltip("各ジャンルレベルのテキスト")]
    [SerializeField]
    Text[] JunleLvText;

    [Tooltip("レベルアップごとの各ジャンルの増加値")]
    [SerializeField]
    private int[] LiveJunleIncrement;

    //経験値バーを初期化してあげる
    void Awake()
    {
        LiveJunleIncrement = new int[] { 50, 100, 150, 200, 250 };

        for (int i = 0; i < EachSlider.Length; i++)
        {
            EachSlider[i].initializationEXPtables();

            if (SaveData.Instance.PreviousDataIsAvailableOrNot == false)
            {
                continue;
            }

            EachSlider[i].GiveExP(SaveData.Instance.ExpAmounts[i]);
            //レベルテキストを更新
            JunleLvText[i].text = "Lv" + EachSlider[i].currentLevel.ToString();
            //各ジャンルの現在のレベルに合わせた増加値を再設定してあげる。
            SaveData.Instance.junle_Effective[i].BaseIncrease = LiveJunleIncrement[EachSlider[i].currentLevel - 1];
        }


    }

    /// <summary>
    /// どのジャンルが使用されたかを判別し、最終的な視聴者数(経験値)をそのジャンルの経験値バーに与える
    /// </summary>
    public void JudgmentJunles()
    {
        for (int i = 0; i < SaveData.Instance.junle_Effective.Count; i++)
        {
            if (SaveData.Instance.junle_Effective[i].OnorOff == true)
            {
                //経験値を与える
                EachSlider[i].GiveExP(ViwerResult._nowViewerCount);

                //レベルテキストを更新
                JunleLvText[i].text = "Lv" + EachSlider[i].currentLevel.ToString();

                //各ジャンルの現在のレベルに合わせた増加値を再設定してあげる。
                SaveData.Instance.junle_Effective[i].BaseIncrease = LiveJunleIncrement[EachSlider[i].currentLevel - 1];

            }
        }
    }



}
