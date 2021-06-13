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

    AnimationUI _animationUI;

    GameObject Object_A;

    //終了ボタンの処理
    public void ToMain()
    {
        //メイン画面を表示
        Object_A = GameObject.FindWithTag("A");
        Object_A.transform.GetChild(0).gameObject.SetActive(true);

        //プレイヤーキャラを新たに作成する一連のメソッドを起動
        _animationUI = GameObject.FindWithTag("Door").GetComponent<AnimationUI>();
        _animationUI.DoorAnimation();

        //すでに作成してあるプレイヤーオブジェクトを破棄
        var player = GameObject.FindWithTag("PlayerObject");
        Destroy(player);

        GameObject ThisGG = GameObject.FindWithTag("Now_Choose_LayoutItems");
        var Btn2 = GameObject.FindWithTag("Layout_Btn2");

        //決定、しまうボタンを初期化
        Btn2.transform.GetChild(0).gameObject.SetActive(false);
        //回転ボタンを初期化
        rotationLayoutItems.back();

        //戻るときに選択していたオブジェクトを破壊
        Destroy(ThisGG);
        this.gameObject.SetActive(false);
    }



}
