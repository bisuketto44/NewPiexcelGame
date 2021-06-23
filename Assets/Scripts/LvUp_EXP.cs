using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//経験値バーの基礎Class
public class LvUp_EXP : MonoBehaviour
{
    //対象のスライダー
    private Slider slider;
    //経験値テーブルを作成
    [SerializeField]
    private int[] ExpTable = null;
    //最大レベル
    [SerializeField]
    private int maxLevel = 5;
    //基礎レベル
    private int defaultLevel = 1;
    //現在のレベル
    public int currentLevel;
    //経験値の基礎値
    private int BaseExp = 5000;
    //経験値テーブル作成の際の倍率
    [SerializeField]
    private float tablex = 2;
    [SerializeField]
    //現在の経験値
    private int currentExp = 0;
    [SerializeField]
    public int _comprehensiveEXP = 0;



    public void initializationEXPtables()
    {
        slider = this.gameObject.GetComponent<Slider>();
        currentLevel = defaultLevel;
        ExpTableCreate();
        UpdateVisual();
    }

    /// <summary>
    /// レベルアップのための経験値表を作成。次のレベルに上がるために必要な経験値量が、各配列に格納される。
    /// </summary>
    private void ExpTableCreate()
    {

        ExpTable = new int[maxLevel];
        for (int i = 0; i < ExpTable.Length; i++)
        {
            //経験値表をBaseExp * レベルの2乗で作成
            ExpTable[i] = Mathf.FloorToInt(BaseExp * Mathf.Pow(i + 1, tablex));

        }

    }

    //経験値バーを動かす(現在の経験値がEXPテーブルの何%で計算)
    private void UpdateVisual()
    {
        slider.value = (float)currentExp / ExpTable[currentLevel - 1];
        //Maxレベルになったら経験値バーを100%に
        if (currentLevel == maxLevel)
        {
            slider.value = 1f;
        }

    }

    /// <summary>
    /// 獲得した経験値を現在の経験値に代入し、レベルアップの経験値に達したら、余剰分を持ち越してレベルアップさせる。
    /// </summary>
    /// <param name="amount">獲得した経験値量</param>
    public void GiveExP(int amount)
    {

        if (currentLevel == maxLevel)
        {
            return;
        }

        //総合経験値を記憶
        _comprehensiveEXP += amount;
        currentExp += amount;


        //※マックスレベルになったら抜けて、メソッドが起動しないようにする必要あり
        while (currentExp > ExpTable[currentLevel - 1])
        {
            //余剰分の持ち越し
            currentExp -= ExpTable[currentLevel - 1];
            currentLevel++;
            if (currentLevel == maxLevel)
            {
                return;

            }

        }


        UpdateVisual();

    }


}
