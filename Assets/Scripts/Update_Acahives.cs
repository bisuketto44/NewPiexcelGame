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
        TileText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].Title;
        JunleText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].Junel;
        StyleText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].Style;
        MaxViewerThisLiveText.text = "最高同時視聴者数 : " + LiveAchiveSList.AcaiveElementsList[whichDataLists].MaxViewer.ToString("N0") + "人";
        HiperChatMoneyText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].HiperchatMoney.ToString("N0");
        HiperChatAmountText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].HipechatAmount.ToString("N0") + "個";

        BuleAmountText.text = "青チャット : " + LiveAchiveSList.AcaiveElementsList[whichDataLists].BuleAmount.ToString("N0") + "個";
        BuleMoneyText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].BuleMoney.ToString("N0");

        YellowAmountText.text = "黄チャット : " + LiveAchiveSList.AcaiveElementsList[whichDataLists].YellowAmount.ToString("N0") + "個";
        YellowMoneyText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].YellowMoney.ToString("N0");

        OrangeAmountText.text = "橙チャット : " + LiveAchiveSList.AcaiveElementsList[whichDataLists].OrangeAmount.ToString("N0") + "個";
        OrangeMoneyText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].OrangeMoney.ToString("N0");

        RedAmountText.text = "赤チャット : " + LiveAchiveSList.AcaiveElementsList[whichDataLists].RedAmount.ToString("N0") + "個";
        RedMoneyText.text = LiveAchiveSList.AcaiveElementsList[whichDataLists].RedMoney.ToString("N0");

    }


}
