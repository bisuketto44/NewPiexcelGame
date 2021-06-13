using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live_Acaive_Store_List : MonoBehaviour
{
    [SerializeField]
    Hiper_Chat_Generates HipeChatGanereteCS;

    [Tooltip("アーカイブ選択ボタンの表示")]
    [SerializeField]
    GameObject[] AchivesSelectBtns;


    int count = 0;
    int count2 = 0;

    //アーカイブを保存するための２次元リストを作成
    public List<List<Base_HiperChat_Sort>> AcaiveLiveList;
    //その他のアーカイブ情報を保存するリストを作成
    public List<Base_Achives_Elements> AcaiveElementsList;

    void Awake()
    {
        //2次元リストの初期化
        AcaiveLiveList = new List<List<Base_HiperChat_Sort>>();
        AcaiveElementsList = new List<Base_Achives_Elements>();


    }

    //アーカイブ（ハイチャ)を2次元リストとして保存
    public void GenerateAcaiveHipeChatList()
    {

        //データの保存は10個まで
        if (count == 10)
        {
            count = 9;
            //一番古いデータを削除
            AcaiveLiveList.RemoveAt(0);
        }

        //Listに格納する中身のListを作成
        AcaiveLiveList.Add(new List<Base_HiperChat_Sort>());

        //中身に追加
        for (int i = 0; i < HipeChatGanereteCS.SortList.Count; i++)
        {
            AcaiveLiveList[count].Add(HipeChatGanereteCS.SortList[i]);
        }

        //アーカイブ選択ボタンを表示
        AchivesSelectBtns[count].SetActive(true);

        count++;

    }

    //データリスト(その他諸々)を作成
    public void GenerateAchiveElementsList(string title, string junle, string style, int maxviewer, int hiperchatmoney, int hiperchatamount, int buleamount, int yellowamount, int orangeamount, int redamount, int bulemoney, int yellowmoney, int orangemoney, int redmoney)
    {
        //最大個数を10個に制限
        if (count2 == 10)
        {
            count2 = 9;
            AcaiveElementsList.RemoveAt(0);
        }

        //リストを作成
        AcaiveElementsList.Add(new Base_Achives_Elements(title, junle, style, maxviewer, hiperchatmoney, hiperchatamount, buleamount, yellowamount, orangeamount, redamount, bulemoney, yellowmoney, orangemoney, redmoney));
        //リストのタイトルと視聴者数をボタンテキストに表示
        for (int i = 0; i < AcaiveElementsList.Count; i++)
        {
            Text sumple1 = AchivesSelectBtns[i].transform.GetChild(1).GetComponent<Text>();
            Text sumple2 = AchivesSelectBtns[i].transform.GetChild(2).GetComponent<Text>();

            sumple1.text = AcaiveElementsList[i].Title;
            sumple2.text = "最高視聴者数" + AcaiveElementsList[i].MaxViewer.ToString("N0") + "人";

        }
        count2++;


    }
}
