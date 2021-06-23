using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_RedChat_Coment
{
    public bool GetOrNot;
    public string RedChatContents;
    public string Commentary;
    public string Title;

    public Base_RedChat_Coment(bool CGetOrNot, string CRedChatCOntents, string CCommentary,string CTitle)
    {
        GetOrNot = CGetOrNot;
        RedChatContents = CRedChatCOntents;
        Commentary = CCommentary;
        Title = CTitle;
    }
}
