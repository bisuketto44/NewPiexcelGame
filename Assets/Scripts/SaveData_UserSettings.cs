using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// クラスを丸ごとJsonで保存するデータクラス
/// </summary>
[Serializable]
public class SaveData_UserSettings : ISerializationCallbackReceiver
{

    //シングルトンを実装するための実体、初アクセス時にLoadする。
    private static SaveData_UserSettings _instance = null;
    public static SaveData_UserSettings Instance
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

    [SerializeField]
    public bool isdata;

    [SerializeField]
    public int minute;
    [SerializeField]
    public int hour;
    [SerializeField]
    public float InGamePassedTime;
    [SerializeField]
    public float oldTime;

    [SerializeField]
    public float SEfloat = 1f;
    [SerializeField]
    public float BGMfloat = 1f;



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
        _instance = JsonUtility.FromJson<SaveData_UserSettings>(GetJson());
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
            _jsonText = JsonUtility.ToJson(new SaveData_UserSettings());
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
        _jsonText = JsonUtility.ToJson(new SaveData_UserSettings());
        Reload();
    }

    //=================================================================================
    //保存先のパス
    //=================================================================================

    //保存する場所のパスを取得。
    private static string GetSaveFilePath()
    {

        string filePath = "SaveData_UserSettings";

        //確認しやすいようにエディタではAssetsと同じ階層に保存し、それ以外ではApplication.persistentDataPath以下に保存するように。
#if UNITY_EDITOR
        filePath += ".json";
#else
    filePath = Application.persistentDataPath + "/" + filePath;
#endif

        return filePath;
    }

}