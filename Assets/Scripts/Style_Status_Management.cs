using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Style_Status_Management : MonoBehaviour
{
    [Tooltip("現在の各ステータス状況")]
    public int[] StyleSatus;

    [Tooltip("現在所持しているMAXのスタイルポイント(=所持しているスタイルキットの数)")]
    public int MaxStylePoint;

    [Tooltip("残りのスタイル強化ポイント")]
    public int LeftStylePoint;

    [Tooltip("残りのスタイル強化ポイントを表示するText")]
    [SerializeField]
    private Text LeftStylePointText;

    [Tooltip("各スタイルの現在のポイントを表示するテキスト")]
    [SerializeField]
    private Text[] StyleStatusText;

    [Tooltip("各スタイルを強化するためのボタン")]
    [SerializeField]
    private Button[] StyleUpBtn;

    [Tooltip("各レベルごとのスタイルによる強化テーブル")]
    [SerializeField]
    private int[] Style_LiveEnhance_Value;

    [Tooltip("スタイルの強化状況の反映")]
    [SerializeField]
    private Live_Data_Information LiveData;

    [Tooltip("レーダーチャートの値を変更するスクリプトを取得する")]
    [SerializeField]
    private Activate_RaderChart RaderChart;

    private SE_Contoroller sE_Contoroller;

    [SerializeField]
    Item_Purchase item_Purchase;


    void OnEnable()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();

        //スタイルのレベルを全部0で初期化
        StyleSatus = new int[] { 0, 0, 0, 0, 0, 0 };

        LeftStylePoint = 0;

        //最初はボタンを使用できないように
        for (int i = 0; i < StyleUpBtn.Length; i++)
        {
            StyleUpBtn[i].interactable = false;
        }

        //スタイルの強化テーブルを初期化
        Style_LiveEnhance_Value = new int[] { 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 245, 250 };

    }

    //スタイルキットの購入を反映する
    public void StylePointApply(int StyleKitPurchase)
    {
        //現在所持しているスタイルポイントの総値を更新
        MaxStylePoint += StyleKitPurchase;

        //購入したスタイルポイントを残りのポイントに追加
        LeftStylePoint += StyleKitPurchase;
        LeftStylePointText.text = "残りポイント : " + LeftStylePoint.ToString();
        Debug.Log(LeftStylePoint);

        //新しくスタイルポイントを獲得した場合、レベルがカンストしているスタイルを除きボタンを有効化
        for (int i = 0; i < StyleUpBtn.Length; i++)
        {
            if (StyleSatus[i] != 25)
            {
                StyleUpBtn[i].interactable = true;
            }

        }

    }

    //スタイルUPボタンでスタイルのレベルを上げる。
    public void StyleEnhanceBtn(int whichStyle)
    {

        //レベルを1UPしてテキストに反映、データを保存
        StyleSatus[whichStyle] += 1;
        StyleStatusText[whichStyle].text = StyleSatus[whichStyle].ToString() + "/25";

        //レーダーチャートの数値を変動
        RaderChart.StyleUpRaderChart(whichStyle);

        //スタイルポイントを消費
        LeftStylePoint--;
        LeftStylePointText.text = "残りポイント : " + LeftStylePoint.ToString();

        //もし残りのポイントが0ならボタンを使用不可に
        if (LeftStylePoint == 0)
        {
            for (int i = 0; i < StyleUpBtn.Length; i++)
            {
                StyleUpBtn[i].interactable = false;
            }
        }
        //あるいは、スタイルレベルがカンストしたらそのスタイルUPボタンを使用不可に
        else if (StyleSatus[whichStyle] == 25)
        {
            StyleUpBtn[whichStyle].interactable = false;
        }

        //リストの強化状況に、現在のスタイルのレベルに合わせたValueをセットしてあげる
        SaveData.Instance.Style_Effective[whichStyle].BaseIncrease = Style_LiveEnhance_Value[StyleSatus[whichStyle] - 1];

        if (item_Purchase.isloadDone == true)
        {
            sE_Contoroller.PlayDicideSound();
        }


    }

    public void StylePointReSetBtn()
    {
        //0ポイントの時はリセットボタンの効力を無くす
        if (MaxStylePoint <= 0)
        {
            return;
        }
        //全値をリセット
        for (int i = 0; i < StyleSatus.Length; i++)
        {
            StyleSatus[i] = 0;
            StyleStatusText[i].text = "0/25";
            LeftStylePoint = MaxStylePoint;
            LeftStylePointText.text = "残りポイント : " + LeftStylePoint.ToString();
            StyleUpBtn[i].interactable = true;

            //レーダーチャートを初期化
            RaderChart.ReSetStyleRedaerChart();

            //初期効果に戻す
            SaveData.Instance.Style_Effective[i].BaseIncrease = 10;

        }
        sE_Contoroller.PlayCancelSound();

    }
}
