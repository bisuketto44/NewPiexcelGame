using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live_Data_Information : MonoBehaviour
{
    public List<Item_Effective> ItemsEffective;
    public List<Junle_Effective> JuneEffective;
    public List<Style_Effective> StyleEffective;
    public List<Motivation_Effective> MotivationEffectives;
    public List<CollaboChar_Effective> CollaboChaeEffcrive;
    public List<LiveTime> LiveTimeEffective;
    public float[,] ConboMultipule;

    void Awake()
    {
        //配列 = アイテム配列と一緒
        //各効果を10%UP
        ItemsEffective = new List<Item_Effective>();
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "青いエレキギター", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "クラッシクギター", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "快眠ベッド", "やる気回復速度"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "ソファ", "やる気回復速度"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "木製丸テーブル", "やる気回復速度"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "ガラス制テーブル", "やる気回復速度"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "青色ランプ", "視聴継続率UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "ドレッサー", "視聴継続率UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "観葉植物", "視聴継続率UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "真ん丸カーペット", "視聴継続率UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "本棚", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "３色収納棚", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "青いドラムセット", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "高性能マイク", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "液晶テレビ", "視聴者数UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "YBOX", "レアチャット獲得確立UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "WEE", "レアチャット獲得確立UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "キューブ型", "レアチャット獲得確立UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.1f, 10, "アーケード", "レアチャット獲得確立UP"));
        ItemsEffective.Add(new Item_Effective(false, 0.15f, 10, "PC1", "全効果"));
        ItemsEffective.Add(new Item_Effective(false, 0.15f, 10, "PC2", "全効果"));

        //ジャンル効果
        //固定値UP
        JuneEffective = new List<Junle_Effective>();
        JuneEffective.Add(new Junle_Effective(false, 50, "ゲーム配信"));
        JuneEffective.Add(new Junle_Effective(false, 50, "歌配信"));
        JuneEffective.Add(new Junle_Effective(false, 50, "ダンス配信"));
        JuneEffective.Add(new Junle_Effective(false, 50, "雑談配信"));
        JuneEffective.Add(new Junle_Effective(false, 50, "お絵描き配信"));
        JuneEffective.Add(new Junle_Effective(false, 50, "コラボ配信"));

        //スタイル効果
        StyleEffective = new List<Style_Effective>();
        StyleEffective.Add(new Style_Effective(false, 10, "真面目"));
        StyleEffective.Add(new Style_Effective(false, 10, "おもしろ"));
        StyleEffective.Add(new Style_Effective(false, 10, "エロス"));
        StyleEffective.Add(new Style_Effective(false, 10, "炎上"));
        StyleEffective.Add(new Style_Effective(false, 10, "可愛い"));
        StyleEffective.Add(new Style_Effective(false, 10, "狂気"));

        //時間
        LiveTimeEffective = new List<LiveTime>();
        LiveTimeEffective.Add(new LiveTime(false, 15, "短い"));
        LiveTimeEffective.Add(new LiveTime(false, 20, "通常"));
        LiveTimeEffective.Add(new LiveTime(false, 25, "長い"));


        //やる気効果
        MotivationEffectives = new List<Motivation_Effective>();
        MotivationEffectives.Add(new Motivation_Effective(false, 1f, 0));
        MotivationEffectives.Add(new Motivation_Effective(false, 1.25f, 2));
        MotivationEffectives.Add(new Motivation_Effective(false, 1.5f, 4));
        MotivationEffectives.Add(new Motivation_Effective(false, 2f, 6));

        //コンボ倍率
        //縦が真面目、おもしろ、エロス、炎上、可愛い、狂気の６個、横が、ゲーム配信、歌配信、ダンス配信、雑談配信、お絵描き配信の５個の２次元配列
        //1fの部分は後で乱数倍率にする
        ConboMultipule = new float[,] { { 1.1f, 1.2f, 1.1f, 1f, 1.0f, 1f }, { 1.2f, 0.9f, 1.0f, 1f, 1.1f, 1f }, { 1.0f, 1.0f, 1.1f, 1f, 1.2f, 1f },
        { 1.0f, 1.2f, 1.2f, 1f, 1.1f, 1f }, { 1.1f, 1.0f, 1.1f, 1f, 1.2f, 1f } };

        //コラボキャラの倍率
        CollaboChaeEffcrive = new List<CollaboChar_Effective>();
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.1f, "ニック"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.1f, "アメリア"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.2f, "親方"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.2f, "ルーシーシェフ"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.3f, "オランジーノ"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.3f, "アンドロイフォン"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.4f, "新伊麦一郎"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.4f, "ヨウドルちゃん"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.5f, "ゴーストン"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.6f, "ウォーキングアンデット"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.7f, "ビビデバビデ嬢"));
        CollaboChaeEffcrive.Add(new CollaboChar_Effective(false, 1.8f, "Mr.サンタクロース"));

    }
}
