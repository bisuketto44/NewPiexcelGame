using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorollVar_AutoBackValue1 : MonoBehaviour
{
    Scrollbar scrollbar;

    //アクティブ時にスクロールバーを取得
    void Awake()
    {
        scrollbar = this.gameObject.GetComponent<Scrollbar>();
    }
    //非アクティブ時にスクロールバーの位置をリセット
    void OnDisable()
    {
        scrollbar.value = 1;

    }
}
