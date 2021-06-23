using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveContoroller : MonoBehaviour
{
    [SerializeField]
    Style_Status_Management style_Status_Management;

    [SerializeField]
    JunleLv_Judge junleLv_Judge;

    /// <summary>
    /// ゲーム終了時にセーブを行うメソッド
    /// </summary>
    void OnApplicationQuit()
    {

        //=================================================================================
        //セーブデータがあるフラグを立てる
        //=================================================================================
        SaveData.Instance.PreviousDataIsAvailableOrNot = true;

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
        //セーブを実行
        //=================================================================================
        SaveData.Instance.Save();
    }
}
