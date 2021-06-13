using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGrahpeContoroller : MonoBehaviour
{
    [SerializeField]
    private LineGrahpe lineGraphs;

    [Tooltip("Aの中身")]
    [SerializeField]
    GameObject A;

    [Tooltip("Bの中身")]
    [SerializeField]
    GameObject B;

    //視聴者数のデータ
    List<int> testData;

    void Awake()
    {
        testData = new List<int>();

    }

    public void UpdateLineGraph(int AddNum)
    {
        //データを追加
        testData.Add(AddNum);

        //描画更新
        foreach (Transform Grahps in A.transform)
        {
            Destroy(Grahps.gameObject);
        }
        foreach (Transform Grahps in B.transform)
        {
            Destroy(Grahps.gameObject);
        }
        //リセットして最初の配列を削除
        if (testData.Count == 7)
        {
            testData.RemoveAt(0);
        }
        //描画を更新
        lineGraphs.ShowGraph(testData);

    }
    
    //グラフを完全リセット
    public void ResetGrahpe()
    {
        foreach (Transform Grahps in A.transform)
        {
            Destroy(Grahps.gameObject);
        }
        foreach (Transform Grahps in B.transform)
        {
            Destroy(Grahps.gameObject);
        }
        testData.Clear();

    }
}
