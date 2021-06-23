using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live_Acaive_Store_List : MonoBehaviour
{
    //作成したハイパーチャットのリスト
    [SerializeField]
    Hiper_Chat_Generates HipeChatGanereteCS;

    [Tooltip("アーカイブ選択ボタンの表示")]
    [SerializeField]
    GameObject[] AchivesSelectBtns;

    void Awake()
    {
        //リストをもつクラスを格納するためのリスト
        SaveData.Instance.AcaiveLiveList = new List<ValueList>();

        //=================================================================================
        //セーブデータロード時にあるアーカイブ数だけボタンを表示
        //=================================================================================

        if (SaveData.Instance.AcaiveElementsList == null)
        {
            return;
        }

        for (int i = 0; i < SaveData.Instance.AcaiveElementsList.Count; i++)
        {
            //アーカイブ選択ボタンを表示
            AchivesSelectBtns[i].SetActive(true);
            Text sumple1 = AchivesSelectBtns[i].transform.GetChild(1).GetComponent<Text>();
            Text sumple2 = AchivesSelectBtns[i].transform.GetChild(2).GetComponent<Text>();

            sumple1.text = SaveData.Instance.AcaiveElementsList[i].Title;
            sumple2.text = "最高視聴者数" + SaveData.Instance.AcaiveElementsList[i].MaxViewer.ToString("N0") + "人";
        }

    }

    //アーカイブ（ハイチャ)を2次元リストとして保存
    public void GenerateAcaiveHipeChatList()
    {

        //データの保存は10個まで
        if (SaveData.Instance.count == 10)
        {
            SaveData.Instance.count = 9;
            //一番古いデータを削除
            SaveData.Instance.AcaiveLiveList.RemoveAt(0);
        }

        //リストを持つクラスを新たに生成し、その中身のリストにハイチャの履歴を格納
        SaveData.Instance.AcaiveContents = new ValueList();
        for (int i = 0; i < HipeChatGanereteCS.SortList.Count; i++)
        {
            SaveData.Instance.AcaiveContents.HiperChatList.Add(HipeChatGanereteCS.SortList[i]);
        }

        //履歴を格納したclassを格納
        SaveData.Instance.AcaiveLiveList.Add(SaveData.Instance.AcaiveContents);


        //アーカイブ選択ボタンを表示
        AchivesSelectBtns[SaveData.Instance.count].SetActive(true);

        SaveData.Instance.count++;

    }

    //データリスト(その他諸々)を作成
    public void GenerateAchiveElementsList(string title, string junle, string style, int maxviewer, int hiperchatmoney, int hiperchatamount, int buleamount, int yellowamount, int orangeamount, int redamount, int bulemoney, int yellowmoney, int orangemoney, int redmoney)
    {
        //最大個数を10個に制限
        if (SaveData.Instance.count2 == 10)
        {
            SaveData.Instance.count2 = 9;
            SaveData.Instance.AcaiveElementsList.RemoveAt(0);
        }

        //リストを作成
        SaveData.Instance.AcaiveElementsList.Add(new Base_Achives_Elements(title, junle, style, maxviewer, hiperchatmoney, hiperchatamount, buleamount, yellowamount, orangeamount, redamount, bulemoney, yellowmoney, orangemoney, redmoney));
        //リストのタイトルと視聴者数をボタンテキストに表示
        for (int i = 0; i < SaveData.Instance.AcaiveElementsList.Count; i++)
        {
            Text sumple1 = AchivesSelectBtns[i].transform.GetChild(1).GetComponent<Text>();
            Text sumple2 = AchivesSelectBtns[i].transform.GetChild(2).GetComponent<Text>();

            sumple1.text = SaveData.Instance.AcaiveElementsList[i].Title;
            sumple2.text = "最高視聴者数" + SaveData.Instance.AcaiveElementsList[i].MaxViewer.ToString("N0") + "人";

        }
        SaveData.Instance.count2++;


    }
}

//クラスに別のクラスのインスタンスのリストをを持たせる
[System.SerializableAttribute]
public class ValueList
{
    public List<Base_HiperChat_Sort> HiperChatList = new List<Base_HiperChat_Sort>();

}
