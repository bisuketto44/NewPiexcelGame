using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//長押しで選択中にできるスクリプト
public class Layout_InsItems : MonoBehaviour
{

    private bool can = false;
    private bool once = true;
    private float temptime = 0;
    public int tempindex = 100;

    private GameObject UITimerObject;
    private GameObject rotatin;

    void Awake()
    {
        rotatin = GameObject.FindWithTag("rotation");

    }

    // Update is called once per frame
    void Update()
    {
        if (can == true)
        {

            temptime += Time.deltaTime;
            if (temptime > 0.9f && once == true)
            {
                var whatitems = GameObject.Find("Layout_Items_StoreBox").GetComponent<Layout_Items_StoreBOX>();
                var Btn2 = GameObject.FindWithTag("Layout_Btn2");
                var Ins = GameObject.FindWithTag("LayoutBtn_StoreBOX").GetComponent<Layout_BtnPro_BOXCS>();


                //レイアウトボタン用のアイテムを表示する
                Btn2.transform.GetChild(0).gameObject.SetActive(true);

                //選択オブジェクトへ置換
                Instantiate(whatitems.StoreBox[tempindex], whatitems.isStoreBox[tempindex].transform.position, Quaternion.identity);

                whatitems.isStoreBox[tempindex] = null;
                whatitems.whatBtn[tempindex] = false;

                //回転用の処理
                if (tempindex == 3 || tempindex == 10 || tempindex == 13 || tempindex == 14 || tempindex == 18 || tempindex == 20)
                {

                    rotatin.SetActive(true);
                    //ローテーションに情報を渡す
                    rotatin.GetComponent<Rotation_LayoutItems>().whatItems = tempindex;
                    rotatin.GetComponent<Rotation_LayoutItems>().RotationBtnAcativate(tempindex);

                }

                //一回初期化してからイベントリスナーへ選択したアイテムを決定を送る
                var DicideBtn = GameObject.Find("Layout_Dicide_Btn").GetComponent<Button>();
                DicideBtn.onClick.RemoveAllListeners();
                DicideBtn.onClick.AddListener(() => { Ins.InstansiateItems(tempindex); });

                //アイテム選択中に別のアイテムを選択できないようにbool設定
                once = false;

                //選択オブジェクトを生成したので、実態オブジェクトのほうは破棄。このスクリプトも呼ばれなくなる。
                Destroy(this.gameObject);
                Destroy(UITimerObject);

            }


        }

    }

    public void LayoutStoreDown(int temp)
    {
        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");
        //ヒエラルキー上に選択中のオブジェクトがあれば無効
        if (ThisGG == null)
        {
            can = true;
            //設置したアイテムを長押ししたらその引数を流し込む
            tempindex = temp;

            //アニメーション用のオブジェクトを生成
            var UITimerObjectTemp = Resources.Load<GameObject>("UI_Timer");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UITimerObject = Instantiate(UITimerObjectTemp, mousePosition, Quaternion.identity);

        }

    }

    public void LayoutStoreUp()
    {
        can = false;
        temptime = 0f;
        Destroy(UITimerObject);
    }



}
