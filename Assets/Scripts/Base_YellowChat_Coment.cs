using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_YellowChat_Coment
{
   public bool GetOrNot;
   public string YellowChatContents;

   public Base_YellowChat_Coment(bool CGetOrNot, string CYellowChatCOntents)
   {
       GetOrNot = CGetOrNot;
       YellowChatContents = CYellowChatCOntents;
   }
}
