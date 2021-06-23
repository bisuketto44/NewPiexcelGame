using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcaiveContoroller : MonoBehaviour
{
    [Tooltip("アーカイブ用のスクロールビュースクリプトを獲得")]
    [SerializeField]
    public InfinityScroll_Acaive InfenityScrollActivate;

    [Tooltip("その他のデータを表示するためボタンからの入力情報を送る")]
    [SerializeField]
    public Update_Acahives UpdateAchaives;

    [Tooltip("ハイパーチャットのアーカイブデータを保存しているリストを獲得")]
    [SerializeField]
    public Live_Acaive_Store_List LiveAcaiveStoreList;

    [Tooltip("ビジュアルアップデート用の無限スクロールビュースクリプトを獲得")]
    [SerializeField]
    InfinityScoll InfinityScrollScript;

    [Tooltip("アーカイブ詳細を表示するビュー")]
    [SerializeField]
    GameObject ArchivesView;

    [Tooltip("どのアーカイブ詳細を表示するかを選択するビュー")]
    [SerializeField]
    GameObject ArchivesSelectView;

    [Tooltip("チャンネル詳細を表示するビュー")]
    [SerializeField]
    GameObject ChannelView;

    [SerializeField]
    GameObject[] Views;

    public void ActivateAcaives(int whatNumberOfData)
    {
        //詳細ビューを表示
        Change(4);

        //表示するスパチャのマックス数を持ってくる
        InfenityScrollActivate.max = SaveData.Instance.AcaiveLiveList[whatNumberOfData].HiperChatList.Count;

        //Listの何番を表示するかを決定
        InfenityScrollActivate.WhatChats = whatNumberOfData;

        //何番目のその他のデータを表示するかを送る
        UpdateAchaives.whichDataLists = whatNumberOfData;

        //ビジュアルアップデート
        UpdateAchaives.UpdateAchiveBasicInfomations();

        //ビジュアルアップデート
        InfinityScrollScript.AutoUpdata();

    }


    public void BackToChannelView()
    {
        ArchivesSelectView.SetActive(false);
        ChannelView.SetActive(true);
    }

    //戻るボタン
    public void BackToSelectView()
    {
        ArchivesSelectView.SetActive(true);
        ArchivesView.SetActive(false);

    }

    //情報ウィンドウの表示機能
    public void Change(int num)
    {
        for (int i = 0; i < Views.Length; i++)
        {
            if (i == num)
            {
                Views[i].SetActive(true);
            }
            else
            {
                Views[i].SetActive(false);
            }

        }

    }
}
