using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SceneLayoutManagerオブジェクトに配置
public class LayoutScene : MonoBehaviour
{
    //配置ボタンのアクティブ化を管理。MainScene.CSにてフラグを管理
    [SerializeField]
    public GameObject[] _Items;

    [SerializeField]
    private Rotation_LayoutItems rotationLayoutItems;

    [SerializeField]
    GameObject Door;

    GameObject Object_A;

    private SE_Contoroller sE_Contoroller;

    void Awake()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();
    }

    //終了ボタンの処理
    public void ToMain()
    {
        //=================================================================================
        //メイン画面の表示
        //=================================================================================
        Object_A = GameObject.FindWithTag("A");
        Object_A.transform.GetChild(0).gameObject.SetActive(true);

        //=================================================================================
        //プレイヤー生成のアニメーションを再生
        //=================================================================================
        var main = GameObject.FindWithTag("MainSceneManager");
        var Door2 = Instantiate(Door, Door.transform.position, Quaternion.identity, main.transform);
        Door2.GetComponent<AnimationUI>().DoorAnimation();

        //=================================================================================
        //すでに生成してあるキャラクターを破棄
        //=================================================================================
        var player = GameObject.FindWithTag("PlayerObject");
        Destroy(player);


        //=================================================================================
        // 決定、しまうボタンを初期化、回転ボタンを初期化
        //=================================================================================
        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");
        var Btn2 = GameObject.FindWithTag("Layout_Btn2");
        Btn2.transform.GetChild(0).gameObject.SetActive(false);
        rotationLayoutItems.back();

        //=================================================================================
        // 戻るときに選択していたオブジェクトを破棄
        //=================================================================================

        sE_Contoroller.PlayCancelSound();

        Destroy(ThisGG);
        this.gameObject.SetActive(false);


    }



}
