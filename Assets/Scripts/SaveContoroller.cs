using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveContoroller : MonoBehaviour
{
    [SerializeField]
    Style_Status_Management style_Status_Management;

    [SerializeField]
    JunleLv_Judge junleLv_Judge;

    [SerializeField]
    private GameObject Tutorial;

    [SerializeField]
    MoneyContoroller MoneyContoroller;



    void Awake()
    {
        //=================================================================================
        //データリロード
        //=================================================================================
        SaveData.Instance.Reload();
        //=================================================================================
        //初回時はチュートリアルを自動表示する
        //=================================================================================
        if (SaveData.Instance.PreviousDataIsAvailableOrNot == false)
        {
            Tutorial.SetActive(true);
        }
    }

    /// <summary>
    /// ゲーム終了時にセーブを行うメソッド
    /// </summary>
    void OnApplicationQuit()
    {
        //=================================================================================
        //スタイルポイントのスキル振りをセーブ前にSaveDataインスタンスへ格納
        //=================================================================================
        for (int i = 0; i < SaveData.Instance.StyleSatus.Length; i++)
        {
            SaveData.Instance.StyleSatus[i] = style_Status_Management.StyleSatus[i];
        }

        //=================================================================================
        //各経験値の総合量をsavedataインスタンスへ格納
        //=================================================================================

        for (int i = 0; i < junleLv_Judge.EachSlider.Length; i++)
        {
            SaveData.Instance.ExpAmounts[i] = junleLv_Judge.EachSlider[i]._comprehensiveEXP;
        }


        //=================================================================================
        //選択をリセット
        //=================================================================================

        for (int i = 0; i < SaveData.Instance.Style_Effective.Count; i++)
        {
            SaveData.Instance.Style_Effective[i].OnOrOff = false;
        }
        for (int i = 0; i < SaveData.Instance.junle_Effective.Count; i++)
        {
            SaveData.Instance.junle_Effective[i].OnorOff = false;
        }
        for (int i = 0; i < SaveData.Instance.motivation_Effective.Count; i++)
        {
            SaveData.Instance.motivation_Effective[i].OnOrOff = false;
        }
        for (int i = 0; i < SaveData.Instance.LiveTime.Count; i++)
        {
            SaveData.Instance.LiveTime[i].OnOrOff = false;
        }


        //=================================================================================
        //お金の保存
        //=================================================================================
        
        SaveData.Instance.moneys = MoneyContoroller.PossesedMoney;

        //=================================================================================
        //セーブを実行
        //=================================================================================
        SaveData.Instance.Save();
    }
}
