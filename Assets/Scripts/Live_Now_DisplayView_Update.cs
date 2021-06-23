using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live_Now_DisplayView_Update : MonoBehaviour
{
    [SerializeField]
    private GameObject[] DisPlayViews;
    [SerializeField]
    private GameObject[] CollaboCharcters;
    [SerializeField]
    private Live_Data_Information live_Data;
    private int ChooseCollboChar = 0;


    public void UpdateDisplayView(int decideJunle)
    {
        DisPlayViews[decideJunle].SetActive(true);

        for (int i = 0; i < DisPlayViews.Length; i++)
        {
            //選択されたジャンル以外の画面はすべて非表示に
            if (i != decideJunle)
            {
                DisPlayViews[i].SetActive(false);
            }
        }

        //もしコラボ配信が選択されたら
        if (decideJunle == 5)
        {
            SetCollaboCharacter();
        }

    }

    private void SetCollaboCharacter()
    {
        //選択されたコラボキャラクターのアニメーションオブジェクトをオンに
        for (int i = 0; i < SaveData.Instance.CollaboChar_Effective.Count; i++)
        {
            if (SaveData.Instance.CollaboChar_Effective[i].OnOrOff == true)
            {
                CollaboCharcters[i].SetActive(true);
                ChooseCollboChar = i;
            }
        }

    }

    public void UpdateDisplayViewFinish()
    {
        //コラボキャラとジャンルのビューを非表示
        CollaboCharcters[ChooseCollboChar].SetActive(false);
        for (int i = 0; i < DisPlayViews.Length; i++)
        {

            DisPlayViews[i].SetActive(false);

        }
        //終了画面を表示
        DisPlayViews[6].SetActive(true);
       

    }
}
