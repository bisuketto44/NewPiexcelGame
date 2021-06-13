using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineGrahpe : MonoBehaviour
{
    [Tooltip("グラフを表示するViewPortのRectTransFormを取得")]
    [SerializeField]
    private RectTransform m_rtView;

    [SerializeField]
    private Transform A;
    [SerializeField]
    private Transform B;

    [SerializeField]
    private Image DotImage;

    [SerializeField]
    private Image Line;

    public float fMaxY = 1000f;

    //Viewer_countCS
    [SerializeField]
    Viewer_Count NowviewerCount;

    //グラフの立幅人数テキスト
    [SerializeField]
    Text ValueText1;
    [SerializeField]
    Text ValueText2;

    //表示のためのビューポートのRectTransformを取得
    private void Awake()
    {


    }

    private GameObject CreateDot(Vector2 _position)
    {
        GameObject objDot = Instantiate(DotImage, m_rtView.transform.position, Quaternion.identity).gameObject;
        objDot.transform.SetParent(B, false);

        //色変更
        //objDot.GetComponent<Image>().color = Color.black;

        RectTransform rtDot = objDot.GetComponent<RectTransform>();
        //生成した点のアンカー基準点に対する相対的なピポット(中心点)を決定
        rtDot.anchoredPosition = _position;
        //生成した点の大きさを決定
        rtDot.sizeDelta = new Vector2(6.0f, 6.0f);
        //アンカーのminとmaxを決定(基本は0.5?)
        rtDot.anchorMin = Vector2.zero;
        rtDot.anchorMax = Vector2.zero;

        //作成した点を返す
        return objDot;
    }

    public void ShowGraph(List<int> _dataList)
    {
        //ビューポートの高さ
        float fGraphHeight = m_rtView.sizeDelta.y;

        //入力数値の最大値(最大値を下回るまで足す)
        while (NowviewerCount._nowViewerCount > fMaxY)
        {
            fMaxY += 1000f;

        }
        ValueText1.text = (fMaxY / 1000).ToString() + "K";
        ValueText2.text = ((fMaxY / 1000) / 2).ToString() + "K";

        //隣の点までの距離
        float fPitchX = 30f;
        //最初の点とビューポートのX(0)からの距離(表示の基準点)
        float fOffsetX = 15f;

        //ひとつ前の点を保存するために初期化
        GameObject objLast = null;

        for (int i = 0; i < _dataList.Count; i++)
        {
            //横から順番に並べて、データの数*横方向 + オフセット分
            float fPosX = (i * fPitchX) + fOffsetX;
            //最大値 = ビューポートサイズYの最大値として正規化して表示
            float fPosY = (_dataList[i] / fMaxY) * fGraphHeight;

            //新たな点を作成するたびに代入
            GameObject objDot = CreateDot(new Vector2(fPosX, fPosY));

            //もし2点が存在した場合は
            if (objLast != null)
            {
                //PointA & PointBを代入。A(ObjLast)の位置に線を生成
                CreateLine(objLast.GetComponent<RectTransform>().anchoredPosition, objDot.GetComponent<RectTransform>().anchoredPosition);
            }
            //次の点に移る前に今回の点を前回の点として保存
            objLast = objDot;
        }


    }

    private void CreateLine(Vector2 _pointA, Vector2 _pointB)
    {
        GameObject objLine = Instantiate(Line, m_rtView.transform.position, Quaternion.identity).gameObject;
        objLine.transform.SetParent(A, false);

        RectTransform rtLine = objLine.GetComponent<RectTransform>();
        //objLine.GetComponent<Image>().color = Color.black;

        //2点のベクトル(向き)を取得
        Vector2 dir = (_pointB - _pointA).normalized;
        //2点の距離を取得
        float fDistance = Vector2.Distance(_pointA, _pointB);

        //直線の傾き(オイラー角)として、X,Yが0,Z軸(傾き)を指定方向+ベクトルで傾きを出してくれるSignedAngleでとってきて代入
        rtLine.localEulerAngles = new Vector3(0f, 0f, Vector2.SignedAngle(new Vector2(1f, 0f), dir));

        rtLine.anchorMax = Vector2.zero;
        rtLine.anchorMin = Vector2.zero;
        //線の長さを決定(長さ=2点の距離,太さ5f)
        rtLine.sizeDelta = new Vector2(fDistance, 2f);

        //A→Bに向けた線だけだと繋がらないので、線をAとBの間に配置することで二つを繋げたように見せる
        rtLine.anchoredPosition = _pointA + (dir * fDistance * 0.5f);
    }

    public void TextRset()
    {
        ValueText1.text = "1K";
        ValueText2.text = "0.5K";
        fMaxY = 1000;

    }

}
