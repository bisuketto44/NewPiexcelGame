using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcaiveChats : MonoBehaviour
{
    //全ハイチャに付属する割り振り番号と金額とコメント内容
    public int ChatNumber = 0;
    public int whatColor = 0;
    public string ThisHiperChat_ChatContent;

    public int Whatcahts;

    [Tooltip("開くウィンドウ")]
    GameObject HiperChatWindowObject;

    [Tooltip("背景Image1")]
    Image Image1;

    [Tooltip("背景image2")]

    Image Image2;

    [Tooltip("ハイチャの金額表示テキスト")]
    Text MoneyText;

    [Tooltip("ハイチャのチャット内容表示テキスト")]
    Text ChatContentText;

    [Tooltip("ユーザーアイコンのイメージ")]
    Image UserIconImage;


    //値段を表示するテキスト
    [SerializeField]
    Text ValueText;

    [SerializeField]
    Image ObjectImage;

    [SerializeField]
    Button ThisButton;

    private SE_Contoroller sE_Contoroller;

    public void UpdateChat(int count, int whatchats)
    {
        //ソートした後のリストの一番目を取得してくる
        var SortList = GameObject.FindWithTag("Live_Acaive_Store").GetComponent<Live_Acaive_Store_List>();

        //値段を表示
        ValueText.text = SaveData.Instance.AcaiveLiveList[whatchats].HiperChatList[count].value.ToString("N0");

        //値段に合わせて色を変更
        switch (SaveData.Instance.AcaiveLiveList[whatchats].HiperChatList[count].number)
        {
            case 0:
                ObjectImage.color = new Color32(161, 207, 245, 255);
                ThisButton.interactable = false;
                break;
            case 1:
                ObjectImage.color = new Color32(245, 236, 161, 255);
                ThisButton.interactable = true;
                break;
            case 2:
                ObjectImage.color = new Color32(245, 202, 161, 255);
                ThisButton.interactable = true;
                break;
            case 3:
                ObjectImage.color = new Color32(245, 169, 161, 255);
                ThisButton.interactable = true;
                break;
        }

        //インスタンスの変数に今の何番目のアイテムなのかを格納
        ChatNumber = count;
        //保存
        Whatcahts = whatchats;

    }

    //表示に内容を描画
    public void HiperChatContentDesplay()
    {
        //ウィンドウをアクティブ化
        GameObject.FindWithTag("HiperChatViewParent").transform.GetChild(0).gameObject.SetActive(true);

        //サウンドを鳴らす
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();
        sE_Contoroller.PlayAttensionSound();

        //取得
        Image1 = GameObject.FindWithTag("HiperChatViewImage1").GetComponent<Image>();
        Image2 = GameObject.FindWithTag("HiperChatViewImage2").GetComponent<Image>();
        MoneyText = GameObject.FindWithTag("HiperChatMoneyText").GetComponent<Text>();
        ChatContentText = GameObject.FindWithTag("HiperChatContentText").GetComponent<Text>();
        UserIconImage = GameObject.FindWithTag("HiperChatUserImage").GetComponent<Image>();
        var SortList = GameObject.FindWithTag("Live_Acaive_Store").GetComponent<Live_Acaive_Store_List>();

        //格納されたcount変数を使ってリスト内のチャットの値段と、保存したコメント内容を読んでくる
        MoneyText.text = SaveData.Instance.AcaiveLiveList[Whatcahts].HiperChatList[ChatNumber].value.ToString("N0");
        ChatContentText.text = SaveData.Instance.AcaiveLiveList[Whatcahts].HiperChatList[ChatNumber].ChatContent;

        //スパチャの色に合わせてカラーを決定
        switch (SaveData.Instance.AcaiveLiveList[Whatcahts].HiperChatList[ChatNumber].number)
        {
            case 0:
                break;
            case 1:
                Image1.color = new Color32(143, 147, 91, 70);
                Image2.color = new Color32(143, 147, 91, 70);
                break;
            case 2:
                Image1.color = new Color32(147, 121, 91, 70);
                Image2.color = new Color32(147, 121, 91, 70);
                break;
            case 3:
                Image1.color = new Color32(147, 92, 91, 70);
                Image2.color = new Color32(147, 92, 91, 70);
                break;
        }

        //ユーザーアイコンのカラーを決定
        switch (SaveData.Instance.AcaiveLiveList[Whatcahts].HiperChatList[ChatNumber].No)
        {
            case 0:
                UserIconImage.color = new Color32(0, 203, 255, 150);//bule
                break;
            case 1:
                UserIconImage.color = new Color32(0, 255, 187, 150);
                break;
            case 2:
                UserIconImage.color = new Color32(14, 255, 0, 150);
                break;
            case 3:
                UserIconImage.color = new Color32(155, 255, 0, 150);
                break;
            case 4:
                UserIconImage.color = new Color32(255, 248, 0, 150);
                break;
            case 5:
                UserIconImage.color = new Color32(255, 132, 0, 150);
                break;
            case 6:
                UserIconImage.color = new Color32(255, 0, 156, 150);
                break;
            case 7:
                UserIconImage.color = new Color32(172, 0, 255, 150);
                break;
            case 8:
                UserIconImage.color = new Color32(0, 48, 255, 150);
                break;
            case 9:
                UserIconImage.color = new Color32(0, 120, 255, 150);
                break;

        }

    }

}
