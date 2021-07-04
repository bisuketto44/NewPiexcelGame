using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// クラスを丸ごとJsonで保存するデータクラス
/// </summary>
[Serializable]
public class SaveData : ISerializationCallbackReceiver
{

    //シングルトンを実装するための実体、初アクセス時にLoadする。
    private static SaveData _instance = null;
    public static SaveData Instance
    {
        get
        {
            if (_instance == null)
            {
                Load();
            }
            //.Instanceからアクセスすることで返されるインスタンスはここで明記した_instanceだけになり、一つだけインスタンスが作成されることになる。
            return _instance;
        }
    }

    //SaveDataをJsonに変換したテキスト(リロード時に何度も読み込まなくていいように保持)
    [SerializeField]
    private static string _jsonText = "";

    //=================================================================================
    //保存されるデータ(public or SerializeFieldを付ける)
    //=================================================================================

    //前回のデータが存在するかどうかを確認する
    public bool PreviousDataIsAvailableOrNot;

    //ViewerCountCS
    public int MaxViewer = 0;

    //チャンネル登録者数を保存する
    public int subscrivers = 0;
    //最高同時接続数を保存するint
    public int MaxViewerEver = 0;
    //今まで稼いだ額を保存する
    public int MoneyEverEarnd = 0;

    //各ハイパーチャットの取得数
    public int buleamount;
    public int yellowamount;
    public int orangeamount;
    public int redamount;

    //各ハイパーチャットの金額数
    public int bulemoney;
    public int yellowmoney;
    public int orangemoney;
    public int redmoney;

    //コラボ相手をどこまで解禁したかの変数
    public int currentCount = 2;


    //スタイルキットの合計個数を保存する
    public int StyleKitCountInt = 0;

    //スタイルのステータスポイント
    public int[] StyleSatus = new int[] { 0, 0, 0, 0, 0, 0 };

    public string ChannelNameString = "名無しチャンネル";

    //ぞれぞれのジャンルを何回放送したかをカウントする変数
    public int[] CountOfJunle = new int[6];

    //各効果Classのリスト
    public List<Item_Effective> Item_Effectives;
    public List<Junle_Effective> junle_Effective;
    public List<Style_Effective> Style_Effective;
    public List<Motivation_Effective> motivation_Effective;
    public List<CollaboChar_Effective> CollaboChar_Effective;
    public List<LiveTime> LiveTime;

    //アーカイブを保存するための２次元リストを作成
    [SerializeField]
    public List<ValueList> AcaiveLiveList;
    //２次元リストのための、リストをもったクラスを作成
    [SerializeField]
    public ValueList AcaiveContents;
    //その他のアーカイブ情報を保存するリストを作成
    [SerializeField]
    public List<Base_Achives_Elements> AcaiveElementsList;
    //現在のアーカイブ数をカウントする変数
    public int count = 0;
    public int count2 = 0;

    //各経験値バーの総合経験値量を保存
    public int[] ExpAmounts = new int[6];

    //チャット図鑑のコメント内容を保存
    public List<Base_YellowChat_Coment> YellowChatComents;
    public List<Base_OrangeChat_Coment> OrangeChatComents;
    public List<Base_RedChat_Coment> RedChatComents;

    //選択時のオブジェクト保管
    [SerializeField]
    public GameObject[] StoreBox = new GameObject[21];

    //インスタンス化時のオブジェクト保管
    [SerializeField]
    public GameObject[] StoreBoxIns = new GameObject[21];

    //インスタンス化した後のヒエラルキーにあるオブジェクト保管(プレハブを直接参照しないため)
    [SerializeField]
    public float[] X = new float[21];

    [SerializeField]
    public float[] Y = new float[21];


    //選択時、実行処理をすべきか、解除処理をすべきかを判定するbool
    [SerializeField]
    public bool[] whatBtn = new bool[21];


    [SerializeField]
    private string _sampleDictJson = "";
    public Dictionary<string, int> SampleDict = new Dictionary<string, int>(){
    {"Key1", 50},
    {"Key2", 150},
    {"Key3", 550}
  };

    //=================================================================================
    //シリアライズ,デシリアライズ時のコールバック
    //=================================================================================

    /// <summary>
    /// SaveData→Jsonに変換される前に実行される。
    /// </summary>
    public void OnBeforeSerialize()
    {
        //Dictionaryはそのままで保存されないので、シリアライズしてテキストで保存。
        _sampleDictJson = Serialize(SampleDict);
    }

    /// <summary>
    /// Json→SaveDataに変換された後に実行される。
    /// </summary>
    public void OnAfterDeserialize()
    {
        //保存されているテキストがあれば、Dictionaryにデシリアライズする。
        if (!string.IsNullOrEmpty(_sampleDictJson))
        {
            SampleDict = Deserialize<Dictionary<string, int>>(_sampleDictJson);
        }
    }

    //引数のオブジェクトをシリアライズして返す
    private static string Serialize<T>(T obj)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        return Convert.ToBase64String(memoryStream.GetBuffer());
    }

    //引数のテキストを指定されたクラスにデシリアライズして返す
    private static T Deserialize<T>(string str)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
        return (T)binaryFormatter.Deserialize(memoryStream);
    }

    //=================================================================================
    //取得
    //=================================================================================

    /// <summary>
    /// データを再読み込みする。
    /// </summary>
    public void Reload()
    {
        JsonUtility.FromJsonOverwrite(GetJson(), this);
    }

    //データを読み込む。
    private static void Load()
    {
        _instance = JsonUtility.FromJson<SaveData>(GetJson());
    }

    //保存しているJsonを取得する
    private static string GetJson()
    {
        //既にJsonを取得している場合はそれを返す。
        if (!string.IsNullOrEmpty(_jsonText))
        {
            return _jsonText;
        }

        //Jsonを保存している場所のパスを取得。
        string filePath = GetSaveFilePath();

        //Jsonが存在するか調べてから取得し変換する。存在しなければ新たなクラスを作成し、それをJsonに変換する。
        if (File.Exists(filePath))
        {
            _jsonText = File.ReadAllText(filePath);
        }
        else
        {
            _jsonText = JsonUtility.ToJson(new SaveData());
        }

        return _jsonText;
    }

    //=================================================================================
    //保存
    //=================================================================================

    /// <summary>
    /// データをJsonにして保存する。
    /// </summary>
    public void Save()
    {
        _jsonText = JsonUtility.ToJson(this);
        File.WriteAllText(GetSaveFilePath(), _jsonText);
    }

    //=================================================================================
    //削除
    //=================================================================================

    /// <summary>
    /// データを全て削除し、初期化する。
    /// </summary>
    public void Delete()
    {
        _jsonText = JsonUtility.ToJson(new SaveData());
        Reload();
    }

    //=================================================================================
    //保存先のパス
    //=================================================================================

    //保存する場所のパスを取得。
    private static string GetSaveFilePath()
    {

        string filePath = "SaveData";

        //確認しやすいようにエディタではAssetsと同じ階層に保存し、それ以外ではApplication.persistentDataPath以下に保存するように。
#if UNITY_EDITOR
        filePath += ".json";
#else
    filePath = Application.persistentDataPath + "/" + filePath;
#endif

        return filePath;
    }

}