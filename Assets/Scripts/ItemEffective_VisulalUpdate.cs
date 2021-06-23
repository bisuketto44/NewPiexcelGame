using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffective_VisulalUpdate : MonoBehaviour
{
    [Tooltip("視聴者数アップ用テキスト")]
    [SerializeField]
    private Text ViewerUpRateText;

    [Tooltip("視聴継続率テキスト")]
    [SerializeField]
    private Text ViewrRetantionRateTex;

    [Tooltip("ハイパーチャットのレア出現率を上昇させる")]
    [SerializeField]
    private Text HiperChatraretyUpText;

    [Tooltip("やる気の回復速度上昇テキスト")]
    [SerializeField]
    private Text MotivationHealRateUpText;

    [Tooltip("アイテムの上昇効果を記録しているスクリプト")]
    [SerializeField]
    Live_Data_Information live_Data;

    public void UpdateRatioTexts()
    {
        int ViewerUpRateAmount = 0;
        int ViewerRatantionRateAmount = 0;
        int HiperchatRarityAmount = 0;
        int MotivationHealRateAmount = 0;
        int num = 0;

        for (int i = 0; i < SaveData.Instance.Item_Effectives.Count; i++)
        {
            //購入していないアイテムはスルー
            if (SaveData.Instance.Item_Effectives[i].OnOrOff != true)
            {
                continue;
            }

            num = (int)(SaveData.Instance.Item_Effectives[i].MultiplierEffective * 100);

            switch (SaveData.Instance.Item_Effectives[i].effectiveName)
            {

                case "視聴者数UP":
                    ViewerUpRateAmount += num;
                    break;
                case "やる気回復速度":
                    MotivationHealRateAmount += num;
                    break;
                case "視聴継続率UP":
                    ViewerRatantionRateAmount += num;
                    break;
                case "レアチャット獲得確立UP":
                    HiperchatRarityAmount += num;
                    break;
                case "全効果":
                    ViewerRatantionRateAmount += num;
                    ViewerUpRateAmount += num;
                    HiperchatRarityAmount += num;
                    MotivationHealRateAmount += num;
                    break;
            }
        }

        ViewerUpRateText.text = "+" + ViewerUpRateAmount.ToString("N0") + "%";
        ViewrRetantionRateTex.text = "+" + ViewerRatantionRateAmount.ToString("N0") + "%";
        HiperChatraretyUpText.text = "+" + HiperchatRarityAmount.ToString("N0") + "%";
        MotivationHealRateUpText.text = "+" + MotivationHealRateAmount.ToString("N0") + "%";

    }

}
