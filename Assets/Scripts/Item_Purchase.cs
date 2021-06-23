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

    [Tooltip("ViewerCountのスクリプト")]
    [SerializeField]
    Viewer_Count viewer_Count;

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

    [Tooltip("やる気の回復と消費に関するスクリプト")]
    [SerializeField]
    Motivation_Contoroller motivation_Contoroller;

    public bool boolPC1 = false;
    public bool boolPC2 = false;

    //ゲームロード時の処理
    void Start()
    {
        //初回ロード時はなし
        if (SaveData.Instance.PreviousDataIsAvailableOrNot == false)
        {
            return;
        }
        SaveData.Instance.Reload();

        var MainSceneManager = GameObject.FindWithTag("MainSceneManager").GetComponent<MainScene>();

        //どのアイテムを購入したかをロード時に確認
        for (int i = 0; i < SaveData.Instance.Item_Effectives.Count; i++)
        {
            if (SaveData.Instance.Item_Effectives[i].OnOrOff == true)
            {
                //=================================================================================
                //インベントリ内のアイテムをアクティブ化
                //=================================================================================
                _isItems[i].gameObject.SetActive(true);

                //=================================================================================
                // //LayoutSceneにどのアイテム(配列の何番目)を買ったかをpassするためにフラグを管理(MainScene.csで使用)
                //=================================================================================
                if (i < 19)
                {
                    MainSceneManager.JudgeArray[i] = true;
                }

                //=================================================================================
                // スタイルキットの所持数を計算、反映 / 購入数に応じてスタイルポイントの獲得を反映
                //=================================================================================
                if (i == 21)
                {
                    StyleKitCountText.text = "×" + SaveData.Instance.StyleKitCountInt.ToString();
                }

                //=================================================================================
                // PCのアップグレードを反映
                //=================================================================================
                if (i == 19)
                {
                    ActivatePC1();
                }
                if (i == 20)
                {
                    ActivatePC2();
                }

                //=================================================================================
                // 各アイテムのショップ残量を計算、反映
                //=================================================================================
                if (i == 21)
                {
                    ShopCondition.InActivateShopBtns(i, SaveData.Instance.StyleKitCountInt);
                    //すでに値は追加してあるので、反映のためにメソッドだけ起動
                    StyleStatusManager.StylePointApply(SaveData.Instance.StyleKitCountInt);
                }
                else
                {
                    ShopCondition.InActivateShopBtns(i, 1);
                }

                //=================================================================================
                // ViewerCountCsに各アイテムの強化値を反映
                //=================================================================================

                if (SaveData.Instance.Item_Effectives[i].effectiveName == "やる気回復速度" || SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
                {
                    motivation_Contoroller.CaluculationRecoverTime(SaveData.Instance.Item_Effectives[i].MultiplierEffective);
                }

                if (SaveData.Instance.Item_Effectives[i].effectiveName == "視聴継続率UP" || SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
                {
                    viewer_Count.RetentionRatevalue += SaveData.Instance.Item_Effectives[i].MultiplierEffective;
                }

                if (SaveData.Instance.Item_Effectives[i].effectiveName == "レアチャット獲得確立UP" || SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
                {
                    viewer_Count.RareChatGetUp += SaveData.Instance.Item_Effectives[i].MultiplierEffective;

                }

            }


        }

        //=================================================================================
        //　アイテム強化状況のテキストを更新
        //=================================================================================
        itemEffective_VisulalUpdate.UpdateRatioTexts();

        //=================================================================================
        //前回のデータからスキルポイントとそれに伴うメッシュを復元
        //=================================================================================
        for (int s = 0; s < SaveData.Instance.StyleSatus.Length; s++)
        {
            if (SaveData.Instance.StyleSatus[s] == 0)
            {
                continue;
            }
            for (int z = 0; z < SaveData.Instance.StyleSatus[s]; z++)
            {
                StyleStatusManager.StyleEnhanceBtn(s);
            }
        }

    }


    public void PurchaseItems(int i, int quantity)
    {
        //必要な値段を計算し、その値段分の所持金があれば通す。
        //所持金がなければretrunして、警告ウィンドウを表示する。
        if (moneycontoroller.PossesedMoney < (itemdatabase.items[i].cost * quantity))
        {
            CantPuerChasePannelObje.SetActive(true);
            return;
        }
        else
        {
            //費用を所持金から引く
            var costAmount = (itemdatabase.items[i].cost * quantity);
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
        _isItems[i].gameObject.SetActive(true);

        //配列が19じゃないかつ20じゃない = 19か20か21以外なら以下を実行
        if (i != 19 && i != 20 && i != 21)
        {
            //LayoutSceneにどのアイテム(配列の何番目)を買ったかをpassするためにフラグを管理(MainScene.csで使用)
            MainSceneManager.JudgeArray[i] = true;
        }

        //使用したイベントリスナーは削除しておかないとスタックするので削除(成功時でも)
        shop_diceide_btn.onClick.RemoveAllListeners();

        //アイテム効果をON
        SaveData.Instance.Item_Effectives[i].OnOrOff = true;

        //スタイルキットの個数テキストを更新
        if (i == 21 && quantity != 0)
        {
            SaveData.Instance.StyleKitCountInt += quantity;
            StyleKitCountText.text = "×" + SaveData.Instance.StyleKitCountInt.ToString();
            StyleStatusManager.StylePointApply(quantity);

        }

        //PCアップデート
        if (i == 19)
        {
            ActivatePC1();
        }
        if (i == 20)
        {
            ActivatePC2();
        }

        //アイテムが売り切れかどうかを判定するメソッドに値を飛ばす
        ShopCondition.InActivateShopBtns(i, quantity);

        if (i == 21)
        {
            return;
        }

        //購入したアイテムの効果の累計価テキストを表示する
        itemEffective_VisulalUpdate.UpdateRatioTexts();

        //やる気の回復速度上昇を適用する
        if (SaveData.Instance.Item_Effectives[i].effectiveName == "やる気回復速度" || SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
        {
            motivation_Contoroller.CaluculationRecoverTime(SaveData.Instance.Item_Effectives[i].MultiplierEffective);
        }

        //視聴継続率の上昇を適用する
        if (SaveData.Instance.Item_Effectives[i].effectiveName == "視聴継続率UP" || SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
        {
            viewer_Count.RetentionRatevalue += SaveData.Instance.Item_Effectives[i].MultiplierEffective;
        }

        if (SaveData.Instance.Item_Effectives[i].effectiveName == "レアチャット獲得確立UP" || SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
        {
            viewer_Count.RareChatGetUp += SaveData.Instance.Item_Effectives[i].MultiplierEffective;

        }


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


