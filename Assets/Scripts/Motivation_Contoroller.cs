using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//C# : Datatime構造体を使用する名前空間
using System;

public class Motivation_Contoroller : MonoBehaviour
{
    //消費は2/4/6の順番
    //消費値以下しかやる気ゲージがなかった場合
    //ボタンのインタラクティブをfalseに
    //対象のやる気を選択した場合、それに合わせてやる気ゲージを減少させる

    [Tooltip("やる気ゲージのボタン")]
    [SerializeField]
    Button[] MotivationButtons;

    [Tooltip("やる気ゲージのスライダー")]
    [SerializeField]
    private Slider slider;

    [Tooltip("やる気ゲージの現在値を表示するテキスト")]
    [SerializeField]
    Text MotivationValueText;

    [Tooltip("時間表示のテキスト")]
    [SerializeField]
    Text TimeText;

    //やる気ゲージの最大値
    private int _maxMotivationValue = 10;
    //やる気ゲージの現在値
    public int CurrentMotivationValue = 10;
    //消費やる気ゲージ値
    public int ConsMotivationValue = 0;

    //回復するまでに必要な時間と、強化後の時間
    private float TimeToRecover = 60f;
    private float UpdateTimeToRecover = 60f;

    private float EnhanceValueAmount = 0f;


    private DateTime StartTime;
    private DateTime QuitTime;
    private DateTime TimePassedOutofGame;
    private string TimePassedlastTimeBinary;

    //ゲーム外での経過時間(秒)
    private double PassedTime;
    private int GameActivatedAtLastOnce = 0;

    private float InGamePassedTime = 0;
    private float oldTime;
    private float minute = 0;

    private bool boolMax = true;

    void Awake()
    {
        //前回のデータがあるなら前回の終了時間を読み込み
        if (PlayerPrefs.GetInt("isData") == 1)
        {
            //保存したバイナリデータを(読み込み)
            TimePassedlastTimeBinary = PlayerPrefs.GetString("Time");
            //バイナリデータから時刻に復元
            TimePassedOutofGame = DateTime.FromBinary(Convert.ToInt64(TimePassedlastTimeBinary));

            //起動時の時間を保存
            StartTime = DateTime.Now;

            //前回終了した時間から何秒経過したかを計算する
            PassedTime = (StartTime - TimePassedOutofGame).TotalSeconds;

            Debug.Log(PassedTime);
        }

        //前回のやる気ゲージ値を読み込んでロード(読み込み)
        CurrentMotivationValue = PlayerPrefs.GetInt("LeftMotivationPT", CurrentMotivationValue);
        //前回の秒数(読み込み)
        InGamePassedTime = PlayerPrefs.GetFloat("Second", InGamePassedTime);
        //ゲーム時間外とゲーム時間内の秒数を計算して、秒数を再構築
        CaluclateOutOfGameTime();
        //ビジュアルアップデート
        UpdateMotivationBar();


    }

    void Update()
    {
        //値がMAXになったら回復しなくなるように
        if (boolMax == false)
        {
            InGamePassedTime += Time.deltaTime;

            if ((int)InGamePassedTime != (int)oldTime)
            {
                TimeText.text = "あと " + minute.ToString() + ":" + (TimeToRecover - (int)InGamePassedTime).ToString("00");

                minute = 0;
                if (InGamePassedTime >= TimeToRecover)
                {
                    CurrentMotivationValue += 1;
                    InGamePassedTime -= TimeToRecover;
                    UpdateMotivationBar();
                }
            }
            oldTime = InGamePassedTime;

        }

    }

    //ゲーム時間外での時間からスタミナの回復量を計算する
    private void CaluclateOutOfGameTime()
    {
        //何回回復したかを計算
        var num = ((int)PassedTime + (int)InGamePassedTime) / TimeToRecover;

        //0~10までで回復量を計算
        var RecovaryValue = Mathf.Clamp((int)num, 0, 10);
        //回復分を足し合わせる
        CurrentMotivationValue += (int)RecovaryValue;
        //回復量がいくつ足されてもMAXは10に設定
        CurrentMotivationValue = Mathf.Clamp(CurrentMotivationValue, 0, 10);

        //端数の秒数部分を切り取る
        var second = ((int)PassedTime + (int)InGamePassedTime) % TimeToRecover;

        InGamePassedTime = second;
        Debug.Log(InGamePassedTime);
    }

    /// <summary>
    /// ゲーム終了時にやる気ゲージに関するデータを保存
    /// </summary>
    void OnApplicationQuit()
    {
        QuitTime = DateTime.Now;

        //終了時間をバイナリで(０と１の羅列)のstring型で保存(Jsonのような保存)
        PlayerPrefs.SetString("Time", QuitTime.ToBinary().ToString());
        //前回データが"ある"状態で終了(保存)
        GameActivatedAtLastOnce = 1;
        PlayerPrefs.SetInt("isData", GameActivatedAtLastOnce);
        //ゲーム終了時のスタミナ時間を保存
        if (boolMax != true)
        {
            PlayerPrefs.SetFloat("Second", InGamePassedTime);
        }
        Debug.Log("終了しました");
    }

    private void UpdateMotivationBar()
    {
        //やる気ゲージを消費分減少させる
        slider.value = (float)CurrentMotivationValue / _maxMotivationValue;
        MotivationValueText.text = "やる気 : " + CurrentMotivationValue.ToString() + "/10";

        //残りやる気値に合わせて使用不可に
        if (CurrentMotivationValue < 2)
        {
            MotivationButtons[0].interactable = false;
        }
        if (CurrentMotivationValue < 4)
        {
            MotivationButtons[1].interactable = false;
        }
        if (CurrentMotivationValue < 6)
        {
            MotivationButtons[2].interactable = false;
        }

        //残りのやる気値に合わせて使用可能に
        if (CurrentMotivationValue >= 2)
        {
            MotivationButtons[0].interactable = true;
        }
        if (CurrentMotivationValue >= 4)
        {
            MotivationButtons[1].interactable = true;
        }
        if (CurrentMotivationValue >= 6)
        {
            MotivationButtons[2].interactable = true;
        }

        if (CurrentMotivationValue == 10)
        {
            TimeText.text = "MAX";
            boolMax = true;
            //Maxになったら次のカウントが１分で始まるようにリセット
            InGamePassedTime = 0;

        }
        else
        {
            boolMax = false;
        }
        TimeToRecover = UpdateTimeToRecover;
        //やる気ポイントを保存
        PlayerPrefs.SetInt("LeftMotivationPT", CurrentMotivationValue);

    }

    /// <summary>
    /// 配信でやる気消費時に消費量を計算する
    /// </summary>
    public void CaluculationMotivationBar(int ConsValue)
    {
        //消費値を決定
        ConsMotivationValue = ConsValue;
        //現在値を決定
        CurrentMotivationValue = CurrentMotivationValue - ConsMotivationValue;
        //ビジュアルアップデート
        UpdateMotivationBar();

    }

    public void CaluculationRecoverTime(float EnhanceValue)
    {
        //合計値を計算
        EnhanceValueAmount += EnhanceValue;
        //新しい回復時間を設定
        UpdateTimeToRecover = 60f - (60f * EnhanceValueAmount);
        Debug.Log(UpdateTimeToRecover);
        Debug.Log(EnhanceValueAmount);

    }


}
