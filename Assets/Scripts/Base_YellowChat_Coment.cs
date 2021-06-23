using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_YellowChat_Coment
{
   public bool GetOrNot;
   public string YellowChatContents;
   public string Commentary;
   public string Title;

   public Base_YellowChat_Coment(bool CGetOrNot, string CYellowChatCOntents,string CCommentary,string CTitle)
   {
       GetOrNot = CGetOrNot;
       YellowChatContents = CYellowChatCOntents;
       Commentary = CCommentary;
       Title = CTitle;
   }
}
