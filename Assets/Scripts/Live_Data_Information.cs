using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live_Data_Information : MonoBehaviour
{

    public float[,] ConboMultipule;

    void Awake()
    {

        //ゲーム初回起動時はデータを読み込み()
        if (SaveData.Instance.PreviousDataIsAvailableOrNot == false)
        {
            //SaveDataのリストにインスタンスを格納
            //配列 = アイテム配列と一緒
            //各効果を10%UP
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.10f, 10, "青いエレキギター", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.10f, 10, "クラッシクギター", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.10f, 10, "快眠ベッド", "やる気回復速度"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.10f, 10, "ソファ", "やる気回復速度"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.05f, 10, "木製丸テーブル", "やる気回復速度"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.05f, 10, "ガラス制テーブル", "やる気回復速度"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.15f, 10, "青色ランプ", "視聴継続率UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.355f, 10, "ドレッサー", "視聴継続率UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.05f, 10, "観葉植物", "視聴継続率UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.15f, 10, "真ん丸カーペット", "視聴継続率UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.15f, 10, "本棚", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.15f, 10, "３色収納棚", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.2f, 10, "青いドラムセット", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.25f, 10, "高性能マイク", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.30f, 10, "液晶テレビ", "視聴者数UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.05f, 10, "YBOX", "レアチャット獲得確立UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.05f, 10, "WEE", "レアチャット獲得確立UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.05f, 10, "キューブ型", "レアチャット獲得確立UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.55f, 10, "アーケード", "レアチャット獲得確立UP"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.15f, 10, "PC1", "全効果"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0.15f, 10, "PC2", "全効果"));
            SaveData.Instance.Item_Effectives.Add(new Item_Effective(false, 0f, 0, "スタイル強化キット", "スタイル強化キット"));


            //ジャンル効果
            //固定値UP
            SaveData.Instance.junle_Effective.Add(new Junle_Effective(false, 50, "ゲーム配信"));
            SaveData.Instance.junle_Effective.Add(new Junle_Effective(false, 50, "歌配信"));
            SaveData.Instance.junle_Effective.Add(new Junle_Effective(false, 50, "ダンス配信"));
            SaveData.Instance.junle_Effective.Add(new Junle_Effective(false, 50, "雑談配信"));
            SaveData.Instance.junle_Effective.Add(new Junle_Effective(false, 50, "お絵描き配信"));
            SaveData.Instance.junle_Effective.Add(new Junle_Effective(false, 50, "コラボ配信"));

            //スタイル効果

            SaveData.Instance.Style_Effective.Add(new Style_Effective(false, 10, "真面目"));
            SaveData.Instance.Style_Effective.Add(new Style_Effective(false, 10, "おもしろ"));
            SaveData.Instance.Style_Effective.Add(new Style_Effective(false, 10, "エロス"));
            SaveData.Instance.Style_Effective.Add(new Style_Effective(false, 10, "炎上"));
            SaveData.Instance.Style_Effective.Add(new Style_Effective(false, 10, "可愛い"));
            SaveData.Instance.Style_Effective.Add(new Style_Effective(false, 10, "狂気"));

            //時間
            SaveData.Instance.LiveTime.Add(new LiveTime(false, 15, "短い"));
            SaveData.Instance.LiveTime.Add(new LiveTime(false, 20, "通常"));
            SaveData.Instance.LiveTime.Add(new LiveTime(false, 25, "長い"));


            //やる気効果
            SaveData.Instance.motivation_Effective.Add(new Motivation_Effective(false, 1f, 0));
            SaveData.Instance.motivation_Effective.Add(new Motivation_Effective(false, 1.25f, 2));
            SaveData.Instance.motivation_Effective.Add(new Motivation_Effective(false, 1.5f, 4));
            SaveData.Instance.motivation_Effective.Add(new Motivation_Effective(false, 2f, 6));

            //コラボキャラの倍率
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.1f, "ニック"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.1f, "アメリア"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.2f, "親方"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.2f, "ルーシーシェフ"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.3f, "オランジーノ"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.3f, "アンドロイフォン"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.4f, "新伊麦一郎"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.4f, "ヨウドルちゃん"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.5f, "ゴーストン"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.6f, "ウォーキングアンデット"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.7f, "ビビデバビデ嬢"));
            SaveData.Instance.CollaboChar_Effective.Add(new CollaboChar_Effective(false, 1.8f, "Mr.サンタクロース"));
        }

        //コンボ倍率
        //縦が真面目、おもしろ、エロス、炎上、可愛い、狂気の６個、横が、ゲーム配信、歌配信、ダンス配信、雑談配信、お絵描き配信の５個の２次元配列
        //1fの部分は後で乱数倍率にする
        ConboMultipule = new float[,] { { 1.1f, 1.2f, 1.1f, 1f, 1.0f, 1f }, { 1.2f, 0.9f, 1.0f, 1f, 1.1f, 1f }, { 1.0f, 1.0f, 1.1f, 1f, 1.2f, 1f },
        { 1.0f, 1.2f, 1.2f, 1f, 1.1f, 1f }, { 1.1f, 1.0f, 1.1f, 1f, 1.2f, 1f } };

    }
}
