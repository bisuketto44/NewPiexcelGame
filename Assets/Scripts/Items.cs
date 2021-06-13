using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムデータベースの基礎になるclass
[System.Serializable]
public class Items
{
    //メンバ変数（フィールド）
    public string itemNameJP;
    public int itmeID;
    public string itemDesc;
    public Image itemIcon;
    public float ability;
    public int cost;
    public string ItemExplanation;

    //コンストラクタ
    public Items(string name, int id, string desc, string iconname, float abi, int costs, string Expla)
    {
        itemNameJP = name;
        itmeID = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Image>("Image_Icon_" + iconname);
        ability = abi;
        cost = costs;
        ItemExplanation = Expla;

    }

}
