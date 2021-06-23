using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_OrangeChat_Coment
{
    public bool GetOrNot;
    public string OrangeChatContents;
    public string Commentary;
    public string Title;

    public Base_OrangeChat_Coment(bool CGetOrNot, string COrangeChatCOntents, string CCommentary,string CTitle)
    {
        GetOrNot = CGetOrNot;
        OrangeChatContents = COrangeChatCOntents;
        Commentary = CCommentary;
        Title = CTitle;
    }
}
