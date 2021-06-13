using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MainシーンのItemDatabaseオブジェクトに付属
//LayoutシーンのItemsDatabseオブジェクトに付属
public class Item_Purchase : MonoBehaviour
{
    //Itemインベントリのアイテムはボタンで作成。購入されると随時表示されていく仕様
    [SerializeField]
    private Button[] _isItems;

    //アイテムを購入しましたというGUIを表示
    [SerializeField]
    private GameObject _done;

    //Windowを消すためと生成したSHOPでのアイテムアイコンを消すため
    private GameObject _dicideItemsWind;
    private GameObject _iconPanel;

    [Tooltip("配信強化状況の一覧(アイテムの効果のオンのために使用)")]
    [SerializeField]
    private Live_Data_Information LiveData;

    [Tooltip("アイテム情報を取り扱うスクリプト")]
    [SerializeField]
    Item_DataBase itemdatabase;

    [Tooltip("ショップの状態を管理するスクリプトを呼ぶ")]
    [SerializeField]
    private Shop_Conditions ShopCondition;

    [Tooltip("スタイルキットを何個所持しているかを表示するテキスト")]
    [SerializeField]
    private Text StyleKitCountText;

    [Tooltip("スタイルステータスを管理するオブジェクト")]
    [SerializeField]
    private Style_Status_Management StyleStatusManager;

    [Tooltip("マネーシステムをコントロールするスクリプト")]
    [SerializeField]
    MoneyContoroller moneycontoroller;

    [Tooltip("所持金が足りませんパネルを表示する")]
    [SerializeField]
    GameObject CantPuerChasePannelObje;

    [Tooltip("効果テキストをアップデートする")]
    [SerializeField]
    ItemEffective_VisulalUpdate itemEffective_VisulalUpdate;

    private int StyleKitCountInt = 0;

    public bool boolPC1 = false;
    public bool boolPC2 = false;


    public void PurchaseItems(int temp, int quantity)
    {
        //必要な値段を計算し、その値段分の所持金があれば通す。
        //所持金がなければretrunして、警告ウィンドウを表示する。
        if (moneycontoroller.PossesedMoney < (itemdatabase.items[temp].cost * quantity))
        {
            CantPuerChasePannelObje.SetActive(true);
            return;
        }
        else
        {
            //費用を所持金から引く
            var costAmount = (itemdatabase.items[temp].cost * quantity);
            moneycontoroller.SpendMoney(costAmount);

        }

        _dicideItemsWind = GameObject.Find("Shop_Diceide");
        _iconPanel = GameObject.Find("ShopDceide_Icon_Panel");
        var MainSceneManager = GameObject.FindWithTag("MainSceneManager").GetComponent<MainScene>();
        Button shop_diceide_btn = GameObject.Find("Purchase_Btn").GetComponent<Button>();

        //個数選択テキストを非表示に
        GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.GetComponent<Text>().text = "購入数 : 1";
        GameObject.FindWithTag("QuantityText").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindWithTag("QuantityPanel").transform.GetChild(0).gameObject.SetActive(false);

        if (_iconPanel != null)
        {
            Destroy(_iconPanel.transform.GetChild(0).gameObject);
        }
        if (_dicideItemsWind != null)
        {
            _dicideItemsWind.SetActive(false);
        }
        if (_done != null)
        {
            //購入しましたGUIを表示。別ボタンで非表示にする。
            _done.SetActive(true);
        }

        //アイテムBOX内のアイテムをactive化(ここでアイテムインベントリ内のアイテムを管理)
        _isItems[temp].gameObject.SetActive(true);

        //配列が19じゃないかつ20じゃない = 19か20か21以外なら以下を実行
        if (temp != 19 && temp != 20 && temp != 21)
        {
            //LayoutSceneにどのアイテム(配列の何番目)を買ったかをpassするためにフラグを管理(MainScene.csで使用)
            MainSceneManager.JudgeArray[temp] = true;
        }

        //使用したイベントリスナーは削除しておかないとスタックするので削除(成功時でも)
        shop_diceide_btn.onClick.RemoveAllListeners();

        //アイテム効果をONに(スタイル強化キット以外)
        if (temp != 21)
        {
            LiveData.ItemsEffective[temp].OnOrOff = true;
        }

        //スタイルキットの個数テキストを更新
        if (temp == 21 && quantity != 0)
        {
            StyleKitCountInt += quantity;
            StyleKitCountText.text = "×" + StyleKitCountInt.ToString();
            StyleStatusManager.StylePointApply(quantity);

        }

        //PCアップデート
        if (temp == 19)
        {
            ActivatePC1();
        }
        if (temp == 20)
        {
            ActivatePC2();
        }

        //アイテムが売り切れかどうかを判定するメソッドに値を飛ばす
        ShopCondition.InActivateShopBtns(temp, quantity);

        //購入したアイテムの効果の累計価テキストを表示する
        itemEffective_VisulalUpdate.UpdateRatioTexts();


    }



    private void ActivatePC1()
    {
        if (GameObject.Find("Stream_Desk_Ins(Clone)") != null)
        {
            GameObject.Find("Stream_Desk_Ins(Clone)").transform.GetChild(1).gameObject.SetActive(true);
        }
        boolPC1 = true;

    }

    private void ActivatePC2()
    {
        if (GameObject.Find("Stream_Desk_Ins(Clone)") != null)
        {
            GameObject.Find("Stream_Desk_Ins(Clone)").transform.GetChild(2).gameObject.SetActive(true);

        }
        boolPC2 = true;

    }

}


