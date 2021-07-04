using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live_Attribute_Window : MonoBehaviour
{
    private Item_DataBase dataBase;
    private Item_Purchase btn;
    private int quantity = 1;

    private SE_Contoroller sE_Contoroller;

    void Awake()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();
    }

    //Open the window
    public void ActivateWindow()
    {

        this.gameObject.SetActive(true);
        sE_Contoroller.PlayDicideSound();

    }

    //Closed the window
    public void InActivateWindow()
    {

        this.gameObject.SetActive(false);
        sE_Contoroller.PlayCancelSound();
    }


    //below method is for ShopBtn
    public void Shop_Btn_Click(string s)
    {

        this.gameObject.SetActive(true);


        switch (s)
        {
            case "BuleGuitar":
                GetItems(0);
                break;
            case "ClaGuitar":
                GetItems(1);
                break;
            case "Bed":
                GetItems(2);
                break;
            case "Sofa":
                GetItems(3);
                break;
            case "MaruTable":
                GetItems(4);
                break;
            case "GlassTable":
                GetItems(5);
                break;
            case "BuleLump":
                GetItems(6);
                break;
            case "Dresser":
                GetItems(7);
                break;
            case "FakeTree":
                GetItems(8);
                break;
            case "CurPet":
                GetItems(9);
                break;
            case "Shelf":
                GetItems(10);
                break;
            case "TreeShelf":
                GetItems(11);
                break;
            case "Drum":
                GetItems(12);
                break;
            case "Mike":
                GetItems(13);
                break;
            case "TV":
                GetItems(14);
                break;
            case "YBOX":
                GetItems(15);
                break;
            case "Wee":
                GetItems(16);
                break;
            case "Qbe":
                GetItems(17);
                break;
            case "Acade":
                GetItems(18);
                break;
            case "PCone":
                GetItems(19);
                break;
            case "PCtwo":
                GetItems(20);
                break;
            case "StyleKit":
                GetItems(21);
                break;
        }

        sE_Contoroller.PlayDicideSound();
    }

    public void Shop_Btn_Chancel()
    {
        Button shop_diceide_btn = GameObject.Find("Purchase_Btn").GetComponent<Button>();
        GameObject iconPanel = GameObject.Find("ShopDceide_Icon_Panel");

        //個数Tabを閉じる。Textを１個目にリセットする
        GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.GetComponent<Text>().text = "購入数 : 1";
        GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindWithTag("QuantityPanel").transform.GetChild(0).gameObject.SetActive(false);

        sE_Contoroller.PlayCancelSound();

        Destroy(iconPanel.transform.GetChild(0).gameObject);
        this.gameObject.SetActive(false);



        //if canclebtn is tapped , btnEvent is all reset　中身を破棄
        shop_diceide_btn.onClick.RemoveAllListeners();

    }

    private void GetItems(int num)
    {
        Image iconPanel = GameObject.Find("ShopDceide_Icon_Panel").GetComponent<Image>();
        Text nameText = GameObject.Find("ShopDceide_Name_Text").GetComponent<Text>();
        Text descText = GameObject.Find("ShopDceide_Desc_Text").GetComponent<Text>();
        Text costText = GameObject.Find("ShopDceide_Cost_Text").GetComponent<Text>();
        Text ExpText = GameObject.Find("ShopDceide_Exp_Text").GetComponent<Text>();
        dataBase = GameObject.Find("ItemS_DataBase").GetComponent<Item_DataBase>();

        btn = GameObject.Find("ItemS_DataBase").GetComponent<Item_Purchase>();
        Button shop_diceide_btn = GameObject.Find("Purchase_Btn").GetComponent<Button>();

        nameText.text = dataBase.items[num].itemNameJP;
        descText.text = dataBase.items[num].itemDesc;
        ExpText.text = dataBase.items[num].ItemExplanation;
        costText.text = dataBase.items[num].cost.ToString("N0");

        var parent = iconPanel.transform;
        //第四引数で親として設定
        Instantiate(dataBase.items[num].itemIcon, parent.position, Quaternion.identity, parent);
        int temp = num;

        //スタイルキットが選択された場合は個数選択ができるようにquantityを調整
        if (temp == 21)
        {
            //選べる個数は最低1個以上。テキストは1個目からリセットしておく。
            quantity = 1;
            GameObject.FindWithTag("QuantityPanel").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.GetComponent<Text>().text = "購入数 : 1";

        }
        //それ以外は第二引数は無視
        else
        {
            quantity = 1;

        }
        //Activate PuerchaseItms() = ボタンを押したら次の関数を実行したときに右のものを実行(複数個スタックする)
        shop_diceide_btn.onClick.AddListener(() => { btn.PurchaseItems(temp, quantity); });

    }

    //個数選択ボタン
    public void QuantityPulsBtn()
    {
        var shopCondi = GameObject.FindWithTag("Shop_Controller").GetComponent<Shop_Conditions>();
        sE_Contoroller.PlayDicideSound();

        //購入上限は1個~キットの残り個数まで
        quantity = Mathf.Clamp(quantity + 1, 1, shopCondi.StyleKitCount);

        GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.GetComponent<Text>().text = "購入数 : " + quantity.ToString();

        Text costText = GameObject.Find("ShopDceide_Cost_Text").GetComponent<Text>();
        costText.text = (dataBase.items[21].cost * quantity).ToString("N0");

    }
    public void QuantityminasBtn()
    {
        var shopCondi = GameObject.FindWithTag("Shop_Controller").GetComponent<Shop_Conditions>();
        sE_Contoroller.PlayDicideSound();

        //購入下限は1個~キットの残り個数まで
        quantity = Mathf.Clamp(quantity - 1, 1, shopCondi.StyleKitCount);
        GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.GetComponent<Text>().text = "購入数 : " + quantity.ToString();

        Text costText = GameObject.Find("ShopDceide_Cost_Text").GetComponent<Text>();
        costText.text = (dataBase.items[21].cost * quantity).ToString("N0");

    }


}
