using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyContoroller : MonoBehaviour
{
    public int PossesedMoney = 0;

    [Tooltip("所持金を表示するテキスト")]
    [SerializeField]
    private Text MoneyText;

    void Awake()
    {
        PossesedMoney = 0;
    }

    //お金を使う
    public void SpendMoney(int spendmoney)
    {
        PossesedMoney -= spendmoney;
        MoneyText.text = PossesedMoney.ToString("N0");
    }

    //お金を増やす
    public void GainMoney(int gainmoney)
    {
        PossesedMoney += gainmoney;
        MoneyText.text = PossesedMoney.ToString("N0");
    }
}
