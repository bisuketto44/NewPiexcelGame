using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hiper_Chat_Generates : MonoBehaviour
{
    [Tooltip("4色のハイパーチャットオブジェクト")]
    [SerializeField]
    private GameObject HiperChatObjects;

    [Tooltip("ハイパーチャットのコメントデータベース")]
    [SerializeField]
    Coment_HiperChat_DataBaseContoroller HiperChatDataBaseContoroller;

    [Tooltip("ハイパーチャット図鑑のフラグ管理をする")]
    [SerializeField]
    CollaboPictureBookUpdate collaboPictureBookUpdate;

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
                var num1 = Random.Range(0, SaveData.Instance.YellowChatComents.Count);
                Chatstring = SaveData.Instance.YellowChatComents[num1].YellowChatContents;

                //フラグを立てる
                if (SaveData.Instance.YellowChatComents[num1].GetOrNot == false)
                {
                    collaboPictureBookUpdate.GetFlagChats(1, num1);
                }

                HiperChatListGenerate(WhichColor, Value, ListCount, Chatstring);
                break;
            case 2:
                var num2 = Random.Range(0, SaveData.Instance.OrangeChatComents.Count);
                Chatstring = SaveData.Instance.OrangeChatComents[num2].OrangeChatContents;

                if (SaveData.Instance.OrangeChatComents[num2].GetOrNot == false)
                {
                    collaboPictureBookUpdate.GetFlagChats(2, num2);
                }

                HiperChatListGenerate(WhichColor, Value, ListCount, Chatstring);
                break;
            case 3:
                var num3 = Random.Range(0, SaveData.Instance.RedChatComents.Count);
                Chatstring = SaveData.Instance.RedChatComents[num3].RedChatContents;

                if (SaveData.Instance.RedChatComents[num3].GetOrNot == false)
                {
                    collaboPictureBookUpdate.GetFlagChats(3, num3);
                }

                SaveData.Instance.RedChatComents[num3].GetOrNot = true;
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

