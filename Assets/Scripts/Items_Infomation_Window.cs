using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Items_Infomarion_Panelに直接アタッチするスクリプト
public class Items_Infomation_Window : MonoBehaviour
{
    [Tooltip("アイテム情報を格納しているスクリプト")]
    [SerializeField]
    Item_DataBase ItemDataBase;

    [Tooltip("アイテムの見た目アイコンを表示するための親パネル")]
    [SerializeField]
    GameObject BackGroundPanel;

    [Tooltip("アイテム名を表示するテキスト")]
    [SerializeField]
    Text ItemNameText;

    [Tooltip("アイテムの説明文を表示するテキスト")]
    [SerializeField]
    Text ItemDescText;

    [Tooltip("アイテムの効果説明をするテキスト")]
    [SerializeField]
    Text ItemEffectiveDescText;


    public void ActivateItemsInfomation(int WhichItem)
    {
        this.gameObject.SetActive(true);

        //要素を削除
        if (BackGroundPanel.transform.childCount >= 1)
        {
            Destroy(BackGroundPanel.transform.GetChild(0).gameObject);
        }


        //パネルに選択された情報を表示
        Instantiate(ItemDataBase.items[WhichItem].itemIcon, BackGroundPanel.transform.position, Quaternion.identity, BackGroundPanel.transform);
        ItemNameText.text = ItemDataBase.items[WhichItem].itemNameJP;
        ItemDescText.text = ItemDataBase.items[WhichItem].ItemExplanation;
        ItemEffectiveDescText.text = ItemDataBase.items[WhichItem].itemDesc;


    }

    public void back()
    {
        this.gameObject.SetActive(false);
    }
}
