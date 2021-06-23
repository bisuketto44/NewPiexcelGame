using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LayouItemに関するデータ保持オブジェクト
//レイアウトアイテムの選択、インスタンス化はすべてここから選ぶ
public class Layout_Items_StoreBOX : MonoBehaviour
{
    //選択時のオブジェクト保管
    [SerializeField]
    public GameObject[] StoreBox;

    //インスタンス化時のオブジェクト保管
    [SerializeField]
    public GameObject[] StoreBoxIns;

    //インスタンス化した後のヒエラルキーにあるオブジェクト保管(プレハブを直接参照しないため)
    [SerializeField]
    public GameObject[] isStoreBox;

    //選択時、実行処理をすべきか、解除処理をすべきかを判定するbool
    [SerializeField]
    public bool[] whatBtn;

    [SerializeField]
    Transform ParentTransform;

    void Awake()
    {
        //=================================================================================
        //セーブデータが存在する場合、transformXとYからレイアウトを復元
        //=================================================================================
        if (SaveData.Instance.PreviousDataIsAvailableOrNot == true)
        {
            for (int i = 0; i < StoreBoxIns.Length; i++)
            {
                if (SaveData.Instance.whatBtn[i] == true)
                {
                    isStoreBox[i] = Instantiate(SaveData.Instance.StoreBoxIns[i], new Vector2(SaveData.Instance.X[i], SaveData.Instance.Y[i]), Quaternion.identity, ParentTransform);
                }

            }

            return;
        }
        //=================================================================================
        //ない場合はセーブデータを初期化する
        //=================================================================================
        for (int i = 0; i < StoreBox.Length; i++)
        {
            SaveData.Instance.StoreBox[i] = StoreBox[i];
            SaveData.Instance.StoreBoxIns[i] = StoreBoxIns[i];
            SaveData.Instance.whatBtn[i] = whatBtn[i];

        }

    }


}
