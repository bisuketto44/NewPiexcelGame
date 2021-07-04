using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    //ツイッターのURLを開く
    public void OpneMyURL()
    {
        Application.OpenURL("https://twitter.com/bisu66582914");
    }
}
