using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viewer_Count : MonoBehaviour
{
    [Tooltip("同時接続数を表示するText")]
    [SerializeField]
    Text textViewerCount;

    [Tooltip("スパチャの合計数を表示するText")]
    [SerializeField]
    Text textSuperChatCount;

    [Tooltip("配信開始と同時にLive_attribute_decice_Maskを非表示にする")]
    [SerializeField]
    GameObject Live_Attribute_ui;

    //各色のチャット個数テキスト
    [SerializeField]
    Text _buleText;
    [SerializeField]
    Text _yellowText;
    [SerializeField]
    Text _orangeText;
    [SerializeField]
    Text _redText;

    //各色の合計金額
    [SerializeField]
    Text BuleAmountText;
    [SerializeField]
    Text YellowAmountText;
    [SerializeField]
    Text OrangeAmountText;
    [SerializeField]
    Text RedAmountText;

    [Tooltip("スパチャの合計額")]
    [SerializeField]
    Text SChatAmountText;

    [Tooltip("現在適用されている配信の強化状況一覧")]
    [SerializeField]
    Live_Data_Information LiveDataInfo;

    [Tooltip("ジャンルの経験値バーを動かす")]
    [SerializeField]
    JunleLv_Judge UpdateProgressJunleVar;


    Dictionary<int, float> probabilityViewer;
    Dictionary<int, float> probabilitySChat;

    //視聴者の基礎数
    private int _baseViewer = 10;
    //すべての効果を含んだ後のBaseViewer
    private float _baseViewerAfter;

    //実際に扱う視聴者の数字
    private int _Viewer;

    //視聴者数の上振れ最大倍率
    private int _baseViewerMagnification = 2;
    //下振れの最大人数 = 上振れの最大人数の30%とする
    private float _baseViewerdecreaseMF = 0.3f;

    //スパチャの投下頻度
    private float _baseSuperChatCountSecondMax = 6.0f;
    private float _baseSuperChatCountSecondMin = 2.0f;
    private float _baseNowSuperChatSecond;
    //振れ幅倍率
    private float _baseSuperchatMF = 1.05f;


    //ティック数のカウント
    private int _check = 0;
    //配信の長さを決定
    private int LiveTimeCheck = 0;
    //現在の視聴者数
    public int _nowViewerCount = 0;
    private float _nowSuperChatCount = 0;

    //このゲームの同時視聴者数の最大は6万人弱
    private int _maxViewer = 99999;

    //各色の個数
    private int _bule = 0;
    private int _yellow = 0;
    private int _orange = 0;
    private int _red = 0;

    //各色の合計金額
    private int _buleAmount = 0;
    private int _yellowAmount = 0;
    private int _orangeAmount = 0;
    private int _redAmount = 0;


    private int _sChatMoneyAmount = 0;

    //スパチャがカウントされるのは、ライブ中のみ。終わったらカウントされない。
    private bool _countSuperchat = false;

    IEnumerator StartCountUp;
    IEnumerator StartSchatCountUp;

    //必要項目を埋めているかどうかを管理するフラグ
    private bool _checkJunle = false;
    private bool _checkStyle = false;
    private bool _checkTime = false;
    private bool _checkMotivation = false;

    [Tooltip("必要項目を埋めるよう指示するウィンドウの表示")]
    [SerializeField]
    GameObject WarningWindow;

    //配信のタイトル
    string Title = "Sample";

    //選択したスタルとジャンルを表示するテキスト
    [SerializeField]
    Text ChooseStyleText;
    [SerializeField]
    Text ChooseJunleText;
    //選択したスタイルとジャンルを保存するString
    public string ChooseStyleName;
    public string ChooseJunleNmae;

    [Tooltip("配信の開始ボタン")]
    [SerializeField]
    Button DecideLiveBtn;

    [Tooltip("現在配信中であることを表示する警告")]
    [SerializeField]
    GameObject LiveNowWarning;

    [Tooltip("コメント生成を行う")]
    [SerializeField]
    private Nomal_Coment_Generate ComentGenerate;

    [Tooltip("ハイパーチャットの生成を行う")]
    [SerializeField]
    private Hiper_Chat_Generates HiperChatGenerates;

    //スパチャ生成のためのスクリプト獲得
    [SerializeField]
    private InfnityScrollLimited infnityScrollLimitedCS;
    [SerializeField]
    private InfinityScoll infinity;

    //メイン画面での視聴者テキスト
    [SerializeField]
    Text MainDisPlayViewerText;

    //ライングラフ用スクリプト１
    [SerializeField]
    LineGrahpeContoroller LineGrahpeAdd;

    //ライングラフ用スクリプト2
    [SerializeField]
    LineGrahpe LineMax;

    [SerializeField]
    Text LineVieweCountText;

    private bool Data_Previous_Live = false;

    [Tooltip("アーカイブ保存のため")]
    [SerializeField]
    Live_Acaive_Store_List LiveActiveSortList;

    [Tooltip("チャンネルの基本情報をアップデートするためのスクリプト")]
    [SerializeField]
    Channel_Infomation_Update channelInfomationUpdate;

    [SerializeField]
    GameObject NomalComentContents;

    //各配信の最大視聴者数
    int MaxTempViewer = 0;

    [Tooltip("やる気ゲージの増減をコントロールするスクリプト")]
    [SerializeField]
    Motivation_Contoroller motivationcontoroller;

    //消費やる気値
    int ConsMotivationvalue = 0;
    //選んだやる気
    int MotivationInt = 0;

    [Tooltip("選択したやる気を表示するテキスト(選択初期化のために使用)")]
    [SerializeField]
    Text MotivationText;

    [Tooltip("配信のタイトルを振る")]
    [SerializeField]
    Live_Title_Contoroller livetitelcontoroller;

    [Tooltip("現在配信のアニメーションオブジェクトを再生するためのスクリプト")]
    [SerializeField]
    private Live_Now_DisplayView_Update displayView_Update;

    [Tooltip("現在配信ウィンドウの開閉アニメーション")]
    [SerializeField]
    private AnimationUI animationUI;

    [Tooltip("自動で開くかを決めるトグル")]
    [SerializeField]
    private Toggle WindowToggle;

    [Tooltip("マネーシステムを管理するスクリプト")]
    [SerializeField]
    MoneyContoroller moneyContoroller;

    //視聴継続率
    public float RetentionRatevalue = 0f;
    //レアチャット獲得確率UP
    public float RareChatGetUp = 0f;


    //選択したジャンルを保存する変数
    int DecideJunle;

    //配信開始ボタン処理
    public void Go()
    {
        //配信開始前に変数を確認し、Base視聴者数を決定。
        _Viewer = DecideBaseViewrs();
        //配信時間を決定
        DicideLiveTime();


        //配信の必要フラグがすべて立っていたら開始
        if (_checkJunle == true && _checkStyle == true && _checkMotivation == true && _checkTime == true)
        {
            textViewerCount.gameObject.SetActive(true);
            SChatAmountText.gameObject.SetActive(true);
            Live_Attribute_ui.SetActive(false);

            //前回のデータが存在したら配信前に保存&リセット(見ずらいので別途メソッドを用意したほうが良いかも)
            if (Data_Previous_Live == true)
            {
                //ハイチャリストの初期化
                HiperChatGenerates.SortList.Clear();
                //ハイチャの最大数を初期化
                infnityScrollLimitedCS.max = 0;
                //ハイチャスクロールのビジュアルを初期化(更新)
                infinity.AutoUpdata();

                //経験値を与えた後に視聴者数も初期化
                _nowViewerCount = 0;
                //合計スパチャ数とスパチャ額も初期化
                _nowSuperChatCount = 0;
                _sChatMoneyAmount = 0;
                //各色も初期化
                _bule = 0;
                _yellow = 0;
                _orange = 0;
                _red = 0;
                _buleAmount = 0;
                _yellowAmount = 0;
                _orangeAmount = 0;
                _redAmount = 0;

                //各配信の最大視聴者数初期化
                MaxTempViewer = 0;

                //テキスト初期化メソッドを呼ぶ
                LineGrahpeAdd.ResetGrahpe();
                LineMax.TextRset();
                SChatAmountText.text = "0";
                textSuperChatCount.text = "0個";

                _buleText.text = "青チャット : 0" + "個";
                BuleAmountText.text = "0";
                _yellowText.text = "黄チャット : 0" + "個";
                YellowAmountText.text = "0";
                _orangeText.text = "橙チャット : 0" + "個";
                OrangeAmountText.text = "0";
                _redText.text = "赤チャット : 0" + "個";
                RedAmountText.text = "0";


                //コメント削除
                for (int i = 0; i < NomalComentContents.transform.childCount; i++)
                {
                    Destroy(NomalComentContents.transform.GetChild(i).gameObject);
                }


            }

            //やる気値を消費
            motivationcontoroller.CaluculationMotivationBar(ConsMotivationvalue);

            //配信開始と同時にもしやる気ゲージを消費していたら、その選択をリセットしておく
            if (MotivationInt != 0)
            {
                MotivationText.text = "---------";
                SaveData.Instance.motivation_Effective[MotivationInt].OnOrOff = false;
                _checkMotivation = false;
            }

            //選択したジャンルのアニメーションオブジェクトを再生
            displayView_Update.UpdateDisplayView(DecideJunle);

            //タイトル名を決定し、タイトルをstringに保存
            Title = livetitelcontoroller.DicideLiveTitle();

            //トグルにチェックがついていたら自動で配信開始時にウィンドウを開く
            if (WindowToggle.isOn == true)
            {
                animationUI.LiveWindowAnimationActivate_InActivate();
            }


            //配信用コルーチンを開始
            StartCountUp = CountUp();
            StartSchatCountUp = SuperChatCountUp();

            //※このままだと配信開始を押すたびにCoroutineがスタックしていくので対応必要
            StartCoroutine(StartCountUp);
            StartCoroutine(StartSchatCountUp);

            //選択したジャンルとスタイルを現在のライブ放送へ適用
            ChooseJunleText.text = "ジャンル : " + ChooseJunleNmae;
            ChooseStyleText.text = "スタイル : " + ChooseStyleName;

            //配信開始画面に配信中の警告を出して、新しく配信を開始できないようボタンを非アクティブ状態に
            LiveNowWarning.SetActive(true);
            DecideLiveBtn.interactable = false;


        }
        //フラグが立っていなかったら警告ウィンドウを表示
        else
        {
            WarningWindow.gameObject.SetActive(true);
            return;
        }


    }

    //視聴者が増えるか減るか
    void DictsViewer()
    {
        //確率の変動値を計算
        float changeValue = (30f * (RetentionRatevalue)) / 2;

        //0なら増やす、1なら減らす
        probabilityViewer = new Dictionary<int, float>();
        probabilityViewer.Add(0, 70.0f + changeValue); // increase
        probabilityViewer.Add(1, 30.0f - changeValue); // decrease

    }

    //Dictを元に確率抽選
    int ChooseViewer()
    {
        float total = 0;

        foreach (KeyValuePair<int, float> elem in probabilityViewer)
        {
            total += elem.Value;
        }

        float randomPoint = Random.value * total;

        //Valueをもとに確率計算。0~69なら0を返す。それ以外なら引いた残りの値から再抽選。
        foreach (KeyValuePair<int, float> elem in probabilityViewer)
        {
            if (randomPoint < elem.Value)
            {
                return elem.Key;
            }
            else
            {
                randomPoint -= elem.Value;
            }
        }

        return 0; // = end

    }

    //ベース視聴者数を決定するメソッド。(各配信強化状況を適用する)
    private int DecideBaseViewrs()
    {
        int Styleincrease = 0;
        int JunleIncrease = 0;
        int ItemIncrease = 0;

        int DecideStyle = 1;

        float MotivationMultipule = 1f;
        float ItemMultipule = 1f;
        float ConboMultipule = 1f;


        //選択されたスタイル(Lv)の固定増加視聴者数を反映
        for (int i = 0; i < SaveData.Instance.Style_Effective.Count; i++)
        {
            if (SaveData.Instance.Style_Effective[i].OnOrOff == true)
            {
                Styleincrease = SaveData.Instance.Style_Effective[i].BaseIncrease;
                //選択されたスタイルを保存
                DecideStyle = i;
                _checkStyle = true;

                //選択肢したスタイルを保存
                ChooseStyleName = SaveData.Instance.Style_Effective[i].StyleName;

            }

        }

        //選択されたジャンル(Lv)の固定増加視聴者数を反映
        for (int i = 0; i < SaveData.Instance.junle_Effective.Count; i++)
        {
            if (SaveData.Instance.junle_Effective[i].OnorOff == true)
            {
                JunleIncrease = SaveData.Instance.junle_Effective[i].BaseIncrease;
                //選択されたジャンルを保存
                DecideJunle = i;
                _checkJunle = true;

                //選択したジャンルを保存
                ChooseJunleNmae = SaveData.Instance.junle_Effective[i].JunleName;
            }
        }

        //購入されているアイテムの隠し固定値増加を反映
        for (int i = 0; i < SaveData.Instance.Item_Effectives.Count; i++)
        {
            if (SaveData.Instance.Item_Effectives[i].OnOrOff == true)
            {
                ItemIncrease += SaveData.Instance.Item_Effectives[i].HiddenFixedValues;
            }
        }

        //やる気の倍率を反映
        for (int i = 0; i < SaveData.Instance.motivation_Effective.Count; i++)
        {
            if (SaveData.Instance.motivation_Effective[i].OnOrOff == true)
            {
                MotivationMultipule = SaveData.Instance.motivation_Effective[i].Motivation_Percent;
                //やる気消費量を決定
                ConsMotivationvalue = SaveData.Instance.motivation_Effective[i].ConsMotivation;
                _checkMotivation = true;
                //選択したやる気がどれなのかを保存
                MotivationInt = i;
            }
        }

        //アイテム倍率を反映
        for (int i = 0; i < SaveData.Instance.Item_Effectives.Count; i++)
        {
            if (SaveData.Instance.Item_Effectives[i].OnOrOff == true && SaveData.Instance.Item_Effectives[i].effectiveName == "視聴者数UP")
            {
                ItemMultipule += SaveData.Instance.Item_Effectives[i].MultiplierEffective;
            }
            if (SaveData.Instance.Item_Effectives[i].OnOrOff == true && SaveData.Instance.Item_Effectives[i].effectiveName == "全効果")
            {
                ItemMultipule += SaveData.Instance.Item_Effectives[i].MultiplierEffective;
            }
        }

        //コラボ配信以外を選択した場合のスタイル*ジャンルの倍率(コラボ配信の配列は5番なので)※配列の大きさに問題ありそう
        if (DecideJunle != 5)
        {
            ConboMultipule = LiveDataInfo.ConboMultipule[DecideJunle, DecideStyle];
        }
        //5 = コラボ配信なら
        else
        {
            for (int i = 0; i < SaveData.Instance.CollaboChar_Effective.Count; i++)
            {
                if (SaveData.Instance.CollaboChar_Effective[i].OnOrOff == true)
                {
                    ConboMultipule = SaveData.Instance.CollaboChar_Effective[i].CollaboChareMuptipure;
                }
            }

        }

        //(初期BaseViewer + スタイルによる視聴者増加固定 + ジャンルによる視聴者増加固定 + 隠しアイテム固定値) * やる気倍率 * アイテム倍率 * コンボ倍率、で計算
        _baseViewerAfter = (_baseViewer + Styleincrease + JunleIncrease + ItemIncrease) * MotivationMultipule * ItemMultipule * ConboMultipule;
        //小数点切り捨てIntに
        Mathf.Floor(_baseViewerAfter);

        Debug.Log("ベース視聴者");
        Debug.Log(_baseViewerAfter);

        return (int)_baseViewerAfter;
    }

    //配信時間を決定
    private void DicideLiveTime()
    {
        for (int i = 0; i < SaveData.Instance.LiveTime.Count; i++)
        {
            if (SaveData.Instance.LiveTime[i].OnOrOff == true)
            {
                LiveTimeCheck = SaveData.Instance.LiveTime[i].Livetime;
                _checkTime = true;
            }

        }

    }

    //同時視聴者数の変動を操作するメソッド
    void Increase_Decrease()
    {
        DictsViewer();
        int chooseId = ChooseViewer();



        //0なら増やす、1なら減らす
        if (chooseId == 0)
        {
            //BaseViewに振れ幅2倍でカウント
            _nowViewerCount += Random.Range(_Viewer, _Viewer * _baseViewerMagnification);
        }
        else
        {
            var num = (_Viewer * _baseViewerMagnification) * _baseViewerdecreaseMF;
            num = Mathf.Floor(num);

            _nowViewerCount += Random.Range((int)-num, 0);
            if (_nowViewerCount < 0)
            {
                _nowViewerCount = 0;
            }
        }

    }

    //現在の同時接続数から1回でもらえるスパチャの個数を選定
    void SuperChatCount()
    {
        if (_nowViewerCount != 0)
        {
            var position = Mathf.InverseLerp(0, _maxViewer, _nowViewerCount);
            //人数が増えれば増えるほど１回で貰えるスパチャ数が増加する
            var _postion2 = Mathf.Lerp(2, 60, position);
            //最大1*100倍の100個が1ティックで取得できる
            var final = 1 * (Mathf.Floor(_postion2));
            var final2 = (int)final;

            //スパチャの個数をランダム化
            final2 = Random.Range(final2, (final2 * 2));

            //スパチャの個数を選定
            _nowSuperChatCount += final2;

            //スパチャの個数に合わせてその回数分色判定
            for (int i = 0; i < final2; i++)
            {
                //最大値を増やす
                infnityScrollLimitedCS.max++;
                //最大値に合わせて、ビューサイズを変更
                infnityScrollLimitedCS.OnPostSetupItems();
                //チャットを呼ぶ
                isSChatColor();
                //新しいチャットを呼ぶごとに要素を変更
                infinity.AutoUpdata();

            }

        }

    }

    //基礎視聴者数から、スパチャをもらうティック秒数を決定するメソッド
    void SuperChatCountScond()
    {

        var position = 1 - Mathf.InverseLerp(10, 2000, _Viewer);
        var _postion2 = Mathf.Lerp(_baseSuperChatCountSecondMin, _baseSuperChatCountSecondMax, position);

        var final = 1 * _postion2;

        _baseNowSuperChatSecond = final;

    }


    //スパチャの額がどれになるか
    void DictsSuperChat()
    {
        var changeValueYellow = (3.0f * RareChatGetUp);
        var changeValueOrange = (1.6f * RareChatGetUp);
        var changeValueRed = (0.4f * RareChatGetUp);

        probabilitySChat = new Dictionary<int, float>();
        probabilitySChat.Add(0, 95.0f - changeValueYellow - changeValueOrange - changeValueRed);
        probabilitySChat.Add(1, 3.0f + changeValueYellow);
        probabilitySChat.Add(2, 1.6f + changeValueOrange);
        probabilitySChat.Add(3, 0.4f + changeValueRed);

    }

    //スパチャ抽選
    int ChooseSChat()
    {
        float total = 0;

        foreach (KeyValuePair<int, float> elem in probabilitySChat)
        {
            total += elem.Value;
        }

        float randomPoint = Random.value * total;

        foreach (KeyValuePair<int, float> elem in probabilitySChat)
        {
            if (randomPoint < elem.Value)
            {
                return elem.Key;
            }
            else
            {
                randomPoint -= elem.Value;
            }
        }

        return 0; // = end

    }

    void isSChatColor()
    {
        DictsSuperChat();
        int choose = ChooseSChat();

        switch (choose)
        {
            case 0:
                _bule += 1;
                _buleText.text = "青チャット : " + _bule.ToString() + "個";

                var tempInt1 = (Random.Range(1, 100)) * 10;

                //青の合計金額に+
                _buleAmount += tempInt1;
                BuleAmountText.text = _buleAmount.ToString("N0");

                HiperChatGenerates.GenerateHiperChat(0, tempInt1);

                //総合の合計金額に+
                _sChatMoneyAmount += tempInt1;
                break;
            case 1:
                _yellow += 1;
                _yellowText.text = "黄チャット : " + _yellow.ToString() + "個";

                var tempInt2 = Random.Range(100, 200) * 10;

                //黄色の合計金額に+
                _yellowAmount += tempInt2;
                YellowAmountText.text = _yellowAmount.ToString("N0");

                HiperChatGenerates.GenerateHiperChat(1, tempInt2);

                //総合の合計に+
                _sChatMoneyAmount += tempInt2;
                break;
            case 2:
                _orange += 1;
                _orangeText.text = "橙チャット : " + _orange.ToString() + "個";

                var tempInt3 = Random.Range(200, 1000) * 10;

                //橙の合計金額に+
                _orangeAmount += tempInt3;
                OrangeAmountText.text = _orangeAmount.ToString("N0");

                HiperChatGenerates.GenerateHiperChat(2, tempInt3);

                //総合の合計に+
                _sChatMoneyAmount += tempInt3;
                break;
            case 3:
                _red += 1;
                _redText.text = "赤チャット : " + _red.ToString() + "個";

                var tempInt4 = Random.Range(1000, 5001) * 10;

                //赤の合計金額に+
                _redAmount += tempInt4;
                RedAmountText.text = _redAmount.ToString("N0");

                HiperChatGenerates.GenerateHiperChat(3, tempInt4);

                _sChatMoneyAmount += tempInt4;
                break;
            default:
                Debug.Log("End");
                break;
        }

    }

    IEnumerator CountUp()
    {
        _countSuperchat = true;
        while (_check < LiveTimeCheck)
        {

            _check++;
            //視聴者を増やす+スーパーチャットをもらえる秒数を決定。
            Increase_Decrease();
            SuperChatCountScond();

            //コメント生成
            ComentGenerate.GenerateComent();

            textViewerCount.text = "現在の視聴者数 : " + _nowViewerCount.ToString("N0") + "人";
            MainDisPlayViewerText.text = _nowViewerCount.ToString("N0") + "人が視聴中";

            //配信全体の同時視聴者の最大数を記録
            if (SaveData.Instance.MaxViewer <= _nowViewerCount)
            {
                SaveData.Instance.MaxViewer = _nowViewerCount;
            }
            //各配信の最大数を記録
            if (MaxTempViewer <= _nowViewerCount)
            {
                MaxTempViewer = _nowViewerCount;
            }

            //LineGraghpeに人数を送る
            LineGrahpeAdd.UpdateLineGraph(_nowViewerCount);

            yield return new WaitForSeconds(1.5f);

        }
        _countSuperchat = false;

        Data_Previous_Live = true;

        //////以下配信終了後の初期化処理/////

        //カウントを0に再度リセット
        _check = 0;

        //SuperChatCountUp()をストップしてNULLで初期化
        StopCoroutine(StartSchatCountUp);
        StartSchatCountUp = null;

        //このコルーチンもストップしてNULLで初期化
        StopCoroutine(StartCountUp);
        StartCountUp = null;

        //配信中の警告を非表示にし、配信開始ボタンを使用可能に
        LiveNowWarning.SetActive(false);
        DecideLiveBtn.interactable = true;

        //使用されたジャンルを判別し、経験値バーに経験値を与える。(経験値=最終的な人数)
        UpdateProgressJunleVar.JudgmentJunles();
        //終了しました画面を表示する
        displayView_Update.UpdateDisplayViewFinish();
        Debug.Log("END");

        //チャンネル情報更新スクリプトに情報を渡す(メイン)
        channelInfomationUpdate.UpdateChannelMainInfomations(_nowViewerCount, SaveData.Instance.MaxViewer, _sChatMoneyAmount);
        channelInfomationUpdate.UpdateHiperChatAmounts(_bule, _yellow, _orange, _red);
        channelInfomationUpdate.UpdateHiperChatMoneys(_buleAmount, _yellowAmount, _orangeAmount, _redAmount);

        //配信の収益を追加
        moneyContoroller.GainMoney(_sChatMoneyAmount);

        //別の2次元Listに過去のデータを保存
        LiveActiveSortList.GenerateAcaiveHipeChatList();
        //その他のデータをリストに格納
        LiveActiveSortList.GenerateAchiveElementsList(Title, ChooseJunleNmae, ChooseStyleName, MaxTempViewer, _sChatMoneyAmount, (int)_nowSuperChatCount, _bule, _yellow, _orange, _red, _buleAmount, _yellowAmount, _orangeAmount, _redAmount);

    }

    IEnumerator SuperChatCountUp()
    {
        while (_countSuperchat == true)
        {
            //秒数決定に際して、決めたメソッド(※SuperChatCountScond()のこと)からある程度の倍率で乱数を充てる
            var num = Random.Range(_baseNowSuperChatSecond, (_baseNowSuperChatSecond * _baseSuperchatMF));
            Debug.Log(num);
            yield return new WaitForSeconds(num);
            //決定した秒数ごとにスパチャ獲得のメソッドを呼ぶ
            SuperChatCount();
            SChatAmountText.text = _sChatMoneyAmount.ToString("N0");
            textSuperChatCount.text = _nowSuperChatCount.ToString("N0") + "個";


        }

    }

}