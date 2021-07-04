using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollaboPictureBookUpdate : MonoBehaviour
{
    [Tooltip("ハイパーチャットの各詳細の格納データ")]
    [SerializeField]
    private Coment_HiperChat_DataBaseContoroller coment_HiperChat_DataBaseContoroller;

    //獲得したチャットのタイトル欄
    [SerializeField]
    private Text[] YellowTitleText;
    [SerializeField]
    private Text[] OrangeTitleText;
    [SerializeField]
    private Text[] RedTitleText;

    //獲得したチャットのハイチャ内容
    [SerializeField]
    private Text ChatContentText;
    //取得したチャットの解説
    [SerializeField]
    private Text ChatCommentaryText;
    [SerializeField]
    private Text ChatTitle;

    //スパチャの色変更のためにオブジェクトを取得
    [SerializeField]
    private Image WidnowPanel;
    [SerializeField]
    private Image WidnowPanel2;
    [SerializeField]
    private GameObject HiperChatContentGameObject;

    private SE_Contoroller sE_Contoroller;


    void Awake()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();

        //=================================================================================
        //獲得したハイパーチャットを復元
        //=================================================================================
        for (int i = 0; i < SaveData.Instance.YellowChatComents.Count; i++)
        {
            if (SaveData.Instance.YellowChatComents[i].GetOrNot == true)
            {
                YellowTitleText[i].text = SaveData.Instance.YellowChatComents[i].Title;
            }
        }

        for (int i = 0; i < SaveData.Instance.OrangeChatComents.Count; i++)
        {
            if (SaveData.Instance.OrangeChatComents[i].GetOrNot == true)
            {
                OrangeTitleText[i].text = SaveData.Instance.OrangeChatComents[i].Title;
            }
        }

        for (int i = 0; i < SaveData.Instance.RedChatComents.Count; i++)
        {
            if (SaveData.Instance.RedChatComents[i].GetOrNot == true)
            {
                RedTitleText[i].text = SaveData.Instance.RedChatComents[i].Title;
            }
        }
    }

    /// <summary>
    /// もしそのチャットを獲得していたらフラグを立てて???をタイトルに変更する(HiperChatGererateで呼ぶ)
    /// </summary>
    public void GetFlagChats(int color, int index)
    {
        switch (color)
        {
            case 1:
                SaveData.Instance.YellowChatComents[index].GetOrNot = true;
                YellowTitleText[index].text = SaveData.Instance.YellowChatComents[index].Title;
                break;
            case 2:
                SaveData.Instance.OrangeChatComents[index].GetOrNot = true;
                OrangeTitleText[index].text = SaveData.Instance.OrangeChatComents[index].Title;
                break;
            case 3:
                SaveData.Instance.RedChatComents[index].GetOrNot = true;
                RedTitleText[index].text = SaveData.Instance.RedChatComents[index].Title;
                break;
        }

    }

    //それぞれのハイパーチャットの内容と解説を表示する(ハイパーチャット図鑑のボタンを押したら起動するメソッド)
    public void DisPlayChatsContentYellow(int index)
    {
        HiperChatContentGameObject.SetActive(true);
        //黄色に変更
        WidnowPanel.color = new Color32(143, 147, 91, 70);
        WidnowPanel2.color = new Color32(143, 147, 91, 70);

        sE_Contoroller.PlayDicideSound();

        //まだゲットしていなかった場合
        if (SaveData.Instance.YellowChatComents[index].GetOrNot == false)
        {
            ChatContentText.text = "?????";
            ChatCommentaryText.text = "?????";
            ChatTitle.text = "?????";
            return;
        }

        //チャット内容と解説を表示
        ChatContentText.text = SaveData.Instance.YellowChatComents[index].YellowChatContents;
        ChatCommentaryText.text = SaveData.Instance.YellowChatComents[index].Commentary;
        ChatTitle.text = SaveData.Instance.YellowChatComents[index].Title;



    }

    public void DisPlayChatsContentOrange(int index)
    {
        HiperChatContentGameObject.SetActive(true);
        WidnowPanel.color = new Color32(147, 121, 91, 70);
        WidnowPanel2.color = new Color32(147, 121, 91, 70);

        sE_Contoroller.PlayDicideSound();

        if (SaveData.Instance.OrangeChatComents[index].GetOrNot == false)
        {
            ChatContentText.text = "?????";
            ChatCommentaryText.text = "?????";
            ChatTitle.text = "?????";
            return;

        }

        ChatContentText.text = SaveData.Instance.OrangeChatComents[index].OrangeChatContents;
        ChatCommentaryText.text = SaveData.Instance.OrangeChatComents[index].Commentary;
        ChatTitle.text = SaveData.Instance.OrangeChatComents[index].Title;



    }

    public void DisPlayChatsContentRed(int index)
    {
        HiperChatContentGameObject.SetActive(true);
        WidnowPanel.color = new Color32(147, 92, 91, 70);
        WidnowPanel2.color = new Color32(147, 92, 91, 70);

        sE_Contoroller.PlayDicideSound(); sE_Contoroller.PlayDicideSound();

        if (SaveData.Instance.RedChatComents[index].GetOrNot == false)
        {
            ChatContentText.text = "?????";
            ChatCommentaryText.text = "?????";
            ChatTitle.text = "?????";
            return;

        }

        ChatContentText.text = SaveData.Instance.RedChatComents[index].RedChatContents;
        ChatCommentaryText.text = SaveData.Instance.RedChatComents[index].Commentary;
        ChatTitle.text = SaveData.Instance.RedChatComents[index].Title;

    }



}
