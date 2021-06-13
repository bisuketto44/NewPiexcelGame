using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_OrangeChat_Coment
{
    public bool GetOrNot;
    public string OrangeChatContents;

    public Base_OrangeChat_Coment(bool CGetOrNot, string COrangeChatCOntents)
    {
        GetOrNot = CGetOrNot;
        OrangeChatContents = COrangeChatCOntents;
    }
}
