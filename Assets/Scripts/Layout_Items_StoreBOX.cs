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
    

}
