using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Acahives : MonoBehaviour
{
    [Tooltip("情報を格納したリスト")]
    [SerializeField]
    Live_Acaive_Store_List LiveAchiveSList;

    public int whichDataLists = 0;

    [SerializeField]
    Text TileText;

    [SerializeField]
    Text JunleText;

    [SerializeField]
    Text StyleText;

    [SerializeField]
    Text MaxViewerThisLiveText;

    [SerializeField]
    Text HiperChatMoneyText;

    [SerializeField]
    Text HiperChatAmountText;

    //各色の個数を表示するテキスト
    [SerializeField]
    Text BuleAmountText;
    [SerializeField]
    Text YellowAmountText;
    [SerializeField]
    Text OrangeAmountText;
    [SerializeField]
    Text RedAmountText;

    //各色の値段を表示するテキスト
    [SerializeField]
    Text BuleMoneyText;
    [SerializeField]
    Text YellowMoneyText;
    [SerializeField]
    Text OrangeMoneyText;
    [SerializeField]
    Text RedMoneyText;

    public void UpdateAchiveBasicInfomations()
    {
        //各データを更新
        TileText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].Title;
        JunleText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].Junel;
        StyleText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].Style;
        MaxViewerThisLiveText.text = "最高同時視聴者数 : " + SaveData.Instance.AcaiveElementsList[whichDataLists].MaxViewer.ToString("N0") + "人";
        HiperChatMoneyText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].HiperchatMoney.ToString("N0");
        HiperChatAmountText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].HipechatAmount.ToString("N0") + "個";

        BuleAmountText.text = "青チャット : " + SaveData.Instance.AcaiveElementsList[whichDataLists].BuleAmount.ToString("N0") + "個";
        BuleMoneyText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].BuleMoney.ToString("N0");

        YellowAmountText.text = "黄チャット : " + SaveData.Instance.AcaiveElementsList[whichDataLists].YellowAmount.ToString("N0") + "個";
        YellowMoneyText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].YellowMoney.ToString("N0");

        OrangeAmountText.text = "橙チャット : " + SaveData.Instance.AcaiveElementsList[whichDataLists].OrangeAmount.ToString("N0") + "個";
        OrangeMoneyText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].OrangeMoney.ToString("N0");

        RedAmountText.text = "赤チャット : " + SaveData.Instance.AcaiveElementsList[whichDataLists].RedAmount.ToString("N0") + "個";
        RedMoneyText.text = SaveData.Instance.AcaiveElementsList[whichDataLists].RedMoney.ToString("N0");

    }


}
