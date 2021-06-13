using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アニメーションごとにイメージ大きさをそのサイズに合わせて変更する
public class UI_Char_SetNativeSize : MonoBehaviour
{
    Image CharImage;


    void Awake()
    {
        CharImage = this.gameObject.GetComponent<Image>();

    }

    public void ChangeToNativeSize()
    {
        CharImage.SetNativeSize();
    }

}
