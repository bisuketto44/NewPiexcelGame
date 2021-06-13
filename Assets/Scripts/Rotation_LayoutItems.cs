using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_LayoutItems : MonoBehaviour
{
    //この変数にどのアイテムを表示するかを決定させる(3(sofa),20(chair),18(acade),14(TV),13(Mike),10(bookshelf))


    [System.NonSerialized]
    public int whatItems = 0;

    private int countMax = 0;
    private int count = 0;


    [SerializeField]
    GameObject[] Sofa;
    [SerializeField]
    GameObject[] SofaIns;

    [SerializeField]
    GameObject[] BookShelf;
    [SerializeField]
    GameObject[] BookShelfIns;

    [SerializeField]
    GameObject[] Mike;
    [SerializeField]
    GameObject[] Mikeins;

    [SerializeField]
    GameObject[] TV;
    [SerializeField]
    GameObject[] TVIns;

    [SerializeField]
    GameObject[] Acade;
    [SerializeField]
    GameObject[] AcadeIns;

    [SerializeField]
    GameObject[] Chair;
    [SerializeField]
    GameObject[] ChairIns;

    private GameObject[] LayoutIndex;
    private GameObject[] InsLayoutIndex;


    public void RotationBtnAcativate(int temp)
    {

        if (temp == 3 || temp == 10 || temp == 13 || temp == 14 || temp == 18 || temp == 20)
        {
            this.gameObject.SetActive(true);
            //max値を決定
            DeicideCountMax();
            //どの配列(ゲームオブジェクトにアクセスするかを決定)
            ReturnIndex();
            ReturnIndexIns();
            
        }

        return;

    }

    public void back()
    {
        this.gameObject.SetActive(false);
    }

    public void RotationItemsDicide()
    {
        var whatITEM = GameObject.Find("Layout_Items_StoreBox").GetComponent<Layout_Items_StoreBOX>();
        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");
        count++;

        //最初にリセット
        if (count > countMax)
        {
            count = 0;
        }

        //現在掴んでるアイテムを破棄
        Destroy(ThisGG);

        //呼び出したときに持ってくるレイアウトアイテムを回転したバージョンに書き換える
        whatITEM.StoreBox[whatItems] = null;

        //生成するレイアウトアイテムを変更
        whatITEM.StoreBox[whatItems] = LayoutIndex[count];

        //書き換えた後のレイアウトアイテムを元の選択オブジェクトの位置に生成
        Instantiate(whatITEM.StoreBox[whatItems], ThisGG.gameObject.transform.position, Quaternion.identity);

        whatITEM.StoreBoxIns[whatItems] = null;
        //決定ボタン時に生成するインスタンスオブジェクトを回転後のオブジェクトに変更 
        whatITEM.StoreBoxIns[whatItems] = InsLayoutIndex[count];


    }

    public void ReturnIndex()
    {
        switch (whatItems)
        {
            case 3:
                LayoutIndex = Sofa;
                break;
            case 10:
                LayoutIndex = BookShelf;
                break;
            case 13:
                LayoutIndex = Mike;
                break;
            case 14:
                LayoutIndex = TV;
                break;
            case 18:
                LayoutIndex = Acade;
                break;
            case 20:
                LayoutIndex = Chair;
                break;

        }

    }

    public void ReturnIndexIns()
    {
        switch (whatItems)
        {
            case 3:
                InsLayoutIndex = SofaIns;
                break;
            case 10:
                InsLayoutIndex = BookShelfIns;
                break;
            case 13:
                InsLayoutIndex = Mikeins;
                break;
            case 14:
                InsLayoutIndex = TVIns;
                break;
            case 18:
                InsLayoutIndex = AcadeIns;
                break;
            case 20:
                InsLayoutIndex = ChairIns;
                break;

        }

    }

    private void DeicideCountMax()
    {
        //配列の最大数を決定
        switch (whatItems)
        {
            case 3:
                countMax = 3;
                break;
            case 10:
                countMax = 2;
                break;
            case 13:
                countMax = 2;
                break;
            case 14:
                countMax = 3;
                break;
            case 18:
                countMax = 3;
                break;
            case 20:
                countMax = 1;
                break;

        }

    }

}
