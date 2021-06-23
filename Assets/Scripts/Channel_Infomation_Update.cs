using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Channel_Infomation_Update : MonoBehaviour
{

    [Tooltip("チャンネル登録者数を表示するテキスト")]
    [SerializeField]
    Text ChannnelSubscribersText;

    [Tooltip("今までの最高同時接続数を表示するテキスト")]
    [SerializeField]
    Text MaxViewerEverText;

    [Tooltip("今までの累計額を表示するテキスト")]
    [SerializeField]
    Text MoneyEverEarndText;

    [Tooltip("チャンネル名変更ウィンドウ")]
    [SerializeField]
    GameObject ChannelNameChangeWindow;

    [Tooltip("チャンネル名を表示するテキスト")]
    [SerializeField]
    Text ChannelNameText;

    [Tooltip("変更後のチャンネル")]
    [SerializeField]
    Text ChangeChannelNameText;

    //各色の個数
    [SerializeField]
    Text BuleAmountText;
    [SerializeField]
    Text YellowAmountText;
    [SerializeField]
    Text OrangeAmountText;
    [SerializeField]
    Text RedAmountText;

    //各色の累計額
    [SerializeField]
    Text BuleMoneyText;
    [SerializeField]
    Text YellowMoneyText;
    [SerializeField]
    Text OrangeMoneyText;
    [SerializeField]
    Text RedMoneyText;

    [Tooltip("コラボキャラを増やすメソッドを呼ぶ")]
    [SerializeField]
    private CollaboChar_Info_Database collaboCharInfoDatabase;

    void Awake()
    {
        //String型にチャンネル名を保存
        ChannelNameText.text = SaveData.Instance.ChannelNameString;
        SaveData.Instance.ChannelNameString = ChannelNameText.text;

        //=================================================================================
        //データロード時にチャンネル情報を復元
        //=================================================================================
        MaxViewerEverText.text = SaveData.Instance.MaxViewerEver.ToString("N0") + "人";
        ChannnelSubscribersText.text = SaveData.Instance.subscrivers.ToString("N0") + "人";
        MaxViewerEverText.text = SaveData.Instance.MaxViewerEver.ToString("N0") + "人";
        MoneyEverEarndText.text = SaveData.Instance.MoneyEverEarnd.ToString("N0");

        BuleAmountText.text = "青チャット : " + SaveData.Instance.buleamount.ToString("N0") + "個";
        YellowAmountText.text = "黄チャット : " + SaveData.Instance.yellowamount.ToString("N0") + "個";
        OrangeAmountText.text = "橙チャット : " + SaveData.Instance.orangeamount.ToString("N0") + "個";
        RedAmountText.text = "赤チャット : " + SaveData.Instance.redamount.ToString("N0") + "個";

        BuleMoneyText.text = SaveData.Instance.bulemoney.ToString("N0");
        YellowMoneyText.text = SaveData.Instance.yellowmoney.ToString("N0");
        OrangeMoneyText.text = SaveData.Instance.orangemoney.ToString("N0");
        RedMoneyText.text = SaveData.Instance.redmoney.ToString("N0");
    }

    //チャンネルの基本情報を更新するメソッド
    public void UpdateChannelMainInfomations(int Viewer, int MaxViewer, int MoneyEver)
    {
        var RandPercentage = Random.Range(40, 70);
        var num = (Viewer * ((float)RandPercentage / 100));
        Mathf.Round(num);
        //チャンネル登録者数に最終視聴者数の20~35%をランダムで追加
        SaveData.Instance.subscrivers += (int)num;

        //現在の登録者数をコラボキャラの増加メソッドへ投げる
        collaboCharInfoDatabase.ActivateCollabocharcter(SaveData.Instance.subscrivers);

        //最大視聴者数を更新
        SaveData.Instance.MaxViewerEver = MaxViewer;

        //配信で稼いだ額を配信累計額に追加
        SaveData.Instance.MoneyEverEarnd += MoneyEver;

        //テキストを更新
        ChannnelSubscribersText.text = SaveData.Instance.subscrivers.ToString("N0") + "人";
        MaxViewerEverText.text = SaveData.Instance.MaxViewerEver.ToString("N0") + "人";
        MoneyEverEarndText.text = SaveData.Instance.MoneyEverEarnd.ToString("N0");

    }

    //ハイチャの累計個数更新
    public void UpdateHiperChatAmounts(int bule, int yellow, int orange, int red)
    {
        //合計個数を追加
        SaveData.Instance.buleamount += bule;
        SaveData.Instance.yellowamount += yellow;
        SaveData.Instance.orangeamount += orange;
        SaveData.Instance.redamount += red;

        //テキスト更新
        BuleAmountText.text = "青チャット : " + SaveData.Instance.buleamount.ToString("N0") + "個";
        YellowAmountText.text = "黄チャット : " + SaveData.Instance.yellowamount.ToString("N0") + "個";
        OrangeAmountText.text = "橙チャット : " + SaveData.Instance.orangeamount.ToString("N0") + "個";
        RedAmountText.text = "赤チャット : " + SaveData.Instance.redamount.ToString("N0") + "個";

    }

    //ハイチャの累計額を更新
    public void UpdateHiperChatMoneys(int bule, int yellow, int orange, int red)
    {
        //合計額を追加
        SaveData.Instance.bulemoney += bule;
        SaveData.Instance.yellowmoney += yellow;
        SaveData.Instance.orangemoney += orange;
        SaveData.Instance.redmoney += red;

        BuleMoneyText.text = SaveData.Instance.bulemoney.ToString("N0");
        YellowMoneyText.text = SaveData.Instance.yellowmoney.ToString("N0");
        OrangeMoneyText.text = SaveData.Instance.orangemoney.ToString("N0");
        RedMoneyText.text = SaveData.Instance.redmoney.ToString("N0");

    }

    //チャンネル名変更ウィンドウを起動する(ボタンから呼び出し)
    public void ActivateChannnelNameChangeWindow()
    {
        ChannelNameChangeWindow.SetActive(true);
    }

    //変更後のチャンネル名を適用する(ボタンから呼び出し)
    public void AplayChannelName()
    {
        //変更した名前を適用
        ChannelNameText.text = ChangeChannelNameText.text;
        SaveData.Instance.ChannelNameString = ChannelNameText.text;
        ChannelNameChangeWindow.SetActive(false);
    }


}
