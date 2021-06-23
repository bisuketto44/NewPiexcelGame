using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUI : MonoBehaviour
{
    //現在のライブ配信状況を見るウィンドウのアニメーター
    private Animator LiveWindow;
    private bool _liveWindowbool = false;

    [SerializeField]
    GameObject LiveNowWindow;

    [SerializeField]
    GameObject PictureBooks;

    [SerializeField]
    GameObject PictureBook;

    //現在ライブビューのMask
    [SerializeField]
    GameObject LiveNowMask;

    [Tooltip("ドアを開閉するアニメーター")]
    [SerializeField]
    Animator DoorAnimator;

    [SerializeField]
    GameObject ResetCharcterObjects;

    [SerializeField]
    GameObject PlayerObjects;

    //現在ライブを起動するアニメーション
    public void LiveWindowAnimationActivate_InActivate()
    {
        LiveWindow = GameObject.FindWithTag("LiveWindow").GetComponent<Animator>();
        LiveWindow.SetTrigger("LiveWinTriiger");

        if (_liveWindowbool == false)
        {
            LiveNowMask.gameObject.SetActive(true);

            _liveWindowbool = true;
            return;
        }
        else
        {
            LiveNowMask.gameObject.SetActive(false);

            _liveWindowbool = false;
            return;
        }

    }

    public void PictureBookAnimationActivate_Inactivate()
    {
        var animation = PictureBooks.GetComponent<Animator>();
        animation.SetTrigger("CLCTTrigger");

        if (_liveWindowbool == false)
        {
            LiveNowMask.gameObject.SetActive(true);

            _liveWindowbool = true;
            return;
        }
        else
        {
            LiveNowMask.gameObject.SetActive(false);

            _liveWindowbool = false;
            return;
        }

    }

    //現在ライブのセットアクティブを起動する(AnimationEventで使用する)
    public void ActivateWindow()
    {
        LiveNowWindow.gameObject.SetActive(true);

    }

    //現在ライブのセットアクティブを表示してないときは非アクティブ化する(AnimationEventで使用する)
    public void InActivateWindow()
    {
        LiveNowWindow.gameObject.SetActive(false);

    }
    
    //上記と同じくハイパーチャット図鑑のアニメーションイベントで呼ぶ
    public void ActivateBook()
    {
        PictureBook.SetActive(true);

    }

    public void InactivateBook()
    {
        PictureBook.SetActive(false);

    }

    //以下キャラ生成用アニメーション

    //１: どの開閉アニメーションをスタートするトリガー
    public void DoorAnimation()
    {
        //ドアアニメーションのトリガーを引く
        DoorAnimator.SetTrigger("DoorTrigger");
    }

    //2 : リセット時のキャラクター出現アニメーション(ドアが開いた後にAnimationEventで呼び出し)
    public void ResetCharcter()
    {
        var Char = Instantiate(ResetCharcterObjects, ResetCharcterObjects.transform.position, Quaternion.identity);
        Char.GetComponent<Animator>().SetBool("ResetTrigger", true);

    }

    //3 : インスタンス化したオブジェクトからトリガーにアクセスするメソッド(リセットキャラが指定地点まで移動した後AnimatorEventで呼び出し)
    public void DoorAnimationinCharcter()
    {
        var gameObject = GameObject.FindWithTag("Door").GetComponent<Animator>();
        gameObject.SetTrigger("DoorTrigger");
    }

    //4 : アニメーション用のオブジェクトを破棄して、ゲーム用オブジェクトをインスタンス化する。(ドアが閉まったあとにAnimationEventで呼び出し)
    public void InstansiatePlayerCharcter()
    {
        var gameObject = GameObject.FindWithTag("ResetCharcter");
        //リセットキャラオブジェクトを破棄
        Destroy(gameObject);

        var Parent = GameObject.FindWithTag("MainSceneManager").transform;

        //ゲーム用オブジェクトをインスタンス化し、親をメインシーン管理オブジェクト化に
        var Object = Instantiate(PlayerObjects, PlayerObjects.transform.position, Quaternion.identity);
        Object.transform.SetParent(Parent, false);

    }




}
