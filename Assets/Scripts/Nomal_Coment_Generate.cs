using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ComentGanarateオブジェクトに付与します
public class Nomal_Coment_Generate : MonoBehaviour
{
    [Tooltip("通常コメントの基礎オブジェクト")]
    [SerializeField]
    private GameObject Nomal_Coment_Object;

    [Tooltip("コメントをセットするContentを指定")]
    [SerializeField]
    private GameObject LocationOfParentTosSetComent;

    [Tooltip("最新のコメントを表示するためにValueを固定")]
    [SerializeField]
    private Scrollbar ComentSctollBar;

    [Tooltip("自動スクロールを切り替えるトグル")]
    [SerializeField]
    private Toggle ComentToggle;

    [Tooltip("通常コメントのデータベースに接続")]
    [SerializeField]
    private Coment_HiperChat_DataBaseContoroller ComentDatabese;

    private Transform ParentTransform;


    void Awake()
    {
        //親のトランスフォームを取得
        ParentTransform = LocationOfParentTosSetComent.transform;
    }

    public void GenerateComent()
    {

        //オブジェクトを生成し、変数に格納
        var GeneratedGameObject = Instantiate(Nomal_Coment_Object, ParentTransform.position, Quaternion.identity, ParentTransform);

        //どのコメントを選ぶかランダムで抽選
        var TempChooseComent = Random.Range(0, ComentDatabese.NomalComents.Length);

        //生成したコメントを変更
        GeneratedGameObject.transform.GetChild(1).GetComponent<Text>().text = ComentDatabese.NomalComents[TempChooseComent];

　　　　 //トグルがオンなら最新のコメントへ自動スクロール
        StartCoroutine(ForceScrollDown());

    }

    //※スクロールバーのスクロールは１フレーム以上待たないと反映されない(２フレーム安定かな?)
    IEnumerator ForceScrollDown()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        if (ComentToggle.isOn == true)
        {
            //最新コメントを表示
            ComentSctollBar.value = 0.0000f;

        }
    }


}
