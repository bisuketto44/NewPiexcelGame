using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//MainScnenオブジェトに付属
public class MainScene : MonoBehaviour
{
    //どのレイアウトアイテムをアクティブにするかを判定する
    [SerializeField]
    public bool[] JudgeArray;

    [SerializeField]
    private Item_Purchase itemPurchase;

    //LayoutSceneへ行く前にアイテムTABを閉じる
    [SerializeField]
    private GameObject _infoMaskObje;

    AnimationUI _animationUI;

    //layoutSceneのオブジェクト取得
    private GameObject Object_B;
    CanvasScaler _Canvas;

    //ゲーム開始時の処理
    void Start()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        JudgeArray = new bool[21];

        //キャラ生成を実行
        _animationUI = GameObject.FindWithTag("Door").GetComponent<AnimationUI>();
        _animationUI.DoorAnimation();
    }

    //シーンを複数ロードし、レイアウトシーンのほうは非表示にしておく。
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        Object_B = GameObject.FindWithTag("B");
        Object_B.transform.GetChild(0).gameObject.SetActive(false);
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    //配置からレイアウト画面を行く処理
    public void ToLayout()
    {
        Object_B = GameObject.FindWithTag("B");
        Object_B.transform.GetChild(0).gameObject.SetActive(true);

        //リセットキャラクター再生中ならそれも破棄、Doorオブジェクトも破棄
        var Rset = GameObject.FindWithTag("ResetCharcter");
        Destroy(Rset);
        Destroy(GameObject.FindWithTag("Door").gameObject);



        //アイテム配置ボタンをアクティブ化
        var LayoutSceneScript = Object_B.transform.GetChild(0).GetComponent<LayoutScene>();
        for (int i = 0; i < JudgeArray.Length; i++)
        {
            if (JudgeArray[i] == true)
            {
                //取得したアイテム数だけLayoutItemもアクティブ化
                LayoutSceneScript._Items[i].SetActive(true);

            }

        }

        //PCパーツを購入したらPCビジュアルをアップデート
        if (itemPurchase.boolPC1 == true)
        {
            var StoreBOX = GameObject.FindWithTag("LayoutStoreBOX").GetComponent<Layout_Items_StoreBOX>();
            SaveData.Instance.StoreBox[19].transform.GetChild(1).gameObject.SetActive(true);
           SaveData.Instance.StoreBoxIns[19].transform.GetChild(1).gameObject.SetActive(true);
            itemPurchase.boolPC1 = false;
        }
        if (itemPurchase.boolPC2 == true)
        {
            var StoreBOX = GameObject.FindWithTag("LayoutStoreBOX").GetComponent<Layout_Items_StoreBOX>();
            SaveData.Instance.StoreBox[19].transform.GetChild(2).gameObject.SetActive(true);
            SaveData.Instance.StoreBoxIns[19].transform.GetChild(2).gameObject.SetActive(true);
            itemPurchase.boolPC2 = false;
        }

        _infoMaskObje.SetActive(false);
        this.gameObject.SetActive(false);


    }


}
