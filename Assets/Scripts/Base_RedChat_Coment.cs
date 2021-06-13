using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_RedChat_Coment
{
    public bool GetOrNot;
    public string RedChatContents;

    public Base_RedChat_Coment(bool CGetOrNot, string CRedChatCOntents)
    {
        GetOrNot = CGetOrNot;
        RedChatContents = CRedChatCOntents;
    }
}
