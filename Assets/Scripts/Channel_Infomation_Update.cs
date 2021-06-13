using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Channel_Infomation_Update : MonoBehaviour
{
    //チャンネル登録者数を保存する変数
    int subscurivers = 0;

    [Tooltip("チャンネル登録者数を表示するテキスト")]
    [SerializeField]
    Text ChannnelSubscribersText;

    //最高同時接続数を保存するint
    int MaxViewerEver = 0;

    [Tooltip("今までの最高同時接続数を表示するテキスト")]
    [SerializeField]
    Text MaxViewerEverText;

    int MoneyEverEarnd;

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

    public string ChannelNameString;

    //各色の個数
    [SerializeField]
    Text BuleAmountText;
    [SerializeField]
    Text YellowAmountText;
    [SerializeField]
    Text OrangeAmountText;
    [SerializeField]
    Text RedAmountText;

    int BuleAmountint;
    int YellowAmountint;
    int OrangeAmountint;
    int RedAmountint;

    //各色の累計額
    [SerializeField]
    Text BuleMoneyText;
    [SerializeField]
    Text YellowMoneyText;
    [SerializeField]
    Text OrangeMoneyText;
    [SerializeField]
    Text RedMoneyText;

    int BuleMoneyint;
    int YellowMoneyInt;
    int OrangeMoneyInt;
    int RedMoneyInt;

    [Tooltip("コラボキャラを増やすメソッドを呼ぶ")]
    [SerializeField]
    private CollaboChar_Info_Database collaboCharInfoDatabase;

    void Awake()
    {
        //String型にチャンネル名を保存
        ChannelNameString = ChannelNameText.text;
    }

    //チャンネルの基本情報を更新するメソッド
    public void UpdateChannelMainInfomations(int Viewer, int MaxViewer, int MoneyEver)
    {
        var RandPercentage = Random.Range(20, 35);
        var num = (Viewer * ((float)RandPercentage / 100));
        Mathf.Round(num);
        //チャンネル登録者数に最終視聴者数の20~35%をランダムで追加
        subscurivers += (int)num;

        //現在の登録者数をコラボキャラの増加メソッドへ投げる
        collaboCharInfoDatabase.ActivateCollabocharcter(subscurivers);

        //最大視聴者数を更新
        MaxViewerEver = MaxViewer;

        //配信で稼いだ額を配信累計額に追加
        MoneyEverEarnd += MoneyEver;

        //テキストを更新
        ChannnelSubscribersText.text = subscurivers.ToString("N0") + "人";
        MaxViewerEverText.text = MaxViewer.ToString("N0") + "人";
        MoneyEverEarndText.text = MoneyEverEarnd.ToString("N0");

    }

    //ハイチャの累計個数更新
    public void UpdateHiperChatAmounts(int bule, int yellow, int orange, int red)
    {
        //合計個数を追加
        BuleAmountint += bule;
        YellowAmountint += yellow;
        OrangeAmountint += orange;
        RedAmountint += red;

        //テキスト更新
        BuleAmountText.text = "青チャット : " + BuleAmountint.ToString("N0") + "個";
        YellowAmountText.text = "黄チャット : " + YellowAmountint.ToString("N0") + "個";
        OrangeAmountText.text = "橙チャット : " + OrangeAmountint.ToString("N0") + "個";
        RedAmountText.text = "赤チャット : " + RedAmountint.ToString("N0") + "個";

    }

    //ハイチャの累計額を更新
    public void UpdateHiperChatMoneys(int bule, int yellow, int orange, int red)
    {
        //合計額を追加
        BuleMoneyint += bule;
        YellowMoneyInt += yellow;
        OrangeMoneyInt += orange;
        RedMoneyInt += red;

        BuleMoneyText.text = BuleMoneyint.ToString("N0");
        YellowMoneyText.text = YellowMoneyInt.ToString("N0");
        OrangeMoneyText.text = OrangeMoneyInt.ToString("N0");
        RedMoneyText.text = RedMoneyInt.ToString("N0");

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
        ChannelNameString = ChannelNameText.text;
        ChannelNameChangeWindow.SetActive(false);
    }


}
