using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//LayoutItemsWindowにアタッチするスクリプト
public class Activate_LayoutItem_Window : MonoBehaviour
{
    [Tooltip("何番目のレイアウト済みテキストか")]
    [SerializeField]
    GameObject[] Btns;

    [SerializeField]
    Layout_Items_StoreBOX LayoutStore;

    public void ActivateLayoutWindow()
    {
        this.gameObject.SetActive(true);

        //配置済み or 名前のどちらかを表示
        for (int i = 0; i < SaveData.Instance.whatBtn.Length; i++)
        {
            if (SaveData.Instance.whatBtn[i] == true)
            {
                Btns[i].transform.GetChild(0).gameObject.SetActive(false);
                Btns[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                Btns[i].transform.GetChild(0).gameObject.SetActive(true);
                Btns[i].transform.GetChild(1).gameObject.SetActive(false);
            }

        }

    }

    public void back()
    {
        this.gameObject.SetActive(false);
    }
}
