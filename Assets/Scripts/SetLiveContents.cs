using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//このScriptはLive_Windowに取り付けています
public class SetLiveContents : MonoBehaviour
{
    #region DfenitionVar

    [Tooltip("表示するScrollView内のコンテンツ配列")]
    [SerializeField]
    private GameObject[] _UI_Contents;

    [Tooltip("デフォで一番最初に表示される配信内容決定のメイン画面")]
    [SerializeField]
    private GameObject _UI_Main_Contents;

    [Tooltip("メイン画面のジャンルテキスト")]
    [SerializeField]
    private Text _UI_Main_Contents_JunleText;

    [Tooltip("メイン画面のスタイルテキスト")]
    [SerializeField]
    private Text _UI_Main_Contents_StyleText;

    [Tooltip("メイン画面の時間テキスト")]
    [SerializeField]
    private Text _UI_Main_Contents_TimeText;

    [Tooltip("メイン画面のやる気テキスト")]
    [SerializeField]
    private Text _UI_Main_Contents_Motivation;

    [Tooltip("メイン画面表示に現れる、配信開始画面を終了するボタン")]
    [SerializeField]
    private GameObject MainCloseBtn;

    [Tooltip("メイン画面以外で現れる１つ前の画面に戻るためのボタン")]
    [SerializeField]
    private GameObject BackBtn;

    [Tooltip("配信を開始するボタン")]
    [SerializeField]
    private GameObject LiveStartBtn;

    [Tooltip("コラボキャラクターの基礎情報をもつデータベースScriptをアタッチしたゲームオブジェクト")]
    [SerializeField]
    GameObject CollaboChatrcterDatabase;

    [Tooltip("コラボ決定画面を表示する(Mask)")]
    [SerializeField]
    GameObject _CollaboPanelMask;

    [Tooltip("キャラクターイメージを生成する基準になる背景パネル")]
    [SerializeField]
    private Image _CharcterIconPanelBackGround;

    [Tooltip("コラボキャラクターの名前テキスト")]
    [SerializeField]
    private Text _CharcterNameText;

    [Tooltip("コラボキャラクターの情報テキスト")]
    [SerializeField]
    private Text _CharcterExplaText;

    [Tooltip("レアリティ表示テキスト(★)")]
    [SerializeField]
    private Text _RearityText;

    [Tooltip("メイン画面にある決定したコラボキャラを表示するUI")]
    [SerializeField]
    private GameObject DisplayMainCollaboCharcterPanel;

    [Tooltip("コラボ決定画面を表示する(Mask)")]
    [SerializeField]
    private GameObject _CharcterChoosePanelMask;

    [Tooltip("キャラを決定するボタン")]
    [SerializeField]
    private GameObject _CharacterChooseDecideBtn;

    [Tooltip("メイン画面のレア度を表示するテキスト")]
    [SerializeField]
    private Text RearityTextMainPanel;

    [Tooltip("メイン画面のコラボキャラを表示する背景(空))")]
    [SerializeField]
    private GameObject CharcterPanelMainBackGround;

    [Tooltip("配信強化状況の一覧")]
    [SerializeField]
    private Live_Data_Information LiveData;


    //現在選択している画面を保存
    private int NowChooseContent;

    #endregion

    /// <summary>
    /// ジャンル、スタイル、時間、やる気をそれぞれ表示する。ボタンからメソッドを呼ぶ
    /// </summary>
    /// <param name="WhichContent">どの要素を表示するかを決定する引数</param>
    public void ActivateContents(int WhichContent)
    {
        _UI_Main_Contents.SetActive(false);
        _UI_Contents[WhichContent].SetActive(true);

        //BackBtnを表示
        MainCloseBtn.SetActive(false);
        LiveStartBtn.SetActive(false);
        BackBtn.SetActive(true);

        //選択画面を保存
        NowChooseContent = WhichContent;

    }

    /// <summary>
    /// 選んだジャンル内容をメイン画面に反映する。コラボ配信のみ別途メソッドを作成。
    /// </summary>
    /// <param name="formWhichContent">選んだボタン</param>
    public void SetContentToTheMainScreen_Junle(int formWhichContent)
    {
        string[] Chars;
        Chars = new string[5] { "ゲーム実況", "歌配信", "ダンス配信", "雑談配信", "お絵描き配信" };

        AvoidRepitiaon(formWhichContent, 5, _UI_Main_Contents_JunleText, Chars);

        //各選択したジャンルのオンに、選択されたもの以外をオフにする
        for (int i = 0; i < LiveData.JuneEffective.Count; i++)
        {
            LiveData.JuneEffective[i].OnorOff = false;
        }
        LiveData.JuneEffective[formWhichContent].OnorOff = true;

        //コラボ以外のジャンルを適用した場合はコラボキャラの倍率をオフに
        for (int i = 0; i < LiveData.CollaboChaeEffcrive.Count; i++)
        {
            LiveData.CollaboChaeEffcrive[i].OnOrOff = false;
        }

        //コラボ以外の時にはコラボキャラ選択を結果UIを非表示に
        DisplayMainCollaboCharcterPanel.SetActive(false);

    }

