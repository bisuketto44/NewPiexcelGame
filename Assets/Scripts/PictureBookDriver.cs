using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureBookDriver : MonoBehaviour
{
    [Tooltip("表示するコンテントパネル")]
    [SerializeField]
    private GameObject[] ContentPanels;

    private int _Currentpanel;

    List<RectTransform> TextList = new List<RectTransform>();

    [SerializeField]
    private RectTransform[] TextS;

    Vector3 Velocity;

    private bool left;
    private bool right;

    private SE_Contoroller sE_Contoroller;
    

    void Awake()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();

        _Currentpanel = 0;

        for (int i = 0; i < TextS.Length; i++)
        {
            TextList.Add(TextS[i]);
        }

        Velocity = Vector3.zero;

    }

    void Update()
    {
        if (left == true)
        {
            //文字の数指定方向にスライドさせる
            for (int i = 0; i < TextList.Count; i++)
            {
                var pos = TextList[i].transform.localPosition;
                TextList[i].transform.Translate(Vector3.right * 200f * Time.deltaTime);
            }
            //末尾がスライド仕切ったら位置をリセットし、先頭と末尾を入れ替える
            if (TextList[TextList.Count - 1].transform.localPosition.x > 500)
            {
                //コピー
                var obj = TextList[TextList.Count - 1];
                TextList.RemoveAt(TextList.Count - 1);
                TextList.Insert(0, obj);
                //位置がずれない様に初期化
                //0 = 先頭
                TextList[0].transform.localPosition = new Vector3(-250, 0, 0);
                //1 = 表示させたいテキスト
                TextList[1].transform.localPosition = new Vector3(0, 0, 0);
                //末尾
                TextList[TextList.Count - 1].transform.localPosition = new Vector3(250, 0, 0);

                left = false;

            }


        }
        else if (right == true)
        {

            //文字の数指定方向にスライドさせる
            for (int i = 0; i < TextList.Count; i++)
            {
                var pos = TextList[i].transform.localPosition;
                TextList[i].transform.Translate(Vector3.left * 200f * Time.deltaTime);
            }
            //末尾がスライド仕切ったら位置をリセットし、先頭と末尾を入れ替える
            if (TextList[0].transform.localPosition.x < -500)
            {
                //コピー
                var obj = TextList[0];
                TextList.RemoveAt(0);
                TextList.Add(obj);
                //位置がずれない様に初期化
                //0 = 先頭
                TextList[0].transform.localPosition = new Vector3(-250, 0, 0);
                //1 = 表示させたいテキスト
                TextList[1].transform.localPosition = new Vector3(0, 0, 0);
                //末尾
                TextList[TextList.Count - 1].transform.localPosition = new Vector3(250, 0, 0);

                right = false;

            }

        }

    }

    public void ChangePanel(int num)
    {
        _Currentpanel += num;
        //配列のサイズの上限や下限を超える場合は一周回るように
        //例 : 0の左は3  3の右は0
        if (_Currentpanel > (ContentPanels.Length - 1))
        {
            _Currentpanel = 0;
        }
        else if (_Currentpanel < 0)
        {
            _Currentpanel = (ContentPanels.Length - 1);
        }
        Debug.Log(_Currentpanel);

        //非表示
        for (int i = 0; i < ContentPanels.Length; i++)
        {
            ContentPanels[i].SetActive(false);
        }
        //表示
        ContentPanels[_Currentpanel].SetActive(true);


        //文字をスライドするためのメソッドを呼ぶ
        SlideInOutText(num);
        sE_Contoroller.PlayDicideSound();

    }

    //Update関数内でスライドを開始
    private void SlideInOutText(int num)
    {
        //リストで管理
        if (num < 0)
        {

            left = true;

        }
        else
        {
            right = true;

        }

    }



}
