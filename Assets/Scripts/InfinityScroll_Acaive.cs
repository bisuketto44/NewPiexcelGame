using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfinityScroll_Acaive : UIBehaviour, InfinityScrollSetUp
{
    //表示するハイチャの数を指定
    public int max = 0;

    public int WhatChats = 0;

    public void OnPostSetupItems()
    {
        var infiniteScroll = GetComponent<InfinityScoll>();
        infiniteScroll.onUpdateItem.AddListener(OnUpdateItem);
        //GetComponentInParent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;
        var rectTransform = GetComponent<RectTransform>();
        var delta = rectTransform.sizeDelta;

        //横サイズを増加。縦方向ならyで
        delta.x = infiniteScroll.itemScale * max;
        rectTransform.sizeDelta = delta;

    }

    public void OnUpdateItem(int itemCount, GameObject obj)
    {
        if (itemCount < 0 || itemCount >= max)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);

            //対象のゲームオブジェクトに付属したItemを呼び出す
            var chats = obj.GetComponentInChildren<AcaiveChats>();
            chats.UpdateChat(itemCount, WhatChats);
        }
    }
}
