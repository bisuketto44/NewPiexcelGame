using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hiper_Chat_Generates : MonoBehaviour
{
    [Tooltip("4色のハイパーチャットオブジェクト")]
    [SerializeField]
    private GameObject HiperChatObjects;

    [Tooltip("自動スクロール実行の有無を決定するトグル")]
    [SerializeField]
    private Toggle HiperChatToggle;

    [Tooltip("自動スクロールのためのスクロールバー")]
    [SerializeField]
    private Scrollbar HiperChatScrollbar;

    [Tooltip("ハイパーチャットのコメントデータベース")]
    [SerializeField]
    Coment_HiperChat_DataBaseContoroller HiperChatDataBaseContoroller;

    //セットする親の、金額順ソート用のリスト、何個目に生成されたかを数えるint変数
    private Transform SetParent;
    public List<Base_HiperChat_Sort> SortList;
    public int ListCount = -1;

    void Awake()
    {
        //ソート用のリストを作成。追加はチャット生成時に順次行う
        SortList = new List<Base_HiperChat_Sort>();
    }

    public void GenerateHiperChat(int WhichColor, int Value)
    {
        ListCount = Random.Range(0, 10);
        string Chatstring;
        //リスト作成とリストソートを実行

        switch (WhichColor)
        {
            case 0:
                HiperChatListGenerate(WhichColor, Value, ListCount, "");
                break;
            case 1:
                var num1 = Random.Range(0, HiperChatDataBaseContoroller.YellowChatComents.Count);
                Chatstring = HiperChatDataBaseContoroller.YellowChatComents[num1].YellowChatContents;
                HiperChatListGenerate(WhichColor, Value, ListCount, Chatstring);
                break;
            case 2:
                var num2 = Random.Range(0, HiperChatDataBaseContoroller.OrangeChatComents.Count);
                Chatstring = HiperChatDataBaseContoroller.OrangeChatComents[num2].OrangeChatContents;
                HiperChatListGenerate(WhichColor, Value, ListCount, Chatstring);
                break;
            case 3:
                var num3 = Random.Range(0, HiperChatDataBaseContoroller.RedChatComents.Count);
                Chatstring = HiperChatDataBaseContoroller.RedChatComents[num3].RedChatContents;
                HiperChatListGenerate(WhichColor, Value, ListCount, Chatstring);
                break;
        }

        HiperChatListSort();

    }

    //リストに追加(どの色のスパチャか、値段、どの色のイメージアイコンか、どのチャット内容か)
    private void HiperChatListGenerate(int countNumber, int value, int ListCount, string ChatContent)
    {
        SortList.Add(new Base_HiperChat_Sort(countNumber, value, ListCount, ChatContent));
    }
    //ハイパーチャットの値段順に下降順(大→小)ソート
    private void HiperChatListSort()
    {
        SortList.Sort((A, B) => B.value - A.value);
    }

}

