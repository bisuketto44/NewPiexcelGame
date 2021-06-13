using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Conditions : MonoBehaviour
{
    [Tooltip("ショップの商品テキスト")]
    [SerializeField]
    public Text[] Shop_Goods_Texts;

    [Tooltip("商品のアイコンを表示する背景パネル")]
    [SerializeField]
    public Image[] Shop_Icon_Panels;

    [Tooltip("商品のアイコン")]
    [SerializeField]
    public Image[] Shop_Goods_Icons;

    [Tooltip("商品のボタン")]
    [SerializeField]
    public Button[] Shop_Buttons;

    [Tooltip("スタイルキットの残りカウント 6*25pt分")]
    public int StyleKitCount = 150;

    [Tooltip("コインイメージ")]
    [SerializeField]
    GameObject[] CoinImages;


    /// <summary>
    /// 商品買うまたは、規定数買うと商品ボタンをインアクティブにするメソッド
    /// </summary>
    /// <param name= "WhichBtn">どのボタンが選択されたかを判別する引数</param>
    public void InActivateShopBtns(int WhichBtn, int quantity)
    {
        if (WhichBtn == 21 && StyleKitCount != 0)
        {
            //個数を引く
            StyleKitCount -= quantity;

            if (StyleKitCount == 0)
            {
                Shop_Goods_Texts[WhichBtn].alignment = TextAnchor.MiddleCenter;
                Shop_Goods_Texts[WhichBtn].lineSpacing = 1;
                Shop_Goods_Texts[WhichBtn].text = "売り切れです";

                //アイコンとパネルの色を落とす
                Shop_Goods_Icons[WhichBtn].color = new Color32(255, 255, 255, 130);
                Shop_Icon_Panels[WhichBtn].color = new Color32(180, 183, 188, 100);

                //コインイメージを消去
                CoinImages[WhichBtn].SetActive(false);

                //ボタン機能を無効化
                Shop_Buttons[WhichBtn].interactable = false;

            }
            return;
        }
        else
        {
            //既存のテキストを売り切れ表示に変更
            //縦方向の並びを中央に(インスペクターでいう右側)
            Shop_Goods_Texts[WhichBtn].alignment = TextAnchor.MiddleCenter;
            Shop_Goods_Texts[WhichBtn].lineSpacing = 1;
            Shop_Goods_Texts[WhichBtn].text = "売り切れです";

            //アイコンとパネルの色を落とす
            Shop_Goods_Icons[WhichBtn].color = new Color32(255, 255, 255, 130);
            Shop_Icon_Panels[WhichBtn].color = new Color32(180, 183, 188, 100);

            //コインイメージを消去
            CoinImages[WhichBtn].SetActive(false);

            //ボタン機能を無効化
            Shop_Buttons[WhichBtn].interactable = false;

        }




    }


}
