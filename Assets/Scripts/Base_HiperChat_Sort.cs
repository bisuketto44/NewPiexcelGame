using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_HiperChat_Sort
{
    public int number;
    public int value;
    public int No;
    public string ChatContent;

    public Base_HiperChat_Sort(int Cnumber, int Cvalue , int CNo,string CChatContent)
    {
        number = Cnumber;
        value = Cvalue;
        No = CNo;
        ChatContent = CChatContent;
    }
}
