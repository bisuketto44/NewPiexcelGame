using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ボタン操作で選択と決定を行えるスクリプト
public class Layout_BtnPro_BOXCS : MonoBehaviour
{
    private GameObject _ddItems;

    [Tooltip("レイアウトアイテムのローテションの関するスクリプト")]
    [SerializeField]
    Rotation_LayoutItems rotationLayoutItems;

    [SerializeField]
    Layout_Items_StoreBOX layout_Items_StoreBOX;

    private SE_Contoroller sE_Contoroller;

    void Awake()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();
    }

    //決定ボタンを押したときの処理
    public void InstansiateItems(int temp)
    {
        
        //UpDate等で変更した後の数値はもう一回UnityEditor上から見つけてくる必要がある(同じCLASS内でも)
        _ddItems = GameObject.Find("Layout_Items(DD)");
        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");
        var whatitems = GameObject.Find("Layout_Items_StoreBox").GetComponent<Layout_Items_StoreBOX>();
        var Btn2 = GameObject.FindWithTag("Layout_Btn2");

        var parent = _ddItems.transform;

        var i = Instantiate(SaveData.Instance.StoreBoxIns[temp], ThisGG.gameObject.transform.position, Quaternion.identity, parent);
        whatitems.isStoreBox[temp] = i;
        SaveData.Instance.whatBtn[temp] = true;

        //回転ボタンを非表示
        rotationLayoutItems.back();
        Destroy(ThisGG);
        Btn2.transform.GetChild(0).gameObject.SetActive(false);

        //=================================================================================
        // 配置したアイテムの場所を記憶。xとyのVector2を記憶してセーブデータ読み込み時に復元する
        //=================================================================================
        for (int s = 0; s < layout_Items_StoreBOX.isStoreBox.Length; s++)
        {
            if (SaveData.Instance.whatBtn[s] == true)
            {
                SaveData.Instance.X[s] = layout_Items_StoreBOX.isStoreBox[s].transform.localPosition.x;
                SaveData.Instance.Y[s] = layout_Items_StoreBOX.isStoreBox[s].transform.localPosition.y;

            }

        }

        sE_Contoroller.PlayDicideSound();
    }

    //レイアウトアイテムを選んだ時の処理
    public void ChooseLayoutItems(string s)
    {

        var WInd = GameObject.Find("Layout_items_Mask");
        var Btn2 = GameObject.FindWithTag("Layout_Btn2");

        //決定、しまうボタンをアクティブ化
        Btn2.transform.GetChild(0).gameObject.SetActive(true);

        switch (s)
        {
            case "BuleGuitar":
                InsChooseObj(0);
                break;
            case "ClaGuitar":
                InsChooseObj(1);
                break;
            case "Bed":
                InsChooseObj(2);
                break;
            case "Sofa":
                rotationLayoutItems.whatItems = 3;
                InsChooseObj(3);
                break;
            case "MaruTable":
                InsChooseObj(4);
                break;
            case "GlassTable":
                InsChooseObj(5);
                break;
            case "BuleLump":
                InsChooseObj(6);
                break;
            case "Dresser":
                InsChooseObj(7);
                break;
            case "FakeTree":
                InsChooseObj(8);
                break;
            case "CurPet":
                InsChooseObj(9);
                break;
            case "Shelf":
                rotationLayoutItems.whatItems = 10;
                InsChooseObj(10);
                break;
            case "TreeShelf":
                InsChooseObj(11);
                break;
            case "Drum":
                InsChooseObj(12);
                break;
            case "Mike":
                rotationLayoutItems.whatItems = 13;
                InsChooseObj(13);
                break;
            case "TV":
                rotationLayoutItems.whatItems = 14;
                InsChooseObj(14);
                break;
            case "YBOX":
                InsChooseObj(15);
                break;
            case "Wee":
                InsChooseObj(16);
                break;
            case "Qbe":
                InsChooseObj(17);
                break;
            case "Acade":
                rotationLayoutItems.whatItems = 18;
                InsChooseObj(18);
                break;
            case "Desk":
                InsChooseObj(19);
                break;
            case "Chair":
                rotationLayoutItems.whatItems = 20;
                InsChooseObj(20);
                break;

        }

        //アイテムを選んだら配置ウィンドウを自動で閉じる
        WInd.SetActive(false);


    }

    //選択オブジェクトの生成処理
    private void InsChooseObj(int temp)
    {
        //指定オブジェクト以外は回転ボタンを表示しない
        if (temp != 3 || temp != 10 || temp != 13 || temp != 14 || temp != 18 || temp != 20)
        {
            rotationLayoutItems.back();
        }

        var whatitems = GameObject.Find("Layout_Items_StoreBox").GetComponent<Layout_Items_StoreBOX>();
        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");
        var DicideBtn = GameObject.Find("Layout_Dicide_Btn").GetComponent<Button>();


        //既に選択してあったオブジェクトを解除処理して、別のオブジェクトを選択する処理
        //true = 既に別のオブジェクトを選択している状態
        if (SaveData.Instance.whatBtn[temp] == true)
        {
            //リセット
            Destroy(ThisGG);

            //実体をObjを消して、ChooseObjをその位置に再生成
            Instantiate(SaveData.Instance.StoreBox[temp], whatitems.isStoreBox[temp].transform.position, Quaternion.identity);
            Destroy(whatitems.isStoreBox[temp]);
            whatitems.isStoreBox[temp] = null;
            SaveData.Instance.whatBtn[temp] = false;
            sE_Contoroller.PlayCancelSound();

        }
        //何もない状態でオブジェクトを選択した場合の処理
        else
        {
            //選択したオブジェクトを初期位置にスポーン
            Vector2 pos = new Vector2(5, -2);
            Destroy(ThisGG);
            Instantiate(SaveData.Instance.StoreBox[temp], pos, Quaternion.identity);
            sE_Contoroller.PlayDicideSound();

        }
        //回転ボタンの表示
        rotationLayoutItems.RotationBtnAcativate(temp);
        //スタックしたイベントの初期化
        DicideBtn.onClick.RemoveAllListeners();
        //決定ボタン実行時の準備
        DicideBtn.onClick.AddListener(() => { InstansiateItems(temp); });

    }

    //しまうボタンの処理
    public void LayoutItemStore()
    {
        GameObject.FindWithTag("Layout_Dicide_Btn").GetComponent<Button>().interactable = true;
        var Btn2 = GameObject.FindWithTag("Layout_Btn2");
        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");

        //回転ボタンを非表示
        rotationLayoutItems.back();

        Btn2.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(ThisGG);

        sE_Contoroller.PlayCancelSound();

    }
}