    /// <summary>
    /// 選んだスタイル内容をメイン画面に反映する
    /// </summary>
    /// <param name="formWhichContent">選んだボタン</param>
    public void SetContentToTheMainScreen_Style(int formWhichContent)
    {

        string[] Chars;
        Chars = new string[6] { "真面目", "おもしろ", "エロス", "炎上", "可愛い", "狂気" };

        AvoidRepitiaon(formWhichContent, 6, _UI_Main_Contents_StyleText, Chars);

        //各選択したスタイルのオンに、選択されたもの以外をオフにする
        for (int i = 0; i < LiveData.StyleEffective.Count; i++)
        {
            LiveData.StyleEffective[i].OnOrOff = false;
        }
        LiveData.StyleEffective[formWhichContent].OnOrOff = true;


    }

    /// <summary>
    /// 選んだ時間内容をメイン画面に反映する
    /// </summary>
    /// <param name="formWhichContent">選んだボタン</param>
    public void SetContentToTheMainScreen_Time(int formWhichContent)
    {
        string[] Chars;
        Chars = new string[3] { "短い", "普通", "長い" };

        AvoidRepitiaon(formWhichContent, 3, _UI_Main_Contents_TimeText, Chars);

        //時間選択追加の必要あり
        for (int i = 0; i < LiveData.LiveTimeEffective.Count; i++)
        {
            LiveData.LiveTimeEffective[i].OnOrOff = false;
        }
        LiveData.LiveTimeEffective[formWhichContent].OnOrOff = true;

    }

    /// <summary>
    /// 選んだやる気内容をメイン画面に反映する
    /// </summary>
    /// <param name="formWhichContent">選んだボタン</param>
    public void SetContentToTheMainScreen_Motivation(int formWhichContent)
    {
        string[] Chars;
        Chars = new string[4] { "通常", "25%UP", "50%UP", "100%UP" };

        AvoidRepitiaon(formWhichContent, 4, _UI_Main_Contents_Motivation, Chars);

        //各選択したやる気%をオンに、選択されたもの以外をオフにする
        for (int i = 0; i < LiveData.MotivationEffectives.Count; i++)
        {
            LiveData.MotivationEffectives[i].OnOrOff = false;
        }
        LiveData.MotivationEffectives[formWhichContent].OnOrOff = true;


    }

    /// <summary>
    /// 選んだ内容をメイン画面に表示するメソッド。各種ボタンで呼び出したメソッド内でこのメソッドを呼び出す。
    /// </summary>
    /// <param name="formWhichContent">選んだボタン</param>
    /// <param name="NumberOfCases">どのボタンを選んだかを判別する引数</param>
    /// <param name="WhichText">どのTextにString要素を割り当てるかを決定する</param>
    /// <param name="Chars">表示する文字列。配列で受け取り、何番目かを判定したのちに引数のTextに沿って反映する</param>
    private void AvoidRepitiaon(int formWhichContent, int NumberOfCases, Text WhichText, string[] Chars)
    {
        //メイン画面に戻るため再表示
        _UI_Main_Contents.SetActive(true);

        for (int i = 0; i < NumberOfCases; i++)
        {
            if (formWhichContent == i)
            {
                WhichText.text = Chars[i];
            }
        }

        //選択し終わった各コンテント画面は非表示に
        _UI_Contents[NowChooseContent].gameObject.SetActive(false);

        //終了ボタンを表示
        MainCloseBtn.SetActive(true);
        LiveStartBtn.SetActive(true);
        BackBtn.SetActive(false);

    }

    /// <summary>
    /// コラボ相手選択画面を起動するメソッド
    /// </summary>
    /// <param name="WhichContent">どの要素を表示するかを決定する引数。4はコラボビュー</param>
    public void CollaboContentsActivate(int WhichContent)
    {
        _UI_Main_Contents.SetActive(false);
        _UI_Contents[NowChooseContent].SetActive(false);
        _UI_Contents[WhichContent].SetActive(true);

        //選択画面を保存
        NowChooseContent = WhichContent;

        //メイン画面のコラボUIから飛んだ時にバックボタンを表示する
        if (MainCloseBtn.activeSelf == true)
        {
            MainCloseBtn.SetActive(false);
            LiveStartBtn.SetActive(false);
            BackBtn.SetActive(true);

        }

    }

