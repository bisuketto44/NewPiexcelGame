using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_Effective
{
    //アイテム効果が有効かどうか
    public bool OnOrOff = false;
    //各アイテムの倍率効果
    public float MultiplierEffective;
    //アイテムの隠しviwer固定値UP
    public int HiddenFixedValues;
    public string ItemsName;
    public string effectiveName;

    public Item_Effective(bool COnOrOff, float CMultiplierEffective, int CHiddenFixedValue, string name, string effectname)
    {
        OnOrOff = COnOrOff;
        MultiplierEffective = CMultiplierEffective;
        HiddenFixedValues = CHiddenFixedValue;
        ItemsName = name;
        effectiveName = effectname;

    }



}


