using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRotation : MonoBehaviour
{

    [SerializeField]
    GameObject Text1;
    [SerializeField]
    GameObject Text2;

    RectTransform T1;
    RectTransform T2;

    float a1;
    float a2;

    float textWidth;

    void Awake()
    {
        //横サイズを取得
        textWidth = Text1.GetComponent<Text>().preferredWidth;

        T1 = Text1.GetComponent<RectTransform>();
        T2 = Text2.GetComponent<RectTransform>();

        T2.localPosition = new Vector2(textWidth + 230f, 0);
        Debug.Log(textWidth);

        a1 = T1.localPosition.x;
        a2 = T2.localPosition.x;
    }

    void Update()
    {

        //少しづつ移動
        T1.transform.Translate(Vector2.left * 1f * Time.deltaTime);
        T2.transform.Translate(Vector2.left * 1f * Time.deltaTime);


        //オブジェクトがしていい位置に来たらリセット
        if (T1.gameObject.transform.localPosition.x < -textWidth)
        {
            T1.localPosition = new Vector2(textWidth, 0);
        }
        if (T2.gameObject.transform.localPosition.x < -textWidth)
        {
            T2.localPosition = new Vector2(textWidth, 0);
        }


    }
}