    /// <summary>
    /// コラボ相手をクリックするとその詳細が表示、その相手で決定するかどうかの確認画面を出すメソッド。
    /// </summary>
    public void CollaboCharChoose(int WhichCharacter)
    {
        var info = CollaboChatrcterDatabase.gameObject.GetComponent<CollaboChar_Info_Database>();

        _CollaboPanelMask.SetActive(true);

        //各テキストにコラボキャラの情報を格納
        _CharcterNameText.text = info.CollaboCharinfo[WhichCharacter].CharcterName;
        _CharcterExplaText.text = info.CollaboCharinfo[WhichCharacter].CharcterExplanation;
        _RearityText.text = info.CollaboCharinfo[WhichCharacter].CharcterRaretity;

        //コラボキャラのアイコン表示のための背景を親要素に
        var parentTransForm = _CharcterIconPanelBackGround.transform;
        //アイコンを生成
        Instantiate(info.CollaboCharinfo[WhichCharacter].CharcterImage, parentTransForm.position, Quaternion.identity, parentTransForm);

        //決定ボタンにメソッドを登録
        var Decidebtn = _CharacterChooseDecideBtn.gameObject.GetComponent<Button>();
        Decidebtn.onClick.RemoveAllListeners();
        Decidebtn.onClick.AddListener(() => { DecideCollaboCharcter(WhichCharacter); });

    }

    /// <summary>
    /// コラボ相手決定後メイン画面でそのキャラクターを表示するメソッド
    /// </summary>
    public void DecideCollaboCharcter(int WhichCharacter)
    {
        var info = CollaboChatrcterDatabase.gameObject.GetComponent<CollaboChar_Info_Database>();

        //開いていたコンテンツを全部閉じて、メイン画面を表示
        _CollaboPanelMask.SetActive(false);
        _UI_Contents[NowChooseContent].SetActive(false);
        _UI_Main_Contents.SetActive(true);

        //メイン画面に移動するので、終了ボタンを表示
        MainCloseBtn.SetActive(true);
        LiveStartBtn.SetActive(true);
        BackBtn.SetActive(false);

        //決定時にコラボ配信をメインテキストへ
        _UI_Main_Contents_JunleText.text = "コラボ配信";

        //コラボジャンルを適用
        for (int i = 0; i < LiveData.JuneEffective.Count; i++)
        {
            LiveData.JuneEffective[i].OnorOff = false;
        }
        LiveData.JuneEffective[5].OnorOff = true;

        //コラボキャラの倍率を適用
        for (int i = 0; i < LiveData.CollaboChaeEffcrive.Count; i++)
        {
            LiveData.CollaboChaeEffcrive[i].OnOrOff = false;
        }
        LiveData.CollaboChaeEffcrive[WhichCharacter].OnOrOff = true;



        //メイン画面で選択したコラボキャラを表示するUIをアクティブ化
        DisplayMainCollaboCharcterPanel.SetActive(true);

        //選択キャラのレア度を表示
        RearityTextMainPanel.text = info.CollaboCharinfo[WhichCharacter].CharcterRaretity;

        //キャラ決定確認画面のイメージも削除
        Destroy(_CharcterIconPanelBackGround.transform.GetChild(0).gameObject);

        //イメージを生成
        var parentTransForm = CharcterPanelMainBackGround.transform;
        //もし生成済みなら消去
        if (parentTransForm.childCount >= 1)
        {
            Destroy(parentTransForm.GetChild(0).gameObject);
        }

        Instantiate(info.CollaboCharinfo[WhichCharacter].CharcterImage, parentTransForm.position, Quaternion.identity, parentTransForm);

    }

    /// <summary>
    /// コラボ相手決定をキャンセルするボタン
    /// </summary>
    public void CollaboCharChancelBtn()
    {
        //キャンセルしたらaddListnertを解除
        var Decidebtn = _CharacterChooseDecideBtn.gameObject.GetComponent<Button>();
        Decidebtn.onClick.RemoveAllListeners();

        //決定確認画面に生成したイメージを削除
        Destroy(_CharcterIconPanelBackGround.transform.GetChild(0).gameObject);
        _CharcterChoosePanelMask.SetActive(false);

    }

    /// <summary>
    /// BackBtnを起動するメソッド
    /// </summary>
    public void FunctionOftheBackBtn()
    {
        _UI_Contents[NowChooseContent].SetActive(false);
        _UI_Main_Contents.SetActive(true);

        //終了ボタンを表示
        MainCloseBtn.SetActive(true);
        LiveStartBtn.SetActive(true);
        BackBtn.SetActive(false);

    }

}
