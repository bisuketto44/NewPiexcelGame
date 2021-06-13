using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_RaderChart : MonoBehaviour
{
    [Tooltip("実際にメッシュを生成するスクリプト")]
    [SerializeField]
    private Style_Status_RaderChart_DinamicMesh RaderChartScript;

    //レーダーチャート生成のための数値を変動する基礎Class
    Style_Status_RaderChart RaderChartBaseClass;

    // レーダーチャートを初期化
    void Start()
    {
        RaderChartBaseClass = new Style_Status_RaderChart(1, 1, 1, 1, 1, 1);
        RaderChartScript.SetStats(RaderChartBaseClass);

    }

    //レーダーチャートをリセットして初期化
    public void ReSetStyleRedaerChart()
    {
        RaderChartBaseClass = new Style_Status_RaderChart(1, 1, 1, 1, 1, 1);
        RaderChartScript.SetStats(RaderChartBaseClass);
    }

    public void StyleUpRaderChart(int WhichStyle)
    {
        switch (WhichStyle)
        {
            case 0:
                RaderChartBaseClass.Increase(Style_Status_RaderChart.Type.Serious);
                RaderChartScript.SetStats(RaderChartBaseClass);
                break;
            case 1:
                RaderChartBaseClass.Increase(Style_Status_RaderChart.Type.Funy);
                RaderChartScript.SetStats(RaderChartBaseClass);
                break;
            case 2:
                RaderChartBaseClass.Increase(Style_Status_RaderChart.Type.Eros);
                RaderChartScript.SetStats(RaderChartBaseClass);
                break;
            case 3:
                RaderChartBaseClass.Increase(Style_Status_RaderChart.Type.Flames);
                RaderChartScript.SetStats(RaderChartBaseClass);
                break;
            case 4:
                RaderChartBaseClass.Increase(Style_Status_RaderChart.Type.Cute);
                RaderChartScript.SetStats(RaderChartBaseClass);
                break;
            case 5:
                RaderChartBaseClass.Increase(Style_Status_RaderChart.Type.Crazy);
                RaderChartScript.SetStats(RaderChartBaseClass);
                break;
        }

    }


}
